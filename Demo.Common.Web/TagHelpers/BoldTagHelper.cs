using Microsoft.AspNetCore.Razor.TagHelpers;

// TagHelper properties can be passed via attributes, PascalCasing is translated 
// into kebab-casing. This means MailTo translates into mail-to.
namespace Demo.Common.Web.TagHelpers
{
    [HtmlTargetElement("bold")]
    [HtmlTargetElement(Attributes = "bold")]
    // Above attributes are combined with an OR, below would be combined with an AND.
    // [HtmlTargetElement("bold", Attributes = "bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.RemoveAll("bold");
            output.PreContent.SetHtmlContent("<strong>");
            output.PostContent.SetHtmlContent("</strong>");
        }
    }
}