#pragma checksum "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1254cd24485d6b9f84cf010072e48c03d5fb2596"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ApprovedCandidates), @"mvc.1.0.view", @"/Views/Home/ApprovedCandidates.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1254cd24485d6b9f84cf010072e48c03d5fb2596", @"/Views/Home/ApprovedCandidates.cshtml")]
    #nullable restore
    public class Views_Home_ApprovedCandidates : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Approved Candidates </h1>\r\n\r\n<table class=\"table table-bordered\">\r\n    <tr>\r\n        <th>RowKey</th>\r\n        <th>PartionKey</th>\r\n        <th>FullName</th>\r\n        <th>Email</th>\r\n    </tr>\r\n\r\n\r\n\r\n");
#nullable restore
#line 13 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"
     foreach (var item in ViewBag.cadidates as List<AzureStorageLibrary.Models.Candidate>)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 16 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"
           Write(item.RowKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 17 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"
           Write(item.PartitionKey);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 18 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"
           Write(item.fullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 19 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"
           Write(item.email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 21 "C:\Users\TCALERDOGAN\source\repos\Spy.Recruiter.Mvc\Spy.Recruiter.Mvc\Views\Home\ApprovedCandidates.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591