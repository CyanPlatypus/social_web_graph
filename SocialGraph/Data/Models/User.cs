using System;
using System.Collections.Generic;

namespace Data.Models
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
        
        public ICollection<Friendship> Friends { get; set; } = new List<Friendship>();
    }
}