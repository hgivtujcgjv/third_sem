
using System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    class CommentAttribute : Attribute
    {
        public string comment { get; }
        public CommentAttribute(string str) => comment = str;
    }

    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }
[XmlInclude(typeof(Cow))]
[XmlInclude(typeof(Lion))]
[XmlInclude(typeof(Pig))]
public abstract class Animal
    {
        public eClassificationAnimal a_type { get; set; }
        public eFavoriteFood a_favoriteFood { get; set; }
        public string Country { get; set; }
        private string HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        private string WhatAnimal { get; set; }
        public Animal() { }
        public Animal(eFavoriteFood food, eClassificationAnimal animal, string country, string hide, string name, string w_animal)
        {
            a_favoriteFood = food;
            a_type = animal;
            this.Country = country;
            this.HideFromOtherAnimals = hide;
            this.Name = name;
            this.WhatAnimal = w_animal;
        }
        ~Animal() { }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return a_type;
        }
        public abstract eFavoriteFood GetFavoriteFood();
        public abstract void SayHello();
    }

    [CommentAttribute("This is cow")]
    public class Cow : Animal
    {
        public Cow(eFavoriteFood food, eClassificationAnimal animal, string country, string hide, string name, string w_animal) : base(food, animal, country, hide, name, w_animal) { }

        public Cow() { }
        public override eFavoriteFood GetFavoriteFood()
        {
            return base.a_favoriteFood;
        }

        public override void SayHello()
        {
            Console.WriteLine($"Hello i'm cow-{base.Name}!");
        }
    }

    [CommentAttribute("This is lion")]
    public class Lion : Animal
    {
        public Lion(eFavoriteFood food, eClassificationAnimal animal, string country, string hide, string name, string w_animal) : base(food, animal, country, hide, name, w_animal) { }

        public Lion() { }
        public override eFavoriteFood GetFavoriteFood()
        {
            return base.a_favoriteFood;
        }

        public override void SayHello()
        {
            Console.WriteLine($"Hello i'm lion-{base.Name}!");
        }
    }

    [CommentAttribute("This is pig")]
    public class Pig : Animal
    {
        public Pig(eFavoriteFood food, eClassificationAnimal animal, string country, string hide, string name, string w_animal) : base(food, animal, country, hide, name, w_animal) { }

        public override eFavoriteFood GetFavoriteFood()
        {
            return base.a_favoriteFood;
        }

        public Pig() { }
        public override void SayHello()
        {
            Console.WriteLine($"Hello i'm pig-{base.Name}!");
        }
    }
