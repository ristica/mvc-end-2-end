﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    
    #line 1 "..\..\Views\Product\List.cshtml"
    using System.Linq;
    
    #line default
    #line hidden
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Demo.Client;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Product/List.cshtml")]
    public partial class _Views_Product_List_cshtml : System.Web.Mvc.WebViewPage<IEnumerable<Demo.ViewModels.ProductViewModel>>
    {
        public _Views_Product_List_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 4 "..\..\Views\Product\List.cshtml"
  
    ViewBag.Title = "Products";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n");

            
            #line 8 "..\..\Views\Product\List.cshtml"
 if (Model == null || !Model.Any())
{

            
            #line default
            #line hidden
WriteLiteral("    <fieldset");

WriteLiteral(" style=\"margin-top: 50px;\"");

WriteLiteral(">\r\n        <legend>Products inventory</legend>\r\n            <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" id=\"noProductParagraph\"");

WriteLiteral(">There are no products in the database yet...</p>\r\n                <p>\r\n");

WriteLiteral("                    ");

            
            #line 15 "..\..\Views\Product\List.cshtml"
               Write(Html.ActionLink("Create New Product", "Create"));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </p>\r\n            </div>\r\n    </fieldset>\r\n");

            
            #line 19 "..\..\Views\Product\List.cshtml"
}
else
{

            
            #line default
            #line hidden
WriteLiteral("    <fieldset");

WriteLiteral(" style=\"margin-top: 50px;\"");

WriteLiteral(">\r\n        <legend");

WriteLiteral(" style=\"border-bottom: 0 none;\"");

WriteLiteral(">Products inventory</legend>\r\n        <table");

WriteLiteral(" class=\"table table-hover table-responsive table-condensed\"");

WriteLiteral(">\r\n            <tr>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 27 "..\..\Views\Product\List.cshtml"
               Write(Html.DisplayNameFor(model => model.ProductId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 30 "..\..\Views\Product\List.cshtml"
               Write(Html.DisplayNameFor(model => model.ProductName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 33 "..\..\Views\Product\List.cshtml"
               Write(Html.DisplayNameFor(model => model.ProductDescription));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th>\r\n");

WriteLiteral("                    ");

            
            #line 36 "..\..\Views\Product\List.cshtml"
               Write(Html.DisplayNameFor(model => model.ProductPrice));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n\r\n");

            
            #line 41 "..\..\Views\Product\List.cshtml"
            
            
            #line default
            #line hidden
            
            #line 41 "..\..\Views\Product\List.cshtml"
             foreach (var item in Model)
            {

            
            #line default
            #line hidden
WriteLiteral("                <tr>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 45 "..\..\Views\Product\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ProductId));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 48 "..\..\Views\Product\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ProductName));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 51 "..\..\Views\Product\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ProductDescription));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 54 "..\..\Views\Product\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ProductPrice));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");

WriteLiteral("                        ");

            
            #line 57 "..\..\Views\Product\List.cshtml"
                   Write(Html.ActionLink("Edit", "Edit", new { id = item.ProductId }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                        ");

            
            #line 58 "..\..\Views\Product\List.cshtml"
                   Write(Html.ActionLink("Details", "Details", new { id = item.ProductId }));

            
            #line default
            #line hidden
WriteLiteral(" |\r\n");

WriteLiteral("                        ");

            
            #line 59 "..\..\Views\Product\List.cshtml"
                   Write(Html.ActionLink("Delete", "Delete", new { id = item.ProductId }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");

            
            #line 62 "..\..\Views\Product\List.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </table>\r\n    </fieldset>\r\n");

            
            #line 65 "..\..\Views\Product\List.cshtml"


            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\Product\List.cshtml"
Write(Html.ActionLink("Create New Product", "Create", null, new { @class= "btn btn-primary" }));

            
            #line default
            #line hidden
            
            #line 66 "..\..\Views\Product\List.cshtml"
                                                                                         
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591
