using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.Collection.API.Application.Dto;

namespace WhereIsMyGame.Collection.API.Application.Services
{
    public interface IFriendAppService
    {
        Task<IEnumerable<FriendDto>> GetByUser(Guid userId);
        Task<FriendDto> GetById(Guid id);        
        Task<bool> AddFriend(AddFriendDto addFriendDto);
        Task<bool> EditFriend(EditFriendDto editFriendDto);
        Task<bool> DeleteFriend(Guid id);
    }
}
