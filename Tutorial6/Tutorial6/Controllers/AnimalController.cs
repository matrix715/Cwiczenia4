using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    private static List<Animal> _animals = Database.Animals;

    [HttpGet]
    public IActionResult GetAllAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        return animal == null ? NotFound($"Animal with ID {id} not found.") : Ok(animal);
    }

    [HttpGet("search")]
    public IActionResult GetAnimalByName([FromQuery] string name)
    {
        var animal = _animals.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        return animal == null ? NotFound($"Animal with name '{name}' not found.") : Ok(animal);
    }

    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        if (animal == null)
            return BadRequest("Animal data is required.");

        animal.AssignId(); // Assign ID if not set
        _animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
    {
        var existingAnimal = _animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
            return NotFound($"Animal with ID {id} not found.");

        existingAnimal.Name = updatedAnimal.Name;
        existingAnimal.Category = updatedAnimal.Category;
        existingAnimal.Weight = updatedAnimal.Weight;
        existingAnimal.HairColor = updatedAnimal.HairColor;

        return Ok(existingAnimal);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound($"Animal with ID {id} not found.");

        _animals.Remove(animal);
        return NoContent();
    }
}
