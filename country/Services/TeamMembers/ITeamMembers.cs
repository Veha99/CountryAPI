using country.Models;
using country.Models.TeamMembers;

namespace country.Services.TeamMembers;

public interface ITeamMembers
{
    TeamMembersResponse GetTeamMembers();
}