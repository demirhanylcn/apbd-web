namespace web_app.data;
public enum Type
{
    Dog,
    Cat,
    Rat
}

public enum Color
{
    Red,
    Blue,
    Black,
    Orange,
    Brown
}
public class Animal
{
    private static int count = 1;
    public int _id { get; private set; }
    public string _name { get; private set; }
    public Type _type  { get; private set; }
    public double _weight { get; private set; }
    public Color _color { get; private set; }
    private static List<Animal> animals = new();

    public Animal(string name, double weight, Type type, Color color)
    {
        _id = count++;
        _name = name;
        _weight = weight;
        _type = type;
        _color = color;
        Console.WriteLine("Buddy called " + this + " is successfully added to system!");
        animals.Add(this);
    }

    public override string ToString() { return _name; }
    public List<Animal> RetrieveAnimals() { return animals; }
    public void PrintAllAnimals()
    {
        var index = 1;
        foreach (var each in animals)
        {
            Console.WriteLine("[" + index++ + "] animal is, "+ each +".");
        }
    }

    public Animal GetSpesificAnimal(int id)
    {
        return animals.Find(animal => animal._id == id);
    }
    
}