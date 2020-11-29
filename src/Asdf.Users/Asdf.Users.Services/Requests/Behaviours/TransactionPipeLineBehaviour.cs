using System;
using System.Threading;
using System.Threading.Tasks;
using Asdf.Users.Services.Contexts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Asdf.UserDomain.Services.Requests.Behaviours
{
    public class TransactionPipeLineBehaviour<TDto, TResult> 
        : IPipelineBehavior<TDto, TResult>
    {
        private readonly IDataAccelerator _dataAccelerator; 
        private readonly ILogger<TransactionPipeLineBehaviour<TDto, TResult>> _logger;
        public TransactionPipeLineBehaviour(
            IDataAccelerator dataAccelerator,
            ILogger<TransactionPipeLineBehaviour<TDto, TResult>> logger)
        {
            this._dataAccelerator = dataAccelerator;
            this._logger = logger;
        }

        public async Task<TResult> Handle(
            TDto request, 
            CancellationToken cancellationToken, 
            RequestHandlerDelegate<TResult> next)
        {
            await using var transaction = this._dataAccelerator.BeginTransaction();
            try
            {
                var result = await next();
                if(result.Equals(false))
                    throw new Exception();
                await this._dataAccelerator.SaveChangesAsync();
                await transaction.CommitAsync(cancellationToken);
                return result;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                this._logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}