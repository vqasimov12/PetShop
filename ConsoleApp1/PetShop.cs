namespace ConsoleApp1;
public class PetShop
{
    List<Cat> catList = new();
    List<Fish> fishList = new();
    List<Dog> dogList = new();
    string pet = "Null";
    public PetShop()
    {
        Pet.Budget = 12;
        Menu();
    }
    void ShowMenu(string[] arr, int select)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (i == select)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(arr[i]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
                Console.WriteLine(arr[i]);
        }
    }
    public void Menu()
    {
        string[] arr = new string[4] { "Fish", "Cat", "Dog", "Exit" };
        int select = 0;
        while (true)
        {
            Console.Clear();
            ShowMenu(arr, select);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                select++;
                if (select == 4)
                    select = 0;
            }

            else if (key.Key == ConsoleKey.UpArrow)
            {
                select--;
                if (select == -1)
                    select = 3;
            }

            else if (key.Key == ConsoleKey.Escape)
                return;

            else if (key.Key == ConsoleKey.Enter)
            {
                if (select == 0)
                    pet = "Fish";
                else if (select == 1)
                    pet = "Cat";
                else if (select == 2)
                    pet = "Dog";
                else return;
                PetMenu();
            }
        }
    }

    void Sell()
    {
        string name;
        Console.WriteLine($"Enter {pet}'s name: ");
        name = Console.ReadLine();
        bool found = false;
        if (pet == "Fish")
        {
            for (int i = 0; i < fishList.Count; i++)
            {
                Fish fish = fishList[i];
                if (fish.Nickname == name)
                {
                    Pet.Budget += fish.Price;
                    fishList.RemoveAt(i);
                    found = true;
                    break;
                }
            }
        }

        else if (pet == "Cat")
        {
            for (int i = 0; i < catList.Count; i++)
            {
                Cat cat = catList[i];
                if (cat.Nickname == name)
                {
                    Pet.Budget += cat.Price;
                    catList.RemoveAt(i);
                    found = true;
                    break;
                }
            }
        }

        else if (pet == "Dog")
        {
            for (int i = 0; i < dogList.Count; i++)
            {
                Dog dog = dogList[i];
                if (dog.Nickname == name)
                {
                    Pet.Budget += dog.Price;
                    dogList.RemoveAt(i);
                    found = true;
                    break;
                }
            }
        }
     
        if (!found)
            Console.WriteLine("Animal cannot be found");
        Console.WriteLine("Press Enter to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    void Add()
    {
        string nickname = "null";
        string gender;
        double age;
        double price;
        int energy;

        while (true)
        {
            Console.WriteLine($"Enter {pet}'s Nickname");
            nickname = Console.ReadLine();
            if (nickname == null || nickname.Length < 3)
            {
                Console.WriteLine("NickName can not be Null or contain less than 3 character");
                Console.ReadKey(true);
            }
            else break;
            Console.Clear();
        }

        while (true)
        {
            Console.WriteLine($"Enter {nickname}'s gender(male||female) ");
            gender = Console.ReadLine();

            if (gender.ToLower() != "male" && gender.ToLower() != "female")
            {
                Console.WriteLine("Enter gender correctly (male||female)");
                Console.ReadKey(true);
            }
            else break;
            Console.Clear();
        }

        Console.Write("Enter Age: ");
        age = double.Parse(Console.ReadLine());
        Console.Write("Enter Price: ");
        price = double.Parse(Console.ReadLine());
        Console.Write("Enter Energy: ");
        energy = Int32.Parse(Console.ReadLine());
        if (pet == "Fish")
        {
            try
            {
                Fish fish = new(nickname, gender, age, energy, price);
                fishList.Add(fish);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        else if (pet == "Cat")
        {
            try
            {
                Cat cat = new(nickname, gender, age, energy, price);
                catList.Add(cat);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        else if (pet == "Dog")
        {
            try
            {
                Dog dog = new(nickname, gender, age, energy, price);
                dogList.Add(dog);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }

    void Feed()
    {
        string name;
        Console.WriteLine($"Enter {pet}'s name: ");
        name = Console.ReadLine();

        if (pet == "Fish")

            foreach (Fish fish in fishList)
                if (fish.Nickname == name)
                    fish.Eat();

                else Console.WriteLine("Animal can not be found");

        else if (pet == "Cat")

            foreach (Cat cat in catList)
                if (cat.Nickname == name)
                    cat.Eat();

                else Console.WriteLine("Animal can not be found");

        else if (pet == "Dog")

            foreach (Dog dog in dogList)
                if (dog.Nickname == name)
                    dog.Eat();

                else Console.WriteLine("Animal can not be found");

    }

    void Play()
    {
        string name;
        Console.WriteLine($"Enter {pet}'s name: ");
        name = Console.ReadLine();

        if (pet == "Fish")

            foreach (Fish fish in fishList)
                if (fish.Nickname == name)
                    fish.Play();

                else Console.WriteLine("Animal can not be found");

        else if (pet == "Cat")

            foreach (Cat cat in catList)
                if (cat.Nickname == name)
                    cat.Play();

                else Console.WriteLine("Animal can not be found");

        else if (pet == "Dog")

            foreach (Dog dog in dogList)
                if (dog.Nickname == name)
                    dog.Play();

                else Console.WriteLine("Animal can not be found");
        Console.ReadKey(true);
    }

    void PetMenu()
    {
        string[] arr = new string[5] { $" Add {pet}", $" Sell {pet}", $" Feed {pet}", $" Play with {pet}", $" Buy Meal for {pet}" };
        int select = 0;
        while (true)
        {
            Console.Clear();
            ShowMenu(arr, select);
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow)
            {
                select++;
                if (select == 5)
                    select = 0;
            }

            else if (key.Key == ConsoleKey.UpArrow)
            {
                select--;
                if (select == -1)
                    select = 4;
            }

            else if (key.Key == ConsoleKey.Escape)
                return;

            else if (key.Key == ConsoleKey.Enter)
            {
                if (select == 0)
                    Add();

                else if (select == 1)
                    Sell();

                else if (select == 2)
                    Feed();

                else if (select == 3)
                    Play();
            }
        }

    }

}
