using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Data.Dtos;

namespace SocialClient.Services
{
    //todo make not static
    public class UserService
    {
        private const string domain = @"http://localhost:55050/api/users";

        //todo: should it be static or using will do better?
        //private static readonly HttpClient client = new HttpClient();

        public static async Task<UserDto> GetUserAsync(int id)
        {
            UserDto user = null;
            
            using( var client = new HttpClient())
            using (var response = await client.GetAsync($"{domain}/{id}").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                    user = await response.Content.ReadAsAsync<UserDto>();
                return user;
            }
        }

        public static async Task<List<UserNodeDto>> GetUsersAsync()
        {
            List<UserNodeDto> users = null;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(domain).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                    users = await response.Content.ReadAsAsync<List<UserNodeDto>>();
                return users;
            }
        }
    }
}