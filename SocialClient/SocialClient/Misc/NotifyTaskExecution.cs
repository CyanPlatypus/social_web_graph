using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SocialClient.Annotations;

namespace SocialClient.Misc
{
    public class NotifyTaskExecution<T> : INotifyPropertyChanged
    {
        private Task<T> _task;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public bool IsRunning => !_task?.IsCompleted ?? false;
        public bool IsCompletedSuccessfully => _task?.Status == TaskStatus.RanToCompletion;
        public bool IsFailed => _task?.IsFaulted ?? false;
        public T Result => _task?.Status == TaskStatus.RanToCompletion? _task.Result : default(T);

        public NotifyTaskExecution(Task<T> task)
        {
            SetTask(task);
        }

        public void SetTask(Task<T> task)
        {
            _task = task;
            if (!_task.IsCompleted)
            {
                var _ = ExecuteTaskAsync();
            }
        }

        private async Task ExecuteTaskAsync()
        {
            try
            {
                OnPropertyChanged(nameof(IsRunning));
                await _task;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            OnPropertyChanged(nameof(IsRunning));
            OnPropertyChanged(nameof(Result));
            OnPropertyChanged(nameof(IsCompletedSuccessfully));
            OnPropertyChanged(nameof(IsFailed));

        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}