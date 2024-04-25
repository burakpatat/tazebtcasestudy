
namespace Shared
{
    public class FormRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int FieldCount { get; set; }
        public List<FormRequestFields> FormFields { get; set; } = new List<FormRequestFields>();
    }
    public class FormRequestFields
    {
        public string FieldName { get; set; }
        public string FieldType { get; set; }
        public bool IsRequired { get; set; }
    }
}
