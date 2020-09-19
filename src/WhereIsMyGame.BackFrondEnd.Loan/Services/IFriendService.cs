using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhereIsMyGame.BackFrondEnd.Loan.Models;
using WhereIsMyGame.Core.Communication;

namespace WhereIsMyGame.BackFrondEnd.Loan.Services
{
    public interface IFriendService
    {
        Task<IEnumerable<FriendDto>> GetByUser();
        Task<GameDto> GetById(Guid id);
        
        Task<ResponseResult> AddFriend(AddFriendDto addFriendDto);
        Task<ResponseResult> EditFriend(EditFriendDto editFriendDto);
        Task<ResponseResult> DeleteFriend(Guid id);
    }
}
