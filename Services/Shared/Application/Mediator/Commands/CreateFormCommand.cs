using MediatR;

namespace Shared.Application.Mediator.Commands
{
    public class CreateFormCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public List<FormFields> FormFields { get; set; } = new List<FormFields>();
    }
}
