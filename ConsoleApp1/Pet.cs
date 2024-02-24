namespace ConsoleApp1;

public abstract class Pet
{
    public Pet(string _nickname, string _gender, double _age, int _energy, double _price)
    {
        Nickname = _nickname;
        Gender = _gender ?? "NULL";
        Age = _age;
        Energy = _energy;
        Price = _price;
    }

    private string _name;

    private double _age;

    private string _gender;
    public string Nickname
    {
        get { return _name; }
        set { if (value.Length > 3) _name = value; else throw new Exception("Nickname can not be NULL"); }
    }
    public double Age
    {
        get { return _age; }
        set { if (value < 0 || value > 15) throw new Exception("Pet's age should between 0 and 15"); _age = value; }
    }
    public string Gender { get { return _gender; } init { _gender = value; } }
    public int Energy { get; set; }
    public double Price { get; set; }
    public static double Budget { get; set; }
    public abstract void Eat();
    public void Sleep()
    {
        Energy += 100;
        Age += 0.1;
        Action("Slepping");
    }
    protected  static void ShowFood(string[] arr, int select)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == select)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(arr[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.WriteLine(arr[i]);
        }
    }
    protected static string SelectFood(string[] arr)
    {
        int select = 0;
        while (true)
        {
            Console.Clear();
            ShowFood(arr, select);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
            {
                select--;
                if (select == -1)
                    select = 3;
            }

            else if (key.Key == ConsoleKey.DownArrow)
            {
                select++;
                if (select == 4)
                    select = 0;
            }

            else if (key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                return "Null";
            }

            else if (key.Key == ConsoleKey.Enter)
            {

                Console.Clear();
                return arr[select];
            }
        }
    }
    public override string ToString()
    {
        return $" Nickname: {Nickname}\n Age:      {Age}\n Gender    {Gender}\n Energy    {Energy}%\n Price     {Price}$";
    }
    protected void Action(string act)
    {
        Console.Clear();
        Console.WriteLine($"{Nickname} is {act}.");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine($"{Nickname} is {act}..");
        Thread.Sleep(200);
        Console.Clear();
        Console.WriteLine($"{Nickname} is {act}...");
        Thread.Sleep(200);
    }
    public void Play()
    {
        Energy -= 5;
        Age += 0.1;
        Budget += 10;
        Action("playing");
        if (Energy <= 0)
        {
            Console.WriteLine($"{Nickname} is tired it should Sleep");
            Console.ReadKey(true);
            Sleep();
            Console.ReadKey(true);
        }
    }
}
