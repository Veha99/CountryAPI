using country.Models.TeamMembers;
using country.Services.TeamMembers;
using Microsoft.AspNetCore.Mvc;

namespace country.Controllers;
[ApiController]
[Route("/api/[controller]")]

public class TeamMemebersController(ITeamMembers teamMembers) : ControllerBase
{
    [HttpGet("/get-members")]
    public ActionResult<TeamMembersResponse> GetTeamMembers()
    {
        return teamMembers.GetTeamMembers();
    }
}