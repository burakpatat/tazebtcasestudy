
namespace Shared
{
    public class FormFieldValues : EntityBase<int>
    {
        public int FormFieldId { get; set; }
        public FormFields FormField { get; set; }
        public string Value { get; set; }
    }
}
