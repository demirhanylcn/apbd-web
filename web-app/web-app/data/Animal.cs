namespace web_app.data;
public enum Type
{
    Dog,
    Cat,
    Rat
}

public enum Color
{
    Red = 1,
    Blue = 2,
    Black = 3,
    Orange = 4,
    Brown = 5
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
    //Retrieve list of animals.
    public List<Animal> RetrieveAnimals() { return animals; }
    public void PrintAllAnimals()
    {
        var index = 1;
        foreach (var each in animals)
        {
            Console.WriteLine("[" + index++ + "] animal is, "+ each +".");
        }
    }

    // Retrieve specific animal by id.
    public Animal GetSpecificAnimal(int id)
    {
        return animals.Find(animal => animal._id == id);
    }
    
    // Add an animal part is already handled in the construction.
    // Edit an animal
    private void EditAnimal()
    {
        Console.WriteLine("Editing animal is possible! Which of those options are the ones you want to edit?");
        _name = getInput("name");
        _weight = Double.Parse(getInput("weight"));
        _color = getColor(getInput("color"));

    }

    private Color getColor(string color)
    {
        var givenColor = Color.Black;
        switch (color)
        {
            case "red":
                givenColor = Color.Red;
                break;
            case "blue":
                givenColor = Color.Blue;
                break;
            case "black":
                givenColor = Color.Black;
                break;
            case "orange":
                givenColor = Color.Orange;
                break;
            case "brown":
                givenColor = Color.Brown;
                break;
        }

        return givenColor;
    }

    private string getInput(string value)
    {
        if (value == "color")
        {
            string[] colors = { "red", "black", "orange", "blue", "brown" };
            while (true)
            {
                Console.WriteLine("Color options are = red,black,orange,blue,brown");
                Console.WriteLine("So, what is the new " + value + " ?");
                string color = Console.ReadLine();
                foreach (var each in colors)
                {
                    if (each == color.ToLower()) return color.ToLower();
                }
                Console.WriteLine("There is typo or wrong choice. Try again.");
            }
            
        }
        else
        {
            Console.WriteLine("What is the new " + value + " ?");
            return Console.ReadLine();
        }
            
    }
    // Delete an animal
    private void DeleteAnimal()
    {
        
    }
}