using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Dtos;
using SocialClient.Annotations;

namespace SocialClient.ViewModels
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private UserDto currentUser;
        private int index;

        public UserDto CurrentUser
        {
            get => currentUser;
            private set
            {
                currentUser = value;
                OnPropertyChanged();
            }
        }

        public UserViewModel()
        {
            index = 0;
            ChangeUser();
        }

        public void ChangeUser()
        {
            var names = new string[] {"Sean", "Baltimor", "Melissa"};
            index = ++index % 3;
            CurrentUser = new UserDto
            {
                Id = 1,
                Name = names[index],
                Surname = "Digger",
                Patronymic = "Semyonovich",
                Phone = "88005353535",
                DateOfBirth = DateTime.Now,
                Gender = "male",
                PlaceOfBirth = "Moscow",
                Residence = "Milan",
                Hobbies = new List<string>(){"golf", "knotting"},
                Friends = new List<UserInfoDto>() { new UserInfoDto
                    {
                        Id = 2,
                        Name = "Helen",
                        Surname = "Selezneva",
                        Patronymic = "Grigorievna"
                    },
                    new UserInfoDto
                    {
                        Id = 2,
                        Name = "Anna",
                        Surname = "Selezneva",
                        Patronymic = "Grigorievna"
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}