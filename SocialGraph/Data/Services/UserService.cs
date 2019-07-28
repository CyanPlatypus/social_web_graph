using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Data.CustomExceptions;
using Data.Dtos;
using Data.Models;
using Data.Repositories;

namespace Data.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(UserRepository userRepository
            , IMapper mapper
            )
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