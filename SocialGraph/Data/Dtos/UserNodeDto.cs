using System.Collections.Generic;

namespace Data.Dtos
{
    public class UserNodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public ICollection<int> Friends { get; set; } = new List<int>();
    }
}
