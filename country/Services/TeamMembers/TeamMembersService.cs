using country.Models;
using country.Data;
using country.Models.TeamMembers;

namespace country.Services.TeamMembers;

public class TeamMembersService(): ITeamMembers
{
    public TeamMembersResponse GetTeamMembers()
    {
        var members = TeamMembersData.teamMemberList;
        return new TeamMembersResponse()
        {
            TeamMembers = members
        };
    }
}