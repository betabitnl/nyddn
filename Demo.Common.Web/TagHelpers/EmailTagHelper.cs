using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Demo.Common.Web.TagHelpers
{
    // TagHelpers are bound to elements on the name. This helper binds to the email tag. The suffix
    // TagHelper is not mandatory, but it does make things clear to add it.
    public class EmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var cntnt = await output.GetChildContentAsync();
            output.Attributes.SetAttribute("href", $"mailto:{cntnt.GetContent()}@betabit.nl");
        }
    }
}