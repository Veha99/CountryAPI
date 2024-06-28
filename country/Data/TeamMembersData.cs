using country.Models.TeamMembers;

namespace country.Data;

public static class TeamMembersData
{
    public static List<TeamMembersInfo> teamMemberList = new List<TeamMembersInfo>
    {
        new TeamMembersInfo
        {
            Name = "Veha",
            Address = "Phnom penh",
            Age = 24,
            Email = "veha123@gmail.com",
            Gender = "male",
        },
        new TeamMembersInfo
        {
            Name = "Leo",
            Address = "Taiwan",
            Age = 30,
            Email = "leo0000@gmail.com",
            Gender = "male",
        },
    };
}