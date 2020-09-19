using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;
using WhereIsMyGame.Collection.API.Data.Repositories;

namespace WhereIsMyGame.Collection.API.Application.Services
{
    public class FriendAppService : IFriendAppService
    {
        private readonly IFriendRepository _friendRepository;

        public FriendAppService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public async Task<IEnumerable<FriendDto>> GetByUser(Guid userId)
        {
            var friends = await _friendRepository.GetByUser(userId);

            return friends.Select(x => new FriendDto()
            {
                Id = x.Id,
                Name = x.Name               
            });
        }

        public async Task<FriendDto> GetById(Guid id)
        {
            var friend = await _friendRepository.GetById(id);

            if (friend != null)
            {
                return new FriendDto()
                {                    
                    Name = friend.Name,                    
                    //Loans = new LoanDto
                    //{
                    //    Id = game.PlataformId,
                    //    Name = game.Plataform.Name,
                    //    Code = game.Plataform.Code
                    //}
                };
            }

            return null;
        }

        public async Task<bool> AddFriend(AddFriendDto addFriendDto)
        {
            var friend = AddFriendDto.ToFriend(addFriendDto);
            _friendRepository.Add(friend);
            var result = await _friendRepository.UnitOfWork.Commit();

            return result;
        }

        public async Task<bool> EditFriend(EditFriendDto editFriendDto)
        {
            var friend = await _friendRepository.GetById(editFriendDto.Id);

            if (friend != null)
            {
                friend.UpdateDetails(editFriendDto.Name);
                _friendRepository.Update(friend);
                return await _friendRepository.UnitOfWork.Commit();
            }

            return false;
        }

        public async Task<bool> DeleteFriend(Guid id)
        {
            var friend = await _friendRepository.GetById(id);

            if (friend != null)
            {
                _friendRepository.Delete(friend);
                return await _friendRepository.UnitOfWork.Commit();
            }

            return false;
        }
    }
}
