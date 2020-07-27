using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PA_Test
{
    public class SnakeMenu : Menu
    {

        public List<Snake> ProgramToClass(List<Snake> snakes)
        {
            List<Snake> snakeList;
            snakeList = snakes;
            return snakeList;
        }
        
        public void DisplaySnakeMenu()
        {
            Console.WriteLine("Snake Menu");
            Console.WriteLine("(1) Create (creates and adds snake to List)");
            Console.WriteLine("(2) Destroy (takes snake out of the List)");
            Console.WriteLine("(3) Update (update snake)");
            Console.WriteLine("(4) Display (all snakes)");
            Console.WriteLine("(5) Back");
            Console.WriteLine("(6) Exit");
        }

        public List<Snake> SnakeSwitch(string choice, List<Snake> snakeList, List<WaterTerrarium> waTerList, List<LandTerrarium> lanTerList, string filename)
        {
            while (true)
            {
                try
                {
                    if (choice == "create" || choice == "1")
                    {
                        AddSnakeToList(CreateSnake(snakeList), snakeList); //check, 2 snakes can NOT have the same name
                        Console.WriteLine("Done!");
                        break;

                    }
                    else if (choice == "destroy" || choice == "2")
                    {
                        while (true)
                        {
                            Console.WriteLine("Name: ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Type: ");
                            string type = Console.ReadLine();
                            string msg = $"Snake with name: {name} and type: {type} is deleted.";
                            if (msg == DeleteSnake(name, type, snakeList))
                            {
                                Console.WriteLine(msg);
                                break;
                            }
                            Console.WriteLine("Invalid name or type or both!");
                        }
                        break;
                    }
                    else if (choice == "update" || choice == "3")
                    {
                        Console.WriteLine("Name of the snake you want to update: ");
                        string uiName = Console.ReadLine();
                        UpdateSnake(uiName, snakeList);
                        Console.WriteLine("Done!");
                        break;

                    }
                    else if (choice == "display" || choice == "4")
                    {
                        DisplayAllSnakes(snakeList);
                        break;
                    }
                    else if (choice == "exit" || choice == "5")
                    {
                        System.Environment.Exit(1);
                    }
                    else if (choice == "back" || choice == "6")
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Type with lowercase maybe.");
                }
            }

            return snakeList;
        }

        public void DuplicateChecker(List<Snake> snakeList, string name)
        {
            foreach (var snake in snakeList)
            {
                if (snake.Name == name)
                {
                    snakeList.Remove(snake);
                    Console.WriteLine("Snake duplicate found!");
                    Console.WriteLine("One of the snake out of the duplicates are deleted.");
                }
            }
        }


        public void AddSnakeToList(Snake snake, List<Snake> snakeList)
        {
            snakeList.Add(snake);
        }

        public Snake CreateSnake(List<Snake> snakeList) //XML writes it also
        {
            string uiType;
            string name;
            Snake Hul = new Snake(); //HashSet instead of list?
            while (true)
            {
                Console.WriteLine("Name: ");
                string uiName = Console.ReadLine();
                if (!DoesExist(snakeList, uiName))
                {
                    name = uiName;
                    break;
                }
            }
            
            uiType = TypeChecker();
            Hul.Name = name;
            Hul.Type = uiType;
            return Hul;
        }

        public string TypeChecker()
        {
            string type = "";
            while (true)
            {
                Console.WriteLine("Type: (Water or Land)");
                string uiType = Console.ReadLine();
                if (!(uiType.ToLower() == "water" || uiType.ToLower() == "land"))
                {
                    Console.WriteLine("Please type 'Water' or 'Land' as a type!");
                }
                else
                {
                    type = uiType;
                    break;
                }
            }
            return type;
        }

        public bool DoesExist(List<Snake> snakeList, string name)
        {
            while (true)
            {
                foreach (var snake in snakeList)
                {
                    if (snake.Name.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Snake already exists with given name!\nTry again!");
                        return true;
                    }

                }
                return false;
            }
        }
        public string DeleteSnake(string name, string type, List<Snake> snakeList)
        {
            string msg = "";
            foreach (var snake in snakeList.ToList())
            {
                if (name == snake.Name && type == snake.Type)
                {
                    msg = $"Snake with name: {name} and type: {type} is deleted.";
                    snakeList.Remove(snake);
                    break;
                }
            }
            if (msg == $"Snake with name: {name} and type: {type} is deleted.")
            {
                return msg;
            }
            else
            {
                msg = "Invalid name or type or both!";
                return msg;
            }

        }

        public void UpdateSnake(string name, List<Snake> snakeList)
        {
            try
            {
                foreach (var snake in snakeList)
                {
                    if (name == snake.Name)
                    {
                        Console.WriteLine("New Name: ");
                        string newName = Console.ReadLine();
                        Console.WriteLine("New Type: ");
                        string newType = Console.ReadLine();
                        snake.Name = newName;
                        snake.Type = newType;
                        Console.WriteLine("Update successful!");
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Check given name!");
            }
        }

        public void DisplayAllSnakes(List<Snake> snakeList)
        {
            foreach (Snake item in snakeList)
            {
                Console.WriteLine($"Snake's Name: {item.Name} - Snake's Type: {item.Type}");
            }
        }
    }
}
