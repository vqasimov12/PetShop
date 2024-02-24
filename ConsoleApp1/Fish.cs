namespace ConsoleApp1;
public class Fish : Pet
{
   public static void SetMeal()
    {
        Meal[0, 0] = "Fish flakes";
        Meal[0, 1] = "0";
        Meal[1, 0] = "Fish sticks";
        Meal[1, 1] = "0";
        Meal[2, 0] = "Fish wafers";
        Meal[2, 1] = "0";
    }
    public static string[,] Meal = new string[3, 2];
    public Fish(string _nicKName, string _gender, double _age, int _energy, double _price) : base(_nicKName, _gender, _age, _energy, _price)
    {
        SetMeal();
    }
    public  static void BuyMeal()
    {
        const int size = 4;
        string[] arr = new string[size] { "Fish flakes => 2$", "Fish sticks => 3$", "Fish wafers= 4$", "Exit" };
        string food = SelectFood(arr);
        if (food == "Fish flakes => 2$")
        {
            if (Budget >= 2)
            {
                Budget -= 2;
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
        else if (food == "Fish sticks => 3$")
        {

            if (Budget >= 3)
            {
                Budget -= 3;
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
        else if (food == "Fish wafers= 4$")
        {

            if (Budget >= 4)
            {
                Budget -= 4;
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
        string[] arr = new string[4] { "Fish flakes", "Fish sticks", "Fish wafers", "Exit" };
        string food = SelectFood(arr);
        if (food == "Null")
            return;
        if (food == "Fish flakes")
        {
            int count = Int32.Parse(Meal[0, 1]);
            if (count == 0)
            {
                Console.WriteLine("Please buy some Fish flakes you don't have enough in stock");
                Console.ReadKey(true);
                return;
            }
            count--;
            Meal[0, 1] = count.ToString();
        }

        else if (food == "Fish sticks")
        {
            int count = Int32.Parse(Meal[1, 1]);
            if (count == 0)
            {
                Console.WriteLine("Please buy some Fish sticks you don't have enough in stock");
                Console.ReadKey(true);
                return;
            }
            count--;
            Meal[1, 1] = count.ToString();
        }

        else if (food == "Fish wafers")
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
