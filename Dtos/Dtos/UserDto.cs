using System;
using System.Collections.Generic;

namespace Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        
        public string Gender { get; set; }
        
        public string PlaceOfBirth { get; set; }
        
        public string Residence { get; set; }

        public ICollection<string> Hobbies { get; set; } = new List<string>();

        public ICollection<UserInfoDto> Friends { get; set; } = new List<UserInfoDto>();
    }
}