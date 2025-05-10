using Tutorial6.Models;

namespace Tutorial6;

public class Database
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal("George", "Monkey", 4, "Black"),
        new Animal("Louis",  "Dog", 2, "Brown"),
        new Animal("Angel", "Horse", 30,  "White"),
        new Animal("Ratatouille", "Rat", 1, "Grey")
    };

    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit(DateTime.Today, 1, "Hairdresser", 200),
        new Visit(DateTime.Today, 3, "Washing", 90),
        new Visit(DateTime.Today, 2, "Deietetician", 100),
        new Visit(DateTime.Today, 4, "Rehabilitation", 420),
    };
}