#pragma checksum "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c572338256322e7ad0851c45659aa5f3630a6186"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_ProductCreate), @"mvc.1.0.view", @"/Views/Product/ProductCreate.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c572338256322e7ad0851c45659aa5f3630a6186", @"/Views/Product/ProductCreate.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8746225dab7920839a12f27f49bac0c7fe28ca08", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_ProductCreate : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SelectListItem>>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml"
  
    ViewData["Title"] = "ProductCreate";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-8"">
            <div class=""form-group"">
                <label for=""formGroupExampleInput"">Ürün Adı</label>
                <input type=""text"" class=""form-control"" id=""name"" placeholder=""Ürün Adı Giriniz."">
            </div>
            <div class=""form-group"">
                <label for=""formGroupExampleInput"">Kategori</label>
                <select class=""form-control"" id=""category"">
");
#nullable restore
#line 18 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c572338256322e7ad0851c45659aa5f3630a61864263", async() => {
#nullable restore
#line 20 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml"
                                               Write(item.Text);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 20 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml"
                           WriteLiteral(item.Value);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 21 "D:\Yazılım\GitHup-Projeler\MarketProject\MarketProject.Web\Views\Product\ProductCreate.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </select>
            </div>
            <div class=""form-group"">
                <label for=""formGroupExampleInput"">Ürün Fiyatı</label>
                <input type=""number"" class=""form-control"" id=""price"" placeholder=""Ürün Fiyatı Giriniz."">
            </div>
            <div class=""form-group"">
                <label for=""formGroupExampleInput"">Stok</label>
                <input type=""number"" class=""form-control"" id=""stock"" placeholder=""Stok Miktarı Giriniz."">
            </div>
            <button type=""button"" onclick=""CreateProduct(this)"" class=""btn btn-success"">Ekle</button>
        </div>
    </div>
</div>


<script>
    function CreateProduct(e) {
        var sonuc = confirm(""Kayıt Eklensin mi?"")
        if (sonuc) {
            var name = $(""#name"").val();
            var price = $(""#price"").val();
            var stock = $(""#stock"").val();
            var category = $(""#category"").val();

            $.post(""/Product/ProductCreate"", { name: name, price: pr");
            WriteLiteral(@"ice, stock: stock, category: category }, function (res) {
                if (res) {
                    window.location.href = ""/Product/Index"";
                }
                else {
                    alert(""Hata Oluştu"")
                }
            });
        }
        else {
            ShowMessage(""success"", ""Kayıt Ekleme"", ""Kayıt Ekleme İşlemi İptal Edildi."");
        }

    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SelectListItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591