using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SPHtmlHelper
{
    [HtmlTargetElement("spbutton")]
    public class SPButtonTagHelper : TagHelper
    {
        [HtmlAttributeName("addclass")]
        public string addclass { get; set; }
        [HtmlAttributeName("asp-value")]
        public string aspValue { get; set; }
        [HtmlAttributeName("type")]
        public string type { get; set; } = "submit";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;

            var template = ($@"<div class='form-group row m-b-0'>
                               <div class='offset-sm-3 col-sm-9'>
                               <button type='{type}' class='btn btn-info waves-effect waves-light {addclass}'>{aspValue}</button>
                               </div>
                               </div>");
            output.TagName = "";
            output.Content.SetHtmlContent(template);
            base.Process(context, output);
        }
    }
}
