using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureStorageLibrary.Models
{
    public class Candidate : TableEntity
    {
        public string candidateId { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public bool? isShown { get; set; }
        public bool? isAccepted { get; set; } 
        public string experience { get; set; }
         
    }


}




