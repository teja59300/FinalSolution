#pragma checksum "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d0077c5d93a52556e0a7454d5920ff4ed12096c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CartList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CartList/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/CartList/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_CartList_Default))]
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
#line 1 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\_ViewImports.cshtml"
using WebMvc;

#line default
#line hidden
#line 2 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\_ViewImports.cshtml"
using WebMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d0077c5d93a52556e0a7454d5920ff4ed12096c", @"/Views/Shared/Components/CartList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82dfb9e8d9c1e15d2e9f7b4d3cf193b2b540299a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CartList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderMyFoodApp.Web.WebMvc.Models.CartModels.Cart>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
  
    ViewData["Title"] = "My Cart";

#line default
#line hidden
            BeginContext(104, 27, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n");
            EndContext();
#line 9 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
     if (TempData.ContainsKey("BasketInoperativeMsg"))
    {

#line default
#line hidden
            BeginContext(194, 90, true);
            WriteLiteral("        <br />\r\n        <div class=\"alert alert-warning\" role=\"alert\">\r\n            &nbsp;");
            EndContext();
            BeginContext(285, 32, false);
#line 13 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
             Write(TempData["BasketInoperativeMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(317, 18, true);
            WriteLiteral("\r\n        </div>\r\n");
            EndContext();
#line 15 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(359, 69, true);
            WriteLiteral("        <article class=\"esh-basket-titles row\">\r\n            <br />\r\n");
            EndContext();
#line 20 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
             if (TempData.ContainsKey("BasketInoperativeMsg"))
            {

#line default
#line hidden
            BeginContext(507, 90, true);
            WriteLiteral("                <div class=\"alert alert-warning\" role=\"alert\">\r\n                    &nbsp;");
            EndContext();
            BeginContext(598, 32, false);
#line 23 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                     Write(TempData["BasketInoperativeMsg"]);

#line default
#line hidden
            EndContext();
            BeginContext(630, 26, true);
            WriteLiteral("\r\n                </div>\r\n");
            EndContext();
#line 25 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
            }

#line default
#line hidden
            BeginContext(671, 396, true);
            WriteLiteral(@"
            <section class=""esh-basket-title col-xs-3"">Product</section>
            <section class=""esh-basket-title col-xs-3 hidden-lg-down""></section>
            <section class=""esh-basket-title col-xs-2"">Price</section>
            <section class=""esh-basket-title col-xs-2"">Quantity</section>
            <section class=""esh-basket-title col-xs-2"">Cost</section>
        </article>
");
            EndContext();
#line 34 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
         for (int i = 0; i < Model.Items.Count; i++)
        {
            var item = Model.Items[i];


#line default
#line hidden
            BeginContext(1176, 232, true);
            WriteLiteral("            <article class=\"esh-basket-items  row\">\r\n                <div>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-lg-3 hidden-lg-down\">\r\n                        <img class=\"esh-basket-image\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 1408, "\"", 1430, 1);
#line 41 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1414, item.PictureUrl, 1414, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1431, 123, true);
            WriteLiteral(" />\r\n                    </section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-3\">");
            EndContext();
            BeginContext(1555, 16, false);
#line 43 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                                                                                 Write(item.ProductName);

#line default
#line hidden
            EndContext();
            BeginContext(1571, 100, true);
            WriteLiteral("</section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-2\">$ ");
            EndContext();
            BeginContext(1672, 29, false);
#line 44 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                                                                                   Write(item.UnitPrice.ToString("N2"));

#line default
#line hidden
            EndContext();
            BeginContext(1701, 144, true);
            WriteLiteral("</section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle col-xs-2\">\r\n                        <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 1845, "\"", 1881, 1);
#line 46 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1852, "quantities[" + i +"].Key", 1852, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1882, "\"", 1898, 1);
#line 46 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1890, item.Id, 1890, 8, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1899, 82, true);
            WriteLiteral(" />\r\n                        <input type=\"number\" class=\"esh-basket-input\" min=\"1\"");
            EndContext();
            BeginWriteAttribute("name", " name=\"", 1981, "\"", 2019, 1);
#line 47 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 1988, "quantities[" + i +"].Value", 1988, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2020, "\"", 2042, 1);
#line 47 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
WriteAttributeValue("", 2028, item.Quantity, 2028, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2043, 147, true);
            WriteLiteral(" />\r\n                    </section>\r\n                    <section class=\"esh-basket-item esh-basket-item--middle esh-basket-item--mark col-xs-2\">$ ");
            EndContext();
            BeginContext(2191, 60, false);
#line 49 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                                                                                                         Write(Math.Round(item.Quantity * item.UnitPrice, 2).ToString("N2"));

#line default
#line hidden
            EndContext();
            BeginContext(2251, 121, true);
            WriteLiteral("</section>\r\n                </div>\r\n                <div class=\"row\">\r\n\r\n                </div>\r\n            </article>\r\n");
            EndContext();
            BeginContext(2374, 56, true);
            WriteLiteral("            <div class=\"esh-basket-items--border row\">\r\n");
            EndContext();
#line 57 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                 if (item.OldUnitPrice != 0)
                {

#line default
#line hidden
            BeginContext(2495, 215, true);
            WriteLiteral("                    <div class=\"alert alert-warning esh-basket-margin12\" role=\"alert\">&nbsp;Note that the price of this article changed in our Catalog. The old price when you originally added it to the basket was $ ");
            EndContext();
            BeginContext(2711, 17, false);
#line 59 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                                                                                                                                                                                                                  Write(item.OldUnitPrice);

#line default
#line hidden
            EndContext();
            BeginContext(2728, 9, true);
            WriteLiteral(" </div>\r\n");
            EndContext();
#line 60 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                }

#line default
#line hidden
            BeginContext(2756, 40, true);
            WriteLiteral("            </div>\r\n            <br />\r\n");
            EndContext();
#line 63 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
        }

#line default
#line hidden
            BeginContext(2809, 490, true);
            WriteLiteral(@"        <div class=""container"">
            <article class=""esh-basket-titles esh-basket-titles--clean row"">
                <section class=""esh-basket-title col-xs-10""></section>
                <section class=""esh-basket-title col-xs-2"">Total</section>
            </article>

            <article class=""esh-basket-items row"">
                <section class=""esh-basket-item col-xs-10""></section>
                <section class=""esh-basket-item esh-basket-item--mark col-xs-2"">$ ");
            EndContext();
            BeginContext(3300, 13, false);
#line 73 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
                                                                             Write(Model.Total());

#line default
#line hidden
            EndContext();
            BeginContext(3313, 660, true);
            WriteLiteral(@"</section>
            </article>

            <article class=""esh-basket-items row"">
                <section class=""esh-basket-item col-xs-7""></section>
                <section class=""esh-basket-item col-xs-2"">
                    <button class=""btn esh-basket-checkout"" name=""name"" value="""" type=""submit"">[ Update ]</button>
                </section>
                <section class=""esh-basket-item col-xs-3"">
                    <input type=""submit""
                           class=""btn esh-basket-checkout""
                           value=""[ Checkout ]"" name=""action"" />
                </section>
            </article>
        </div>
");
            EndContext();
#line 88 "C:\Users\vmadmin123\source\repos\OrderMyFoodApp\src\Web\WebMvc\Views\Shared\Components\CartList\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(3980, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderMyFoodApp.Web.WebMvc.Models.CartModels.Cart> Html { get; private set; }
    }
}
#pragma warning restore 1591
