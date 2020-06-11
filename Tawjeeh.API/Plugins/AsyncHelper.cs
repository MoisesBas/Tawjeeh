using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;

namespace Tawjeeh.Api.Plugins
{


    public static class AsyncHelper
    {
        public static async Task<bool> CheckTasksForTimeoutTask<T>(
            List<Task<T>> taskList,
            Task timeoutTask,
            CancellationTokenSource timeoutTaskCancellationTokenSource,
            Action<T> completedTaskCallback)
        {
            var hasTimedOut = false;

            foreach (var task in taskList)
            {
                var hasThisTaskTimedOut = false;

                await Task.WhenAny(task, timeoutTask).ConfigureAwait(false);

                if (!task.IsCompleted && timeoutTask.IsCompleted)
                {
                    // the timeout task has completed before the other task
                    hasThisTaskTimedOut = true;
                }

                if (!hasThisTaskTimedOut)
                {
                    var data = await task.ConfigureAwait(false);
                    if (completedTaskCallback != null)
                    {
                        completedTaskCallback(data);
                    }
                }
                else
                {
                    hasTimedOut = true;
                }
            }

            if (!hasTimedOut)
            {
                // Cancel the timeout task as everything is complete
                timeoutTaskCancellationTokenSource.Cancel();
            }

            return hasTimedOut;
        }
    }


}