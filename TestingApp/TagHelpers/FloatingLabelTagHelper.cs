using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TestingApp.TagHelpers
{
    [HtmlTargetElement("floating-input", Attributes = "asp-for")]
    public class FloatingLabelTagHelper : TagHelper // Fully qualified TagHelper
    {
        private readonly IModelExpressionProvider _modelExpressionProvider;

        public FloatingLabelTagHelper(IModelExpressionProvider modelExpressionProvider)
        {
            _modelExpressionProvider = modelExpressionProvider;
        }

        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
          //  output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "form-floating mb-3");

          var input = new TagBuilder("input");
           // var input = $"<input id='{For.Name}' name='{For.Name}' class='form-control' />";

            input.Attributes.Add("type", "text");
            input.Attributes.Add("id", For.Name);
            input.Attributes.Add("name", For.Name);
            input.AddCssClass("form-control");
            input.Attributes.Add("value", For.Model?.ToString() ?? "");
            input.Attributes.Add("placeholder", For.Metadata.DisplayName ?? For.Name);

        var label = new TagBuilder("label");
           // var label = $"<label for='{For.Name}' class='form-label'>{For.Metadata.DisplayName}</label>";

            label.Attributes.Add("for", For.Name);
            label.InnerHtml.Append(For.Metadata.DisplayName ?? For.Name);
            //output.Content.SetHtmlContent($"{label}{input}");
            output.Content.AppendHtml(input);
            output.Content.AppendHtml(label);
        }
    }
}
