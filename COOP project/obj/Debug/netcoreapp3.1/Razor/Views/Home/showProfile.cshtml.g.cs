#pragma checksum "C:\Users\almub\source\repos\COOP project\COOP project\Views\Home\showProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10a4c5663b41110b9e8c1019a8f28786928147b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_showProfile), @"mvc.1.0.view", @"/Views/Home/showProfile.cshtml")]
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
#nullable restore
#line 1 "C:\Users\almub\source\repos\COOP project\COOP project\Views\_ViewImports.cshtml"
using COOP_project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\almub\source\repos\COOP project\COOP project\Views\_ViewImports.cshtml"
using COOP_project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\almub\source\repos\COOP project\COOP project\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10a4c5663b41110b9e8c1019a8f28786928147b1", @"/Views/Home/showProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e971c3d1120f52717904cf00373af1cb4ca785e8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_showProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<COOP_project.Models.User>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section class=""pb-1"">
    <div class=""bg-white border rounded-1"">

        <section class=""w-30 px-1 py-1"" style=""background-color: #f4f5f7; border-radius: .5rem .5rem 0 0;"">
            <style>
                .gradient-custom {
                    /* fallback for old browsers */
                    background: #f6d365;
                    /* Chrome 10-25, Safari 5.1-6 */
                    background: -webkit-linear-gradient(to right bottom, rgba(246, 211, 101, 1), rgba(253, 160, 133, 1));
                    /* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
                    background: linear-gradient(to right bottom, rgba(246, 211, 101, 1), rgba(253, 160, 133, 1))
                }
            </style>
            <div class=""row d-flex justify-content-center"">
                <div class=""col col-lg-7 mb-4 mb-lg-0"">
                    <div class=""card"" style=""border-radius: .5rem;"">
                        <div class=""row g-0"">
                            <div class=""col-md-4 g");
            WriteLiteral(@"radient-custom text-center text-white"" 
                            style=""border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;"">
                                <br />
                                <br />
                                <br />
                                <br />

                                <br />
                                <br />
                                <br />
                                <h1> <i class=""bi bi-person""></i></h1>
                                <p></p>

                            </div>
                            <div class=""col-md-8"">
                                <div class=""card-body p-4"">
                                    <h6>Information</h6>
                                    <hr class=""mt-0 mb-4"">
                                    <div class=""row pt-1"">
                                        <div class=""col-6 mb-3"">
                                            <h6>Email</h6>
                                            <p clas");
            WriteLiteral("s=\"text-muted\"> ");
#nullable restore
#line 42 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Home\showProfile.cshtml"
                                                              Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                                        </div>\n                                        <div class=\"col-6 mb-3\">\n                                            <h6>Phone</h6>\n                                            <p class=\"text-muted\"> ");
#nullable restore
#line 46 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Home\showProfile.cshtml"
                                                              Write(Html.DisplayFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>
                                    </div>

                                    <hr class=""mt-0 mb-4"">
                                    <div class=""row pt-1"">
                                        <div class=""col-6 mb-3"">
                                            <h6>User name</h6>
                                            <p class=""text-muted""> ");
#nullable restore
#line 54 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Home\showProfile.cshtml"
                                                              Write(Html.DisplayFor(model => model.userName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                                        </div>\n                                        <div class=\"col-6 mb-3\">\n                                            <h6>Role Name</h6>\n                                            <p class=\"text-muted\"> ");
#nullable restore
#line 58 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Home\showProfile.cshtml"
                                                              Write(Html.DisplayFor(model => model.Role.roleName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>






    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<COOP_project.Models.User> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
