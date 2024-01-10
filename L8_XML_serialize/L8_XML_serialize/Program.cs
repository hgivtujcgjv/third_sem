using System.Xml.Serialization;
using System;
using System.Runtime.Serialization;


Cow cow1 = new Cow(eFavoriteFood.Plants, eClassificationAnimal.Herbivores, "USA", "Grass", "Bessie", "Cow");
Lion lion2 = new Lion(eFavoriteFood.Meat, eClassificationAnimal.Carnivores, "India", "Jungle", "Rajah", "Lion"); Pig pig3 = new Pig(eFavoriteFood.Everything, eClassificationAnimal.Omnivores, "Brazil", "Farm", "Porky", "Pig");
Animal animal = new Cow(eFavoriteFood.Plants, eClassificationAnimal.Herbivores, "Country", "Hide", "KOT", "WhatAnimal");
XmlSerializer xmlSerializer = new XmlSerializer(typeof(Animal[]));
Animal[] massive = { animal , lion2,cow1};
using (FileStream fs = new FileStream("Animal1.xml", FileMode.Create))
{
    xmlSerializer.Serialize(fs, massive);
    Console.WriteLine("Object has been serialized\n\n");
}

using (FileStream fs1 = new FileStream("Animal1.xml", FileMode.Open))
{
    XmlSerializer formatter = new XmlSerializer(typeof(Animal[]));
    Animal[]? newanimal = formatter.Deserialize(fs1) as Animal[];

    if (newanimal != null)
    {
        foreach (Animal i in newanimal)
        {
            Console.WriteLine($"Name: {i.Name} --- FV_food: {i.GetFavoriteFood()}");
        }
    }
}