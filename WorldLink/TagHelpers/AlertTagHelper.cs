using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldLink.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {

        public string Message { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "custom-alert");
                output.Attributes.SetAttribute("id", "custom-alert");
                output.Content.AppendHtml("<span>" + Message + "</span><button id=\"alert-button\">Fechar</button>");
            }
        }
    }
}
