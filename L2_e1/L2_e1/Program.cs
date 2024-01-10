using System;

int[] pupil1Scores = { 5, 4, 4, 5, 5 };
int[] pupil2Scores = { 3, 4, 2, 3, 2 };
int[] pupil3Scores = { 4, 5, 3, 4, 5 };
int[] pupil4Scores = { 2, 3, 2, 2, 3 };

Pupil pupil1 = new ExcellentPupil(true, true, "John Smith", "Reading books", pupil1Scores);
Pupil pupil2 = new GoodPupil(true, true, "Alice Johnson", "Playing sports", pupil2Scores);
Pupil pupil3 = new GoodPupil(true, true, "Bob Williams", "Painting", pupil3Scores);
Pupil pupil4 = new BadPupil(true, true, "Emily Davis", "Cooking", pupil4Scores);

ClassRoom classRoom = new ClassRoom(pupil1, pupil2, pupil3, pupil4);

classRoom.StartLesson();

Console.ReadLine();
class ClassRoom
{
    Pupil[] team;
    public ClassRoom(params Pupil[] stack)
    {
        team = new Pupil[stack.Length];
        for (int i = 0; i < stack.Length; i++)
        {
            team[i] = stack[i];
        }
    }

    public void StartLesson()
    {
        Console.WriteLine("Starting the lesson:");
        foreach (var pupil in team)
        {
            pupil.Study();
            pupil.Read();
            pupil.Write();
            pupil.Relax();
        }
    }
}

class Pupil
{
    bool? read;
    bool? write;
    int[] marks;
    public string? full_name;
    string? cl;
    public string? hobby;
    public string? FullName
    {
        get { return full_name; }
    }

    public string? Hobby
    {
        get { return hobby; }
    }

    public Pupil(bool? reading = null, bool? writing = null, string? fn = "Undefined", string? hb = null, params int[] scores)
    {
        marks = scores;
        read = reading;
        write = writing;
        full_name = fn;
        hobby = hb;
    }

    public virtual void Study()
    {
        Console.WriteLine($"{full_name} is studying.");
    }

    public virtual void Read()
    {
        if (read) { Console.WriteLine($"{full_name} is reading."); }
        else { Console.WriteLine($"{full_name} can't read."); }
    }

    public virtual void Write()
    {
        if (write) { Console.WriteLine($"{full_name} is writing."); }
        else { Console.WriteLine($"{full_name} can't write."); }
    }

    public virtual void Relax()
    {
        Console.WriteLine($"{full_name} is relaxing by {hobby}.");
    }
}

class ExcellentPupil : Pupil
{
    public ExcellentPupil(bool? reading = null, bool? writing = null, string? fn = "Undefined", string? hb = null, params int[] scores)
        : base(reading, writing, fn, hb, scores)
    {
    }

    public override void Study()
    {
        Console.WriteLine($"{full_name} is an excellent pupil and is studying.");
    }
    public override void Relax()
    {
        Console.WriteLine($"{full_name} is relaxing by {this.Hobby}.");
    }
    public override void Read()
    {
        if (read) { Console.WriteLine($"{full_name} is reading."); }
        else { Console.WriteLine($"{full_name} can't read."); }
    }

    public override void Write()
    {
        if (write) { Console.WriteLine($"{full_name} is writing."); }
        else { Console.WriteLine($"{full_name} can't write."); }
    }
}

class GoodPupil : Pupil
{
    public GoodPupil(bool? reading = null, bool? writing = null, string? fn = "Undefined", string? hb = null, params int[] scores)
        : base(reading, writing, fn, hb, scores)
    {
    }

    public override void Study()
    {
        Console.WriteLine($"{full_name} is a good pupil and is studying.");
    }
    public override void Relax()
    {
        Console.WriteLine($"{full_name} is relaxing by {this.Hobby}.");
    }
    public override void Read()
    {
        if (read) { Console.WriteLine($"{full_name} is reading."); }
        else { Console.WriteLine($"{full_name} can't read."); }
    }

    public override void Write()
    {
        if (write) { Console.WriteLine($"{full_name} is writing."); }
        else { Console.WriteLine($"{full_name} can't write."); }
    }
}

class BadPupil : Pupil
{
    public BadPupil(bool? reading = null, bool? writing = null, string? fn = "Undefined", string? hb = null, params int[] scores)
        : base(reading, writing, fn, hb, scores)
    {
    }
    public override void Relax()
    {
        Console.WriteLine($"{full_name} is relaxing by {this.Hobby}.");
    }

    public override void Study()
    {
        Console.WriteLine($"{full_name} is a bad pupil and is studying.");
    }
    public override void Read()
    {
        if (read) { Console.WriteLine($"{full_name} is reading."); }
        else { Console.WriteLine($"{full_name} can't read."); }
    }

    public override void Write()
    {
        if (write) { Console.WriteLine($"{full_name} is writing."); }
        else { Console.WriteLine($"{full_name} can't write."); }
    }
}



