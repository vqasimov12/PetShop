namespace ConsoleApp1;
public class Dog : Pet
{
    public static void SetMeal()
    {
        Meal[0, 0] = "Bone";
        Meal[0, 1] = "0";
        Meal[1, 0] = "Meat";
        Meal[1, 1] = "0";
        Meal[2, 0] = "Chicken";
        Meal[2, 1] = "0";
    }
    public static string[,] Meal = new string[3, 2];
    public Dog(string _nicKName, string _gender, double _age, int _energy, double _price) : base(_nicKName, _gender, _age, _energy, _price)
    {
        SetMeal();
    }
    public static void BuyMeal()
    {
        const int size = 4;
        string[] arr = new string[size] { "Bone => 1$", "Meat => 2$", "Chicken= 5$", "Exit" };
        string food = SelectFood(arr);
        if (food == "Bone => 1$")
        {
            if (Budget >= 1)
            {
                Budget -= 1;
                int count = Int32.Parse(Meal[0, 1]);
                count++;
                Meal[0, 1] = count.ToString();
            }
            else
            {
                Console.WriteLine("You don't have enough budget to buy this Meal.\nYou can earn money by playing with pets or selling pets ");
                Console.ReadKey(true);
            }
        }
        else if (food == "Meat => 2$")
        {

            if (Budget >= 2)
            {
                Budget -= 2;
                int count = Int32.Parse(Meal[1, 1]);
                count++;
                Meal[1, 1] = count.ToString();
            }
            else
            {
                Console.WriteLine("You don't have enough budget to buy this Meal.\nYou can earn money by playing with pets or selling pets ");
                Console.ReadKey(true);
            }
        }
        else if (food == "Chicken= 5$")
        {

            if (Budget >= 5)
            {
                Budget -= 5;
                int count = Int32.Parse(Meal[2, 1]);
                count++;
                Meal[2, 1] = count.ToString();
            }
            else
            {
                Console.WriteLine("You don't have enough budget to buy this Meal.\nYou can earn money by playing with pets or selling pets ");
                Console.ReadKey(true);
            }
        }
    }
    public override void Eat()
    {
        string[] arr = new string[4] { "Bone", "Meat", "Chicken", "Exit" };
        string food = SelectFood(arr);
        if (food == "Null")
            return;
        if (food == "Bone")
        {
            int count = Int32.Parse(Meal[0, 1]);
            if (count == 0)
            {
                Console.WriteLine("Please buy some bone you don't have enough in stock");
                Console.ReadKey(true);
                return;
            }
            count--;
            Meal[0, 1] = count.ToString();
        }

        else if (food == "Meat")
        {
            int count = Int32.Parse(Meal[1, 1]);
            if (count == 0)
            {
                Console.WriteLine("Please buy some meat you don't have enough in stock");
                Console.ReadKey(true);
                return;
            }
            count--;
            Meal[1, 1] = count.ToString();
        }

        else if (food == "Chicken")
        {
            int count = Int32.Parse(Meal[2, 1]);
            if (count == 0)
            {
                Console.WriteLine("Please buy some chicken you don't have enough in stock");
                Console.ReadKey(true);
                return;
            }
            count--;
            Meal[2, 1] = count.ToString();
        }

        Energy += 10;
        Age += 0.1;
        Price += 1;
        Action("eating");
        Console.ReadKey(true);
    }
}
