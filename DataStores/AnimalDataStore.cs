using tutorial04.Models;

namespace tutorial04.DataStores;

public class AnimalsDataStore
{
    public List<Animal> Animals { get; set; }

    public static AnimalsDataStore Current { get; } = new AnimalsDataStore();

    public AnimalsDataStore()
    {
        Animals = new List<Animal>()
        {
            new Animal
            {
                Id = 1,
                Name = "jiki",
                Category = "Dog",
                Color = "black",
                Weight = 14,
            },
            new Animal
            {
                Id = 2,
                Name = "mimo",
                Category = "Cat",
                Color = "white",
                Weight = 9,
            },
            new Animal
            {
                Id = 3,
                Name = "lick",
                Category = "Sheep",
                Color = "bleu",
                Weight = 8,
            },
        };
    }
}