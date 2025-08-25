using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    //ICommandHandler which does not have  response return
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
    {

    }
    //ICommandHandler with response return.Response should not be null
    public interface ICommandHandler<in TCommand, TResponse>
        :IRequestHandler<TCommand, TResponse>
        where TCommand:ICommand<TResponse>
        where TResponse :notnull
    {
    }
}
