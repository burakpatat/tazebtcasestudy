using MediatR;

namespace Shared.Application.Mediator.Commands
{
    public class UpdateFormCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public List<FormFields> FormFields { get; set; } = new List<FormFields>();
    }
}
