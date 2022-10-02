using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SPHtmlHelper
{
    [HtmlTargetElement("spupload")]
    public class SPSingleFileUploadTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression aspFor { get; set; } = null;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreElement.AppendHtml(@"<div class='col-12'>
                                          <div class='form-group row'>
                                          <div class='col-md-3'>
                                          <label class='control-label font-weight-bold pt-1'>Upload Image</label>
                                          </div>
                                          <div class='col-md-9'>
                                          <div class='dropzone dz-drag-hover dropzone-area mb-2' id='dpz-single-file'>
                                          <div class='dz-message'>Drop files here to upload
                                          </div>
                                          </div>
                                          </div>
                                          </div>
                                          </div>");
            output.TagName = "";

            base.Process(context, output);
        }
    }
}
