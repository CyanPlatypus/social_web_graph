using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace WebSocialWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int? GenderId { get; set; }
        public Gender Gender { get; set; }

        public int? PlaceOfBirthId { get; set; }
        public Area PlaceOfBirth { get; set; }

        public int? ResidenceId { get; set; }
        public Area Residence { get; set; }

        public ICollection<Hobby> Hobbies { get; set; } = new List<Hobby>();

        //[ForeignKey("FriendId")]
        public ICollection<Friendship> Friends { get; set; } = new List<Friendship>();
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Friendship
    {
        public int Id { get; set; }

        //[Key, Column(Order = 0)]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }

        //[Key, Column(Order = 1)]
        public int FriendId { get; set; }
        [JsonIgnore]
        public User Friend { get; set; }
    }
}