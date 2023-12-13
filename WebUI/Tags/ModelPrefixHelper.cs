namespace Northwind.WebUI.Tags;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement(Attributes = "asp-model-prefix", TagStructure = TagStructure.WithoutEndTag)]
public class ModelPrefixTagHelper : TagHelper
{
  public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
  {
    if (output.Attributes.TryGetAttribute("name", out var attribute))
    {
      output.Attributes.SetAttribute("name", $"Model.{attribute.Value}");
    }
    
    return base.ProcessAsync(context, output);

  }

}
