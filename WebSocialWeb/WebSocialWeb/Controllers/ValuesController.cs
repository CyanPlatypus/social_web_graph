using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebSocialWeb.Models;
using WebSocialWeb.Models.Contexts;

namespace WebSocialWeb.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public User Get(int id)
        {
            var db = new SocialContext();

            //var user = new User() { Name = "bob" };
            //var user2 = new User() { Name = "alice" };
            //db.Users.Add(user);
            //db.Users.Add(user2);
            //db.SaveChanges();

            //db.Friendships.Add(new Friendship() { User = user, Friend = user2 });
            //db.Friendships.Add(new Friendship() { User = user2, Friend = user });

            //var hobby1 = new Hobby() {Name = "juggling"};
            //var hobby0 = new Hobby() { Name = "coding" };
            //db.Hobbies.Add(hobby0);
            //db.Hobbies.Add(hobby1);
            //db.SaveChanges();
            
            //var city0 = new Area() { Name = "California" };
            //db.Areas.Add(city0);
            //db.SaveChanges();

            //var gender0 = new Gender() { Name = "male" };
            //db.Genders.Add(gender0);
            //db.SaveChanges();

            //var bob = db.Users.FirstOrDefault();
            //bob.Hobbies.Add(hobby0);
            //bob.Hobbies.Add(hobby1);
            //bob.PlaceOfBirth = city0;
            //bob.Residence = city0;
            //bob.Gender = gender0;
            //db.SaveChanges();

            return db.Users.FirstOrDefault();
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
