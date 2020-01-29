#pragma checksum "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba4127adc2ede70f585ae6b038e93b0786118b15"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba4127adc2ede70f585ae6b038e93b0786118b15", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8746225dab7920839a12f27f49bac0c7fe28ca08", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MarketProject.Data.Model.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
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

            .panel-table .panel-body .table-bordered > thea");
            WriteLiteral(@"d > tr:first-of-type > th {
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
    <div class");
            WriteLiteral(@"=""row"">
        <div class=""col-md-12"">
            <div class=""panel panel-default panel-table"">
                <div class=""panel-heading"">
                    <div class=""row"">
                        <div style=""margin-left:20px;"" text-left"">
                            <button type=""button"" onclick=""ProductCreate(this)"" class=""btn btn-sm btn-primary btn-create"">Ürün Ekle</button>
                        </div>
                    </div>
                </div>
                <div class=""panel-body"">
                    <table class=""table table-striped table-bordered table-list"">
                        <thead>
                            <tr>
                                <th class=""hidden-xs"">ID</th>
                                <th>Adı</th>
                                <th>Kategori</th>
                                <th>Stok</th>
                                <th>Fiyat</th>
                                <th><em class=""fa fa-cog""></em></th>
                            ");
            WriteLiteral("</tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 94 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td class=\"hidden-xs\">");
#nullable restore
#line 97 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                                                     Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 98 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 99 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                                   Write(item.ProductType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 100 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                                   Write(item.Stock);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 101 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                                   Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td align=\"center\">\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3819, "\"", 3847, 2);
            WriteAttributeValue("", 3826, "/ProductEdit/", 3826, 13, true);
#nullable restore
#line 103 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
WriteAttributeValue("", 3839, item.Id, 3839, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-success\"><em class=\"fa fa-shopping-cart\"></em></a>\r\n                                        <a");
            BeginWriteAttribute("href", " href=\"", 3958, "\"", 3986, 2);
            WriteAttributeValue("", 3965, "/ProductEdit/", 3965, 13, true);
#nullable restore
#line 104 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
WriteAttributeValue("", 3978, item.Id, 3978, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info\"><em class=\"fa fa-pencil\"></em></a>\r\n                                        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 4087, "\"", 4122, 3);
            WriteAttributeValue("", 4097, "ProductDelete(\'", 4097, 15, true);
#nullable restore
#line 105 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
WriteAttributeValue("", 4112, item.Id, 4112, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4120, "\')", 4120, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\"><em class=\"fa fa-trash\"></em></a>\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 108 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    function ProductCreate() {
        window.location.href = ""/Product/ProductCreate"";
    }

    function ProductDelete(e) {
        var sonuc = confirm(""Kayıt Silinsin mi?"")
        if (sonuc) {
            var id = e;
            $.post(""/Product/ProductDelete"", { id: id }, function (res) {
                if (res) {
                    window.location.href = ""/Product/Index"";
                }
                else {
                    alert(""Hata Oluştu"")
                }
            });
        }
        else {
            ShowMessage(""warning"", ""Kayıt Silme"", ""Kayıt Silme İşlemi İptal Edildi."");
        }
    }

    //function ProductEdit(e) {
    //      var id = e;
    //        $.post(""/Product/ProductEdit"", { id: id }, function (res) {
               
    //        });
    //}
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MarketProject.Data.Model.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591