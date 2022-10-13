using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPHtmlHelper
{
    [HtmlTargetElement("spselect")]
    public class SPSelectTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression aspFor { get; set; }
        [HtmlAttributeName("asp-items")]
        public IEnumerable<SelectListItem> listItems { get; set; }
        [HtmlAttributeName("addclass")]
        public string addclass { get; set; }
        [HtmlAttributeName("asp-text")]
        public string defaultText { get; set; }
        [HtmlAttributeName("asp-value")]
        public string defaultValue { get; set; }
        [HtmlAttributeName("value")]
        public string value { get; set; }
        [HtmlAttributeName("v-model")]
        public string vModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            value = value == null && aspFor.Model != null ? aspFor.Model.ToString() : value;

            var tagSelect = new TagBuilder("select");
            tagSelect.AddCssClass(addclass == null ? "form-control" : "form-control" + addclass);
            tagSelect.Attributes.Add("id", aspFor.Name.Replace(".", "_"));
            tagSelect.Attributes.Add("name", aspFor.Name);
            if (vModel != "" && vModel != null)
            {
                tagSelect.Attributes.Add("v-model", vModel);
            }

            if (aspFor.Metadata.IsRequired)
            {
                tagSelect.Attributes.Add("required", "required");
                tagSelect.Attributes.Add("data-val", aspFor.Metadata.ShowForDisplay.ToString().ToLower());
                var validatorMetadata = aspFor.ModelExplorer.Metadata.ValidatorMetadata;
                if (validatorMetadata != null && validatorMetadata.Count > 0)
                {
                    string requiredErrorMessage = "";
                    foreach (var item in validatorMetadata)
                    {
                        RequiredAttribute m = (RequiredAttribute)item;
                        requiredErrorMessage = m.ErrorMessage;
                    }
                    tagSelect.Attributes.Add("data-val-required", requiredErrorMessage);
                }
                else
                {
                    tagSelect.Attributes.Add("data-val-required", aspFor.Metadata.DisplayName + " is required");
                }
            }

            if (defaultText != null && defaultText != "")
            {
                tagSelect.InnerHtml.AppendHtml("<option value=''" + defaultValue + " >" + defaultText + "</option>");
            }

            if (listItems != null && listItems.ToList().Count > 0)
            {
                var options = new StringBuilder();
                foreach (var item in listItems.ToList())
                {
                    if (value != null && item.Value == value.ToString())
                    {
                        options.Append("<option value='" + item.Value + "' selected='selected'>" + item.Text + "</option>");
                    }
                    else
                    {
                        options.Append("<option value='" + item.Value + "'>" + item.Text + "</option>");
                    }
                }
                tagSelect.InnerHtml.AppendHtml(options.ToString());
            }

            var tagSpan = new TagBuilder("span");
            tagSpan.Attributes.Add("class", "text-danger field-validation-valid");
            tagSpan.Attributes.Add("data-valmsg-for", aspFor.Name);
            tagSpan.Attributes.Add("data-valmsg-replace", "true");

            output.PreElement.AppendHtml(@"<div class='form-group row'>"
                                         + "<div class='col-md-3'>"
                                         + "<label for='" + aspFor.Name.Replace(".", "_") + "' class='control-label font-weight-bold pt-1'>"
                                         + aspFor.Metadata.DisplayName + "</label>"
                                         + "</div>"
                                         + "<div class='col-md-6'>");
            output.PostElement.AppendHtml(tagSelect);
            output.PostElement.AppendHtml(tagSpan);
            output.PostElement.AppendHtml("</div></div>");
            output.TagName = "";
            base.Process(context, output);
        }
    }
}
