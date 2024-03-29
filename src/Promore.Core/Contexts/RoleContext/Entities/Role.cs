using System.Text.Json.Serialization;
using Promore.Core.Contexts.UserContext.Entities;

namespace Promore.Core.Contexts.RoleContext.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public List<User> Users { get; set; }
}