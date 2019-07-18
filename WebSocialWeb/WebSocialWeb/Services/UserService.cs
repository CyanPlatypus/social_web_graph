using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using Dtos;
using WebSocialWeb.CustomExceptions;
using WebSocialWeb.Repositories;

namespace WebSocialWeb.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDto Get(int id)
        {
            var user = _userRepository.Get(id);
            if (user != null)
                return _mapper.Map<UserDto>(user);
            throw new UserNotFoundException();
        }

        public ICollection<UserNodeDto> GetAll()
        {
            return _mapper.Map<ICollection<UserNodeDto>>(_userRepository.GetAll());
        }
    }
}