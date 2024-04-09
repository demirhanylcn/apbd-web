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
    public int _id { get; private set; }
    public string _name { get; private set; }
    public Type _type { get; private set; }
    public double _weight { get; private set; }
    public Color _color { get; private set; }
}