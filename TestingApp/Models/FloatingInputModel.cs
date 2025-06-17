using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TestingApp.Models
{
    public class FloatingInputModel
    {
        public ModelExpression For { get; set; }
        public string Type { get; set; } = "text";
    }
}
