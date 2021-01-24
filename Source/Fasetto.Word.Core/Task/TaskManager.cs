
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class TaskManager : ITaskManager
    {
        public async Task Run(Func<Task> function)
        {
            try
            {
                await Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken)
        {
            try
            {
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<Task<TResult>> function)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken)
        {
            try
            {
                return Task.Run(function,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task<TResult> Run<TResult>(Func<TResult> function)
        {
            try
            {
                return Task.Run(function);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task Run(Func<Task> function, CancellationToken cancellationToken)
        {
            try
            {
                return Task.Run(function, cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task Run(Action action, CancellationToken cancellationToken)
        {
            try
            {
                return Task.Run(action,cancellationToken);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public Task Run(Action action)
        {
            try
            {
                return Task.Run(action);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        #region Private Helper Methods

        private void LogError(Exception ex)
        {
            IoC.Logger.Log($"An unexpected error occured running of IoC.Task.Run. {ex}", LogLevel.Debug);
        }

        #endregion
    }
}
