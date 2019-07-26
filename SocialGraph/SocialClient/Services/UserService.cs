using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dtos;

namespace SocialClient.Services
{
    //todo make not static
    public class UserService
    {
        private const string domain = @"http://localhost:55050/api/users";

        //todo: should it be static or using will do better?
        private static readonly HttpClient _client = new HttpClient();

        public static async Task<UserDto> GetUserAsync(int id)
        {
            UserDto user = null;
            
            using (var response = await _client.GetAsync($"{domain}/{id}").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                    user = await response.Content.ReadAsAsync<UserDto>();
                return user;
            }
        }

        public static async Task<List<UserNodeDto>> GetUsersAsync()
        {
            List<UserNodeDto> users = null;

            using (var responce = await _client.GetAsync(domain).ConfigureAwait(false))
            {
                if (responce.IsSuccessStatusCode)
                    users = await responce.Content.ReadAsAsync<List<UserNodeDto>>();
                return users;
            }
        }
    }
}