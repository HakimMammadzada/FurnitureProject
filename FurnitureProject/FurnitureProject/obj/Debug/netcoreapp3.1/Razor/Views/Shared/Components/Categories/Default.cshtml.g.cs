#pragma checksum "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7360022500485f0070b586d67a45fb183d08c03b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Categories_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Categories/Default.cshtml")]
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
#line 1 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\_ViewImports.cshtml"
using FurnitureProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\_ViewImports.cshtml"
using FurnitureProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7360022500485f0070b586d67a45fb183d08c03b", @"/Views/Shared/Components/Categories/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f7dc27b6825caaef6a4fb74584d06be1e3e8159", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Categories_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CategoriyModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("    <ul class=\"mega-menu\">\r\n\r\n");
#nullable restore
#line 4 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
         foreach (var categoriy in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n                <a href=\"#\">");
#nullable restore
#line 7 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                       Write(categoriy.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                <ul>\r\n");
#nullable restore
#line 9 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                     if (categoriy.Markas.Any())
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                         foreach (var marka in categoriy.Markas)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li><a href=\"compare.html\">");
#nullable restore
#line 13 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                                                  Write(marka.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 14 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                   \r\n                </ul>\r\n            </li>\r\n");
#nullable restore
#line 19 "C:\Users\User\Desktop\proje\FurnitureProject\FurnitureProject\Views\Shared\Components\Categories\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n       \r\n    </ul>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CategoriyModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
