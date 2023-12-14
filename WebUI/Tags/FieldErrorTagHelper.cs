namespace Northwind.WebUI.Tags;

using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("error", TagStructure = TagStructure.NormalOrSelfClosing)]
public class FieldErrorTagHelper : TagHelper
{
  [HtmlAttributeName("asp-for")]
  public ModelExpression For { get; set; }
    
  // public IEnumerable<ValidationFailure> Errors { get; set; }
  
  [ViewContext]
  [HtmlAttributeNotBound]
  public ViewContext ViewContext { get; set; }
    
  public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
  {
    // var model = this.For.ModelExplorer.Model;
    // var type = model?.GetType();
    var modelState = ViewContext?.ViewData?.ModelState;
    var message = modelState?[For.Name]?.Errors[0].ErrorMessage;
    // output.Content.SetHtmlContent(DateTime.Now.ToLongTimeString());
    // return base.ProcessAsync(context, output);
    // Fixed in 0.5.3. Render your form error response with unprocessable entity (422) and Turbo will display it. 
    return Task.CompletedTask;
  }

}
