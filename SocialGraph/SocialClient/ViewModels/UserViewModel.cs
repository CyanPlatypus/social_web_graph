using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Data.Dtos;
using SocialClient.Annotations;
using SocialClient.Commands;
using SocialClient.Misc;
using SocialClient.Services;

namespace SocialClient.ViewModels
{
    public class UserViewModel: INotifyPropertyChanged
    {
        public NotifyTaskExecution<UserDto> NotifyTaskExecution { get; protected set; }

        public UserDto CurrentUser => NotifyTaskExecution.Result;

        public RelayCommand ChangeUserCommand { get; set; }

        public UserViewModel(int id)
        {
            NotifyTaskExecution = new NotifyTaskExecution<UserDto>();
            NotifyTaskExecution.PropertyChanged += NotifyTaskExecution_PropertyChanged;
            
            this.ChangeUserCommand = new RelayCommand(o =>
            {
                if(o is UserInfoDto user)
                    GetUser(user.Id);
            });

            GetUser(id);
        }

        private void GetUser(int id)
        {
            NotifyTaskExecution.StartTask(UserService.GetUserAsync(id));
        }

        private void NotifyTaskExecution_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(NotifyTaskExecution.Result))
                OnPropertyChanged(nameof(CurrentUser));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}