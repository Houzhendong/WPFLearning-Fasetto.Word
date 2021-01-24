
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public interface ITaskManager
    {
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     task returned by function.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously
        //
        // 返回结果:
        //     A task that represents a proxy for the task returned by function.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        Task Run(Func<Task> function);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     Task(TResult) returned by function.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work
        //
        // 类型参数:
        //   TResult:
        //     The type of the result returned by the proxy task.
        //
        // 返回结果:
        //     A Task(TResult) that represents a proxy for the Task(TResult) returned by function.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        Task<TResult> Run<TResult>(Func<Task<TResult>> function, CancellationToken cancellationToken);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     Task(TResult) returned by function.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously
        //
        // 类型参数:
        //   TResult:
        //     The type of the result returned by the proxy task.
        //
        // 返回结果:
        //     A Task(TResult) that represents a proxy for the Task(TResult) returned by function.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        Task<TResult> Run<TResult>(Func<Task<TResult>> function);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a Task(TResult)
        //     object that represents that work. A cancellation token allows the work to be
        //     cancelled.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work
        //
        // 类型参数:
        //   TResult:
        //     The result type of the task.
        //
        // 返回结果:
        //     A Task(TResult) that represents the work queued to execute in the thread pool.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter is null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        Task<TResult> Run<TResult>(Func<TResult> function, CancellationToken cancellationToken);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task`1
        //     object that represents that work.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously.
        //
        // 类型参数:
        //   TResult:
        //     The return type of the task.
        //
        // 返回结果:
        //     A task object that represents the work queued to execute in the thread pool.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter is null.
        Task<TResult> Run<TResult>(Func<TResult> function);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a proxy for the
        //     task returned by function.
        //
        // 参数:
        //   function:
        //     The work to execute asynchronously.
        //
        //   cancellationToken:
        //     A cancellation token that should be used to cancel the work.
        //
        // 返回结果:
        //     A task that represents a proxy for the task returned by function.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The function parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        Task Run(Func<Task> function, CancellationToken cancellationToken);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        //     object that represents that work. A cancellation token allows the work to be
        //     cancelled.
        //
        // 参数:
        //   action:
        //     The work to execute asynchronously
        //
        //   cancellationToken:
        //     A cancellation token that can be used to cancel the work
        //
        // 返回结果:
        //     A task that represents the work queued to execute in the thread pool.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The action parameter was null.
        //
        //   T:System.Threading.Tasks.TaskCanceledException:
        //     The task has been canceled.
        //
        //   T:System.ObjectDisposedException:
        //     The System.Threading.CancellationTokenSource associated with cancellationToken
        //     was disposed.
        Task Run(Action action, CancellationToken cancellationToken);
        //
        // 摘要:
        //     Queues the specified work to run on the thread pool and returns a System.Threading.Tasks.Task
        //     object that represents that work.
        //
        // 参数:
        //   action:
        //     The work to execute asynchronously
        //
        // 返回结果:
        //     A task that represents the work queued to execute in the ThreadPool.
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     The action parameter was null.
        Task Run(Action action);
    }
}
