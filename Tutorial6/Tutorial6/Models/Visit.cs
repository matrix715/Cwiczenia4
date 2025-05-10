namespace Tutorial6.Models;

public class Visit
{
    private static int _visitId = 0;

    public int Id { get; private set; }
    public DateTime DateTime { get; set; }
    public int AnimalId { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }

    public Visit() { }

    public Visit(DateTime dateTime, int animalId, string description, double cost)
    {
        AssignId();
        DateTime = dateTime;
        AnimalId = animalId;
        Description = description;
        Cost = cost;
    }

    public void AssignId()
    {
        Id = ++_visitId;
    }
}
