#pragma checksum "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0125dd5fe7574af80dce7aa4f4e31bf13afe69ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
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
#line 1 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\_ViewImports.cshtml"
using FurnitureProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\_ViewImports.cshtml"
using FurnitureProject.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\_ViewImports.cshtml"
using FurnitureProject.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\_ViewImports.cshtml"
using FurnitureProject.Areas.Admin.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0125dd5fe7574af80dce7aa4f4e31bf13afe69ee", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac8caedfa6c868e7ad2355e931164d6d9b16ffad", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Widgets  -->
<div class=""row"">
    <div class=""col-lg-3 col-md-6"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""stat-widget-five"">
                    <div class=""stat-icon dib flat-color-1"">
                        <i class=""pe-7s-cash""></i>
                    </div>
                    <div class=""stat-content"">
                        <div class=""text-left dib"">
                            <div class=""stat-text"">$<span class=""count"">23569</span></div>
                            <div class=""stat-heading"">Revenue</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-lg-3 col-md-6"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""stat-widget-five"">
                    <div class=""stat-icon dib flat-color-2"">
                        <i class=""pe-7s-cart""></i>
                    </div>
      ");
            WriteLiteral(@"              <div class=""stat-content"">
                        <div class=""text-left dib"">
                            <div class=""stat-text""><span class=""count"">3435</span></div>
                            <div class=""stat-heading"">Sales</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""col-lg-3 col-md-6"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""stat-widget-five"">
                    <div class=""stat-icon dib flat-color-3"">
                        <i class=""pe-7s-browser""></i>
                    </div>
                    <div class=""stat-content"">
                        <div class=""text-left dib"">
                            <div class=""stat-text""><span class=""count"">349</span></div>
                            <div class=""stat-heading"">Templates</div>
                        </div>
                    </div>
                </div>");
            WriteLiteral(@"
            </div>
        </div>
    </div>

    <div class=""col-lg-3 col-md-6"">
        <div class=""card"">
            <div class=""card-body"">
                <div class=""stat-widget-five"">
                    <div class=""stat-icon dib flat-color-4"">
                        <i class=""pe-7s-users""></i>
                    </div>
                    <div class=""stat-content"">
                        <div class=""text-left dib"">
                            <div class=""stat-text""><span class=""count"">2986</span></div>
                            <div class=""stat-heading"">Clients</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- /Widgets -->

<div class=""clearfix""></div>
");
#nullable restore
#line 78 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Areas\Admin\Views\Dashboard\Index.cshtml"
Write(await Component.InvokeAsync("User"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
