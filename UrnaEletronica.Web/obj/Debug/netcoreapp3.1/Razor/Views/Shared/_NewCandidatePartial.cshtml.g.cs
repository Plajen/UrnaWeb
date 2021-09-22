#pragma checksum "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b4aefe7ea723c57cdb97472934282eabd705c0f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(UrnaEletronica.Web.Views.Shared.Views_Shared__NewCandidatePartial), @"mvc.1.0.view", @"/Views/Shared/_NewCandidatePartial.cshtml")]
namespace UrnaEletronica.Web.Views.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\_ViewImports.cshtml"
using UrnaEletronica.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
using UrnaEletronica.Application.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4aefe7ea723c57cdb97472934282eabd705c0f2", @"/Views/Shared/_NewCandidatePartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c49ad8962569753d0506e49ad7c9cedffd06f84e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NewCandidatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CandidateViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
 using (Html.BeginForm("New", "Candidate", FormMethod.Post, new { id = "form-candidate", @class = "modal-content" }))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""modal-header p-2"" style=""padding-left: 20px !important"">
        <div class=""mt-3"">
            <h5 class=""modal-title font-strong"">NOVO CANDIDATO</h5>
        </div>
        <button class=""close"" type=""button"" aria-label=""Close"" id=""close-new-candidate-modal"">
            <span aria-hidden=""true"">×</span>
        </button>
    </div>
    <div class=""modal-body p-5"" style=""padding-bottom: 10px !important; padding-top: 20px !important"">
        <div class=""d-flex mb-4 justify-content-center"">
            <div id=""profile-img-container"">
                <i class=""fa fa-user fa-5x""></i>
            </div>
        </div>
        <div class=""form-group mb-4"">
            ");
#nullable restore
#line 21 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.TextBoxFor(x => x.FullName, new { @class = "form-control", @type = "text", @name = "fullname", @placeholder = "Insira o Nome do Candidato", @Id = "FullName", maxlength = "50" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 22 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.ValidationMessageFor(x => x.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group mb-4\">\r\n            ");
#nullable restore
#line 25 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.TextBoxFor(x => x.ViceName, new { @class = "form-control", @type = "text", @name = "vicename", @placeholder = "Insira o Nome do Vice", @Id = "ViceName", maxlength = "50" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 26 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.ValidationMessageFor(x => x.ViceName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"form-group mb-4\">\r\n            ");
#nullable restore
#line 29 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.TextBoxFor(x => x.Ticket, new { @class = "form-control", @type = "text", @name = "ticket", @placeholder = "Insira a Legenda do Candidato", @Id = "Ticket", maxlength = "2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 30 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
       Write(Html.ValidationMessageFor(x => x.Ticket));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer justify-content-between bg-primary-50\">\r\n        <div>\r\n            <button class=\"btn btn-primary mr-3\" id=\"submit-button\" type=\"submit\">Enviar</button>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 38 "C:\Users\jean_\source\repos\urna-eletronica\UrnaEletronica.Web\Views\Shared\_NewCandidatePartial.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CandidateViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591