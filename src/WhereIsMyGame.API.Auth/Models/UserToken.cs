using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WhereIsMyGame.Auth.API.Models
{
    public class UserToken
    {
        public string Id { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public IEnumerable<UserClaim> Claims { get; set; }
    }

}
