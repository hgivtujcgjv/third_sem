using System.Net.NetworkInformation;

class Program
{
    static void Main(string[] args)
    {
        Cow cow1 = new Cow(eFavoriteFood.Plants, eClassificationAnimal.Herbivores, "USA", "Grass", "Bessie", "Cow");
        Cow cow2 = new Cow(eFavoriteFood.Plants, eClassificationAnimal.Herbivores, "Canada", "Barn", "Moo", "Cow");

        Lion lion1 = new Lion(eFavoriteFood.Meat, eClassificationAnimal.Carnivores, "Africa", "Savannah", "Simba", "Lion");
        Lion lion2 = new Lion(eFavoriteFood.Meat, eClassificationAnimal.Carnivores, "India", "Jungle", "Rajah", "Lion");

        Pig pig1 = new Pig(eFavoriteFood.Plants, eClassificationAnimal.Omnivores, "Germany", "Sty", "Wilbur", "Pig");
        Pig pig2 = new Pig(eFavoriteFood.Everything, eClassificationAnimal.Omnivores, "Brazil", "Farm", "Porky", "Pig");

        cow1.SayHello();
        Console.WriteLine($"Classification: {cow1.GetClassificationAnimal()}");
        Console.WriteLine($"Favorite Food: {cow1.GetFavoriteFood()}");
        Console.WriteLine($"Country: {cow1.Country}");
        Console.WriteLine();

        lion2.SayHello();
        Console.WriteLine($"Classification: {lion2.GetClassificationAnimal()}");
        Console.WriteLine($"Favorite Food: {lion2.GetFavoriteFood()}");
        Console.WriteLine($"Country: {lion2.Country}");
        Console.WriteLine();

        pig1.SayHello();
        Console.WriteLine($"Classification: {pig1.GetClassificationAnimal()}");
        Console.WriteLine($"Favorite Food: {pig1.GetFavoriteFood()}");
        Console.WriteLine($"Country: {pig1.Country}");
    }
}
