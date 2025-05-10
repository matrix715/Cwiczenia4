namespace Tutorial6.Models;

public class Animal
{
    private static int _id = 0;

    public int Id { get; private set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string HairColor { get; set; }

    public Animal() { }

    public Animal(string name, string category, double weight, string hairColor)
    {
        AssignId();
        Name = name;
        Category = category;
        Weight = weight;
        HairColor = hairColor;
    }

    public void AssignId()
    {
        Id = ++_id;
    }
}
