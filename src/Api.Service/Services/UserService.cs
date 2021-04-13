using Api.Domain.Dtos;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _userRepository.SelectByIdAync(id);
            
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _userRepository.SelectAllAync();

            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var model = _mapper.Map<UserModel>(user);
            model.CreateAt = DateTime.UtcNow;
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _userRepository.InsertAsync(entity);

            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var entity = await _userRepository.SelectByIdAync(user.Id);

            entity.Nome = user.Nome;
            entity.Email = user.Email;
            entity.UpdateAt = DateTime.UtcNow;

            var result = await _userRepository.UpdateAync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
