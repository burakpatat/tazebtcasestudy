
namespace Shared
{
    public class FormFieldRequest
    {
        public Guid FormId { get; set; }
        public string? FormName { get; set; }
        
        /// <example>{"name":"string","data":"string"}</example>
        public bool IsCheckboxField { get; set; }
        public Dictionary<string, string> FieldValues { get; set; }
        public Dictionary<string, bool> BoolFieldValues { get; set; }
    }
}
