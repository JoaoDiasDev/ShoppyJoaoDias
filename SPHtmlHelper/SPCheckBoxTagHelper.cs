using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace SPHtmlHelper
{
    [HtmlTargetElement("spcheckbox")]
    public class SPCheckBoxTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression aspFor { get; set; }
        [HtmlAttributeName("asp-items")]
        public IEnumerable<SelectListItem> listItems { get; set; }
        [HtmlAttributeName("value")]
        public string value { get; set; }
        [HtmlAttributeName("v-model")]
        public string vModel { get; set; }
        [HtmlAttributeName("addclass")]
        public string addclass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.SuppressOutput();
            var name = aspFor.Name;
            var id = aspFor.Name.Replace(".", "_");
            string errorMessage = IsRequired(aspFor);
            string listStr = "";
            int index = 0;
            value = value == null && aspFor.Model != null ? aspFor.Model.ToString() : value;
            foreach (var item in listItems)
            {
                var thisId = index == 0 ? id : id + item.Value;
                var selected = item.Selected || item.Value == value ? "checked" : "";

                listStr += $@"<div class='checkbox checkbox-success'>
                              <input id ='{thisId}' type='checkbox' {errorMessage} name='{name}' {selected} value ='{item.Value}'>
                              <label for='{thisId}'>{item.Text}</label>
                              </div>";

                index++;
            }

            addclass = addclass == null ? "list-unstyled mb-0" : addclass;
            var template = $@"<div class='form-group row'>
                              <div class='control-label col-md-3'>
                              {aspFor.Metadata.DisplayName}
                              </div>
                              <div class='col-md-9'>
                              {listStr}
                              </div>
                              </div>";
            output.TagName = "";
            output.Content.SetHtmlContent(template);

            base.Process(context, output);
        }

        private string IsRequired(ModelExpression aspFor)
        {
            if (aspFor.Metadata.IsRequired)
            {
                var validatorMetadata = aspFor.ModelExplorer.Metadata.ValidatorMetadata;
                if (validatorMetadata != null && validatorMetadata.Count > 0)
                {
                    string requiredErrorMessage = "";
                    foreach (var item in validatorMetadata)
                    {
                        RequiredAttribute m = (RequiredAttribute)item;
                        requiredErrorMessage = m.ErrorMessage;
                    }
                    return "data-val=\"true\" data-val-required=\"" + requiredErrorMessage + "\"";
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
