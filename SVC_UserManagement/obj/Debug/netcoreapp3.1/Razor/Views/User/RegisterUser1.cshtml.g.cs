#pragma checksum "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b0b3ec1541bbf5dda3425223394da335a7ff36e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_RegisterUser1), @"mvc.1.0.view", @"/Views/User/RegisterUser1.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b0b3ec1541bbf5dda3425223394da335a7ff36e", @"/Views/User/RegisterUser1.cshtml")]
    public class Views_User_RegisterUser1 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NotificationManagementDBEntity.Models.UserDetails>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
  
    ViewData["Title"] = "RegisterUser1";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>RegisterUser1</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayNameFor(model => model.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 49 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserPassword));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.EmailAddr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 70 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 73 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 76 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdatedDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 79 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.DisplayFor(modelItem => item.UserAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 82 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 83 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                ");
#nullable restore
#line 84 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 87 "E:\NotificationManagement\4BA-NotificationManagement\SVC_UserManagement\Views\User\RegisterUser1.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NotificationManagementDBEntity.Models.UserDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
