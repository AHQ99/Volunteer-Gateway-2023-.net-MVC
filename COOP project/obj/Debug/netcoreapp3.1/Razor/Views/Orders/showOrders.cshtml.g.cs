#pragma checksum "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b13b032699316d70f9cbda762e039173b5edbf43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_showOrders), @"mvc.1.0.view", @"/Views/Orders/showOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b13b032699316d70f9cbda762e039173b5edbf43", @"/Views/Orders/showOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e971c3d1120f52717904cf00373af1cb4ca785e8", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Orders_showOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<COOP_project.Models.Order>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "workInfo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("action-icon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("delForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("sendForm(event)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "showOrders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-soft-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13b032699316d70f9cbda762e039173b5edbf436105", async() => {
                WriteLiteral(@"
    <section class=""container"">
        <script>
            
            function sendForm(e) {
                e.preventDefault();

                Swal.fire({
                    title: 'Do you want to delete your submission?',
                    icon: 'question',
                    showCancelButton: true,
                    showClass: {
                    popup: 'animate__animated animate__fadeInDown'
                    },
                }).then(result => {
                    if (result.isConfirmed) {
                        const del = document.getElementById('delForm');
                        del.submit();
                    }

                })
            }
");
#nullable restore
#line 25 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
          
            if(@ViewData["succ"] != null)
            { 
                

#line default
#line hidden
#nullable disable
                WriteLiteral("                    ");
                WriteLiteral("\r\n                        $(document).ready(function () \r\n                        {\r\n                         var result = \'");
#nullable restore
#line 32 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                  Write(Html.Raw(ViewData["succ"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
                         Swal.fire(result, '', 'success')
                                .then(
                                    function () 
                                    {
                                        window.location.href = '");
#nullable restore
#line 37 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                                           Write(Url.Action("showOrders","Orders"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n                                    }\r\n                                );\r\n                        });\r\n                    ");
#nullable restore
#line 41 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                           
            }
        

#line default
#line hidden
#nullable disable
                WriteLiteral("        </script>\r\n");
#nullable restore
#line 45 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
     if(Model.Count()==0)
	{

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h1 class=\"text-center\">You didnt sign to voulnteer works</h1>\r\n");
#nullable restore
#line 48 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <div class=\"table-responsive\">\r\n");
                WriteLiteral(@"            <table class=""table table-centered w-100 dt-responsive nowrap"" id=""products-datatable"" style=""border-collapse: collapse; border-spacing: 0; width: 100%;"">
                <thead class=""table-light"">
                    <tr>
                        <th class=""all"" style=""width: 20px;"">
                            <div class=""form-check font-16 mb-0"">
                                <label class=""form-check-label"" for=""productlistCheck"">&nbsp;</label>
                            </div>
                        </th>
                        <th class=""all"">Voulnteer Work</th>
                        <th>Building</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Supervisor</th>
                        <th></th>
                        <th>Status</th>
                        <th style=""width: 85px;"">Action</th>
                    </tr>
                </thead>
");
#nullable restore
#line 72 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                 foreach (var item in Model)
                {
                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        <tbody class=""bg-white"">
                            <tr>
                                <td>
                                    <div class=""form-check font-16 mb-0"">
                                        <label class=""form-check-label"" for=""productlistCheck1"">&nbsp;</label>
                                    </div>
                                </td>
                                <td>
                                    <h5 class=""m-0 d-inline-block align-middle""><a href=""#"" class=""text-dark"">");
#nullable restore
#line 83 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                                                                                         Write(item.Work.workName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></h5>\r\n                                </td>\r\n                                <td>\r\n                                    <span>");
#nullable restore
#line 86 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                     Write(item.Work.Building.buildingName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</span>\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 89 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                               Write(item.Work.Date);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                        ");
#nullable restore
#line 92 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                   Write(item.Work.endDate);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    <div>\r\n                                        ");
#nullable restore
#line 96 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                   Write(item.Work.User.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n                                </td>\r\n\r\n                                <td>\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 103 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                     if (item.isSigned == true)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <span class=\"badge badge-soft-primary\">In progress</span>\r\n");
#nullable restore
#line 106 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                    }
                                    else if (item.isRejected == true)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <span class=\"badge badge-soft-danger\">Rejected</span>\r\n");
#nullable restore
#line 110 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                    }
                                    else if (item.isAccepted == true)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <span class=\"badge badge-soft-success\">Accepted</span>\r\n");
#nullable restore
#line 114 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                    }
                                    else if (item.isDone == true)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <span class=\"badge badge-soft-success\">Done</span>\r\n");
#nullable restore
#line 118 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </td>
                                <td>
                                    <ul class=""list-inline table-action m-0"">
                                        <li class=""list-inline-item"">
                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13b032699316d70f9cbda762e039173b5edbf4315676", async() => {
                    WriteLiteral(" <i class=\"mdi mdi-eye\"></i>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 123 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                                                       WriteLiteral(item.Work.IdGuid);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                        </li>\r\n\r\n                                        <li class=\"list-inline-item\">\r\n");
#nullable restore
#line 127 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                             if (item.isSigned == true)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b13b032699316d70f9cbda762e039173b5edbf4318578", async() => {
                    WriteLiteral(@"

                                                    <button style=""border: none;background: none;"" type=""submit"" class=""action-icon"">
                                                        <i class=""mdi mdi-delete""></i>
                                                    </button>
                                                    

                                                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 137 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        </li>\r\n\r\n\r\n                                    </ul>\r\n                                </td>\r\n                            </tr>\r\n\r\n                        </tbody>\r\n");
#nullable restore
#line 146 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                \r\n\r\n            </table>\r\n        </div>\r\n");
#nullable restore
#line 151 "C:\Users\almub\source\repos\COOP project\COOP project\Views\Orders\showOrders.cshtml"
    }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\t\r\n\t\r\n\t<!--Work Name-->\r\n    \r\n   \r\n    \r\n    </section>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    \r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<COOP_project.Models.Order>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
