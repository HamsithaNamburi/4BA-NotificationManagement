#pragma checksum "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cbbc160a6803ed03d6f72269a560d238b70b7619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Notification_GetAllNotifications), @"mvc.1.0.view", @"/Views/Notification/GetAllNotifications.cshtml")]
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
#line 1 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\_ViewImports.cshtml"
using UserManagementUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\_ViewImports.cshtml"
using UserManagementUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cbbc160a6803ed03d6f72269a560d238b70b7619", @"/Views/Notification/GetAllNotifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adc03c1e9f17270f7590ee6f1c011b1e8611a2d6", @"/Views/_ViewImports.cshtml")]
    public class Views_Notification_GetAllNotifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NotificationManagementUI.Models.Notifications>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserLogin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddNotification", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
  
    ViewData["Title"] = "GetAllNotifications";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>GetAllNotifications</h1>\r\n<ul class=\"navbar-nav flew-grow-0\" style=\"margin-left:800px\">\r\n    <li class=\"nav-item navbar-right\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbbc160a6803ed03d6f72269a560d238b70b76195314", async() => {
                WriteLiteral("Logout");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </li>\r\n</ul>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cbbc160a6803ed03d6f72269a560d238b70b76196995", async() => {
                WriteLiteral("Add New Notification");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("&nbsp;&nbsp;\r\n");
            WriteLiteral("</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
           Write(Html.DisplayNameFor(model => model.NotificationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
           Write(Html.DisplayNameFor(model => model.NotificationName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 34 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
               Write(Html.DisplayFor(modelItem => item.NotificationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
               Write(Html.DisplayFor(modelItem => item.NotificationName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 44 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 47 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
               Write(Html.ActionLink("Edit", "UpdateNotification", new { id = item.NotificationId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                   \r\n                    ");
#nullable restore
#line 49 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
               Write(Html.ActionLink("Delete", "DeleteNotification", new { id = item.NotificationId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 52 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"


          
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <tr>\r\n            ");
#nullable restore
#line 58 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
       Write(Html.ActionLink("View Profile", "GetUser", "User", new { id = TempData["id"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            ");
#nullable restore
#line 59 "D:\UpdatedCodeWithGlobalerrors\4BA-NotificationManagement\Web_UserManagement\Views\Notification\GetAllNotifications.cshtml"
       Write(Html.ActionLink("Edit Profile", "UpdateUser", "User", new { id = TempData["id"] }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n        </tr>\r\n    </tbody>\r\n    </table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NotificationManagementUI.Models.Notifications>> Html { get; private set; }
    }
}
#pragma warning restore 1591
