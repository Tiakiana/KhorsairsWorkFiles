#pragma checksum "C:\Users\Jakob\source\repos\ToBeDeleted\ToBeDeleted\Views\Person\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60f2be73acb93e2a18559fa8f4a8a518fd089f09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Person_Index), @"mvc.1.0.view", @"/Views/Person/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Person/Index.cshtml", typeof(AspNetCore.Views_Person_Index))]
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
#line 1 "C:\Users\Jakob\source\repos\ToBeDeleted\ToBeDeleted\Views\_ViewImports.cshtml"
using ToBeDeleted;

#line default
#line hidden
#line 2 "C:\Users\Jakob\source\repos\ToBeDeleted\ToBeDeleted\Views\_ViewImports.cshtml"
using ToBeDeleted.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60f2be73acb93e2a18559fa8f4a8a518fd089f09", @"/Views/Person/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09303f89e8bf4787f26c11bb477ad4c9b544c5f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Person_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Jakob\source\repos\ToBeDeleted\ToBeDeleted\Views\Person\Index.cshtml"
  
    ViewData["Title"] = "Creation Index";

#line default
#line hidden
            BeginContext(52, 196, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<hr />\r\n<div class=\"row\">\r\n    <a class=\"btn btn-default\" href=\"/person/create\">Create Players</a>\r\n    <a class=\"btn btn-default\" href=\"/api/players\">See Players</a>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
