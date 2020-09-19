using System;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Application.Dto
{
    public class AddFriendDto
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }

        public static Friend ToFriend(AddFriendDto addFriendDto)
        {
            return new Friend(addFriendDto.Name, addFriendDto.UserId);
        }
    }
}
