using MediatR;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Mediate23rR
{
    public class HandleLogger<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;
            string unqiueId = Guid.NewGuid().ToString();

            Console.WriteLine(requestName + " " + DateTime.Now);

            var response = await next();

            return response;
        }
        //builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(HandleLogger<,>));
    }

}