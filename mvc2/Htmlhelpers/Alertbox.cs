using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace mvc2.Htmlhelpers
{
    public static class Alertbox
    {
        public static MvcHtmlString Alert(this HtmlHelper html, string message, string cssClass)
        {
            TagBuilder wrapperTag;
            StringBuilder sb = new StringBuilder();
            wrapperTag = new TagBuilder("div");
            wrapperTag.AddCssClass(cssClass);
            wrapperTag.InnerHtml = message;
            sb.Append(wrapperTag.ToString());

            return MvcHtmlString.Create(sb.ToString());
        }
    }
}