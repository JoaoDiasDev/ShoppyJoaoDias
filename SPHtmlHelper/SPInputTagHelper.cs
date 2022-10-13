using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace SPHtmlHelper
{
    [HtmlTargetElement("spinput")]
    public class SPInputTagHelper : TagHelper
    {
        [HtmlAttributeName("asp-for")]
        public ModelExpression aspFor { get; set; }
        [HtmlAttributeName("type")]
        public string type { get; set; }
        [HtmlAttributeName("addclass")]
        public string addclass { get; set; }
        [HtmlAttributeName("asp-value")]
        public string aspValue { get; set; }
        [HtmlAttributeName("firstclass")]
        public string firstclass { get; set; } = "col-sm-3 control-label";
        [HtmlAttributeName("secondclass")]
        public string secondclass { get; set; } = "col-sm-6";
        [HtmlAttributeName("icon")]
        public string icon { get; set; }
        [HtmlAttributeName("v-model")]
        public string vModel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagOnly;
            aspValue = aspValue == null && aspFor.Model != null ? aspFor.Model.ToString() : aspValue;
            TagBuilder tagInput = new TagBuilder("input");
            tagInput.Attributes.Add("id", aspFor.Name.Replace(".", "_"));
            tagInput.Attributes.Add("name", aspFor.Name);
            tagInput.Attributes.Add("type", type);
            tagInput.Attributes.Add("value", aspValue);

            if (vModel != null)
            {
                tagInput.Attributes.Add("v-model", vModel);
            }

            if (type == "hidden")
            {
                tagInput.AddCssClass(addclass == null ? "" : addclass);
                output.TagName = "";
                output.PostElement.AppendHtml(tagInput);
            }
            else
            {
                if (type == null)
                {
                    type = aspFor.Metadata.DataTypeName != null ? aspFor.Metadata.DataTypeName : "text";
                }

                tagInput.AddCssClass(addclass == null ? "form-control" : "form-control " + addclass);
                tagInput.Attributes.Add("placeholder", aspFor.Metadata.DisplayName);
                tagInput.TagRenderMode = TagRenderMode.SelfClosing;

                if (aspFor.Metadata.IsRequired)
                {
                    tagInput.Attributes.Add("required", "required");
                    tagInput.Attributes.Add("data-val", aspFor.Metadata.ShowForDisplay.ToString().ToLower());
                    var validatorMetadata = aspFor.Metadata.ValidatorMetadata;
                    if (validatorMetadata != null && validatorMetadata.Count > 0)
                    {
                        var metadata = aspFor.Metadata;
                        var prop = metadata.ContainerType.GetProperty(metadata.PropertyName);
                        var attrs = prop.GetCustomAttributes(false);
                        var required = attrs.OfType<RequiredAttribute>().FirstOrDefault();

                        if (required != null)
                        {
                            tagInput.Attributes.Add("data-val-required", required.ErrorMessage);
                        }

                        var minLength = attrs.OfType<MinLengthAttribute>().FirstOrDefault();
                        if (minLength != null)
                        {
                            tagInput.Attributes.Add("data-val-minlength-min", minLength.Length.ToString());
                            tagInput.Attributes.Add("data-val-minlength", minLength.ErrorMessage);
                        }

                        var maxLength = attrs.OfType<MaxLengthAttribute>().FirstOrDefault();
                        if (maxLength != null)
                        {
                            tagInput.Attributes.Add("data-val-maxlength-max", maxLength.Length.ToString());
                            tagInput.Attributes.Add("data-val-maxlength", maxLength.ErrorMessage);
                        }

                        var dataType = attrs.OfType<DataTypeAttribute>().FirstOrDefault();

                        if (dataType != null && type == null)
                        {
                            tagInput.Attributes.Add("type", dataType.DataType.ToString());
                        }
                    }
                    else
                    {
                        tagInput.Attributes.Add("data-val-required", aspFor.Metadata.DisplayName + "is required");
                    }
                }

                var tagSpan = new TagBuilder("span");
                tagSpan.Attributes.Add("class", "text-danger filed-validation-valid");
                tagSpan.Attributes.Add("data-valmsg-for", aspFor.Name);
                tagSpan.Attributes.Add("data-valmsg-replace", "true");

                var iconStr = "";
                if (icon != null)
                {
                    iconStr = $"<div class='input-group-addon'><i class='ti-{icon}'></i></div>";
                }

                output.PreElement.AppendHtml(@$"<div class='form-group row'>
                <label for='{aspFor.Name.Replace(".", "_")}' class='{firstclass}'>{aspFor.Metadata.DisplayName}</label>
                <div class='{secondclass}'>
                <div class='input-group'>
                {iconStr}");

                output.TagName = "";
                output.PostContent.AppendHtml(tagInput);
                output.PostContent.AppendHtml(tagSpan);
                output.PostContent.AppendHtml(@"</div></div></div>");
            }

            base.Process(context, output);
        }
    }
}
