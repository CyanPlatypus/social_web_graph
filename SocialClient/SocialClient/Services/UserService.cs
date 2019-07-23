using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Dtos;

namespace SocialClient.Services
{
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
    }
}