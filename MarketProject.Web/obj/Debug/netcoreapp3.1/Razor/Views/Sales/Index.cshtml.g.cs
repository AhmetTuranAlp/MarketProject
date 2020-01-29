#pragma checksum "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d827954bdf8ae5ab99a75966338ece03d2d71db6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sales_Index), @"mvc.1.0.view", @"/Views/Sales/Index.cshtml")]
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
#line 1 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\_ViewImports.cshtml"
using MarketProject.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\_ViewImports.cshtml"
using MarketProject.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d827954bdf8ae5ab99a75966338ece03d2d71db6", @"/Views/Sales/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8746225dab7920839a12f27f49bac0c7fe28ca08", @"/Views/_ViewImports.cshtml")]
    public class Views_Sales_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MarketProject.Data.Model.Sales>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    .panel-table .panel-body {
        padding: 0;
    }

        .panel-table .panel-body .table-bordered {
            border-style: none;
            margin: 0;
        }

            .panel-table .panel-body .table-bordered > thead > tr > th:first-of-type {
                text-align: center;
                width: 100px;
            }

            .panel-table .panel-body .table-bordered > thead > tr > th:last-of-type,
            .panel-table .panel-body .table-bordered > tbody > tr > td:last-of-type {
                border-right: 0px;
            }

            .panel-table .panel-body .table-bordered > thead > tr > th:first-of-type,
            .panel-table .panel-body .table-bordered > tbody > tr > td:first-of-type {
                border-left: 0px;
            }

            .panel-table .panel-body .table-bordered > tbody > tr:first-of-type > td {
                border-bottom: 0px;
            }

            .panel-table .panel-body .table-bordered > thead ");
            WriteLiteral(@"> tr:first-of-type > th {
                border-top: 0px;
            }

    .panel-table .panel-footer .pagination {
        margin: 0;
    }

    /*
    used to vertically center elements, may need modification if you're not using default sizes.
    */
    .panel-table .panel-footer .col {
        line-height: 34px;
        height: 34px;
    }

    .panel-table .panel-heading .col h3 {
        line-height: 30px;
        height: 30px;
    }

    .panel-table .panel-body .table-bordered > tbody > tr > td {
        line-height: 34px;
    }
</style>

<link href=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css"" rel=""stylesheet"" id=""bootstrap-css"">
<script src=""//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js""></script>
<script src=""//code.jquery.com/jquery-1.11.1.min.js""></script>

<link href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css"" rel='stylesheet' type='text/css'>

<div class=""container"">
    <div class=""");
            WriteLiteral(@"row"">
        <div class=""col-md-12"">
            <div class=""panel panel-default panel-table"">

                <div class=""panel-body"">
                    <table class=""table table-striped table-bordered table-list"">
                        <thead>
                            <tr>
                                <th class=""hidden-xs"">ID</th>
                                <th>Tarih</th>
                                <th>Toplam Fiyat</th>
                                <th>Ödeme Tipi</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 86 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"hidden-xs\">");
#nullable restore
#line 89 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                                                     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 90 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                                   Write(String.Format("{0:dd MM yyyy}", item.UpdateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 91 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                                   Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" TL</td>\r\n                                    <td>");
#nullable restore
#line 92 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                                   Write(item.PaymentType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 94 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Sales\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MarketProject.Data.Model.Sales>> Html { get; private set; }
    }
}
#pragma warning restore 1591