using MediatR;

namespace Shared.Application.Mediator.Commands
{
    public class RemoveFormCommand : IRequest
    {
        public RemoveFormCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
