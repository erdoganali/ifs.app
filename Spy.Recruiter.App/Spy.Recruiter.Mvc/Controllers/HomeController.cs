using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spy.Recruiter.Mvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AzureStorageLibrary;
using AzureStorageLibrary.Models;


namespace Spy.Recruiter.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoSqlStorage<AzureStorageLibrary.Models.Candidate> _noSqlStorage;
        public static List<Candidate> _candidateList= new();
        public static List<Technologies> _techList;

        public HomeController(INoSqlStorage<AzureStorageLibrary.Models.Candidate> noSqlStorage)
        {
            _noSqlStorage = noSqlStorage;
        }

        public async void InsertCandidate()
        {
            var jsoncan = System.IO.File.ReadAllText(@"Files\candidates.json");
            var candidates = JsonConvert.DeserializeObject<List<Candidates>>(jsoncan);

            foreach (Candidates i in candidates)
            { 
                await _noSqlStorage.Add(new Candidate
                {
                    RowKey = i.candidateId,
                    PartitionKey = "Candidates",
                    candidateId = i.candidateId,
                    email = i.email,
                    fullName = i.fullName,
                    isAccepted = false,
                    isShown = false,
                    Timestamp = DateTime.Now,
                    experience = JsonConvert.SerializeObject(i.experience) 
                });

            }
        }
        public IActionResult Index()
        { 

            if (_noSqlStorage.All().ToList().Count == 0)
            { 
                InsertCandidate();
            } 


            var jsonTec = System.IO.File.ReadAllText(@"Files\technologies.json");
              _techList = JsonConvert.DeserializeObject<List<Technologies>>(jsonTec);
            List<SelectListItem> values = new(from x in _techList
                                              select new SelectListItem
                                              {
                                                  Text = x.name,
                                                  Value = x.guid
                                              });
            ViewBag.TechItems = values;

            return View();
        }


        [HttpPost]
        public IActionResult Candidate(Candidates.Experience selectedTech)
        {
            if (selectedTech.yearsOfExperience < 0)
            {
               
            }
            _candidateList.Clear();

            var _list = _noSqlStorage.Query(x => x.isShown == false).ToList();

            foreach (var x in _list)
            {
                var _experiences = JsonConvert.DeserializeObject<List<Candidates.Experience>>(x.experience);

                if (_experiences
                    .Where(y => y.technologyId == selectedTech.technologyId
                     && y.yearsOfExperience >= selectedTech.yearsOfExperience)
                    .Any())
                {
                    _candidateList.Add(x);
                } 
                   
            }

            var random = _candidateList.Where(w => w.isShown == false).FirstOrDefault();
            if (random != null)
            {
                return RedirectToAction("SelectCandidate", new { random.candidateId });
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public IActionResult SelectCandidate(string candidateId)
        {
            //ViewBag.remaid  = _noSqlStorage.Query(x => x.isShown == false).ToList().Count;
            ViewBag.remaid  = _candidateList.Where(w => w.isShown == false).ToList().Count;

            var candidate = _candidateList.Where(x => x.candidateId == candidateId && x.isShown == false).FirstOrDefault(); 
            var experiences = JsonConvert.DeserializeObject<List<Candidates.Experience>>(candidate.experience);
             
            experiences.ForEach((x) => {

                x.technologyId = _techList.Where(w => w.guid == x.technologyId).Select(s => s.name).FirstOrDefault();
                
            });
           

            Candidates _candidate = new()
            {
                candidateId = candidate.candidateId,
                fullName = candidate.fullName,
                email = candidate.email,
                experience = experiences
            }; 

            return View(_candidate);
        }


        [HttpPost]
        public IActionResult Approve(Candidates approved)
        {  
            return RedirectToAction("Random", new { candidateId = approved.candidateId, isAccepted = true }); 
        }
        
        
        [HttpPost]
        public IActionResult Reject(Candidates rejected)
        { 
            rejected.isAccepted = false;
            return RedirectToAction("Random", new { candidateId = rejected.candidateId, isAccepted = false });
        }

        
        public async Task<IActionResult> Random(string candidateId, bool isAccepted)
        {
            var _candidate = await _noSqlStorage.Get(candidateId, "Candidates");
            _candidate.isShown = true ;
            _candidate.isAccepted = isAccepted;
            await _noSqlStorage.Update(_candidate);

            var random = _candidateList.Where(x => x.isShown == false).FirstOrDefault();
            if (random != null)
            {
                return RedirectToAction("SelectCandidate", new { random.candidateId });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        public IActionResult ApprovedCandidates()
        {

             var entity =  _noSqlStorage.All().Where(w=>w.isAccepted == true).ToList();

            if (entity != null)
                ViewBag.cadidates = entity;


            return View();
        }

    }
}
