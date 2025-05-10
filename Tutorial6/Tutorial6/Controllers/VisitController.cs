using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers;

[ApiController]
[Route("api/animals/{animalId:int}/visits")]
public class VisitController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Visit>> GetVisits(int animalId)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
            return NotFound($"Animal with ID {animalId} not found.");

        var visits = Database.Visits
            .Where(v => v.AnimalId == animalId)
            .ToList();

        return Ok(visits);
    }

    [HttpPost]
    public ActionResult<Visit> CreateVisit(int animalId, [FromBody] Visit newVisit)
    {
        if (!Database.Animals.Any(a => a.Id == animalId))
            return NotFound($"Animal with ID {animalId} not found.");

        newVisit.AssignId();
        newVisit.AnimalId = animalId;
        Database.Visits.Add(newVisit);

        return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, newVisit);
    }
}
