using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PA_Test
{
    public class LaTerrariumMenu //La = Land
    {
        Utility util = new Utility();


        public void LaTerrariumMenuDisplay()
        {
            Console.WriteLine("Land Terrarium Menu");
            Console.WriteLine("(1) Create (Terarium and adds it to the List)");
            Console.WriteLine("(2) Destroy (Terrarium)");
            Console.WriteLine("(3) Display");
            Console.WriteLine("(4) Add snake to terrarium");
            Console.WriteLine("(5) back");
            Console.WriteLine("(6) Exit");
        }

        

        public List<LandTerrarium> LaTerrariumSwitch(string choice, List<Snake> snakeList, string snakeFilename, List<LandTerrarium> lanTerList, string lanTerfilename)
        {
            SnakeMenu snakeMenu = new SnakeMenu();
            XML theXml = new XML();
            //maybe a WHILE here?
            while (true)
            {
                try
                {
                    if (choice == "create" || choice == "1")
                    {
                        AddTerToList(CreateLaTerrarium(lanTerList), lanTerList);
                        theXml.LandTerWriteToXmlFile(lanTerList, lanTerfilename);
                        Console.WriteLine("Land terrarium successfully created.");
                        break;
                    }
                    else if (choice == "destroy" || choice == "2")
                    {
                        while (true)
                        {
                            Console.WriteLine("ID: ");
                            string id = Console.ReadLine();
                            string msg = $"Terrarium with: {id} has been deleted.";
                            if (DestroyTerrarium(lanTerList, id) == msg)
                            {
                                Console.WriteLine(msg);
                                break;
                            }
                            Console.WriteLine("Invalid id!");
                        }
                        theXml.LandTerWriteToXmlFile(lanTerList, lanTerfilename);
                        break;
                    }

                    else if (choice == "display" || choice == "3")
                    {
                        DisplayTerrarium(lanTerList);
                        break;
                    }
                    else if (choice == "add" || choice == "4")
                    {
                        AddSnakeToTer(snakeList, lanTerList, snakeMenu);
                        Console.WriteLine("Done");
                        theXml.LandTerWriteToXmlFile(lanTerList, lanTerfilename);
                        theXml.WriteToXmlFile(snakeList, snakeFilename);
                        break;
                    }
                    
                    else if (choice == "back" || choice == "5")
                    {
                        break;
                    }
                    else if (choice == "exit" || choice == "6")
                    {
                        System.Environment.Exit(1);
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            return lanTerList;
        }

        bool TypeChecker(string snakeName, List<Snake> snakeList)
        {
            string type = "land";
            // True if good to go, else false
            foreach (var snake in snakeList)
            {
                if (type.ToLower() == snake.Type.ToLower() && snake.Name == snakeName)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddSnakeToTer(List<Snake> snakeList, List<LandTerrarium> laTerList, SnakeMenu snakeMenu)
        {
            Console.WriteLine("Please choose the terrarium you would like to add the snake to:");
            string sName;
            DisplayTerrarium(laTerList);
            Console.WriteLine("ID: ");
            string terId = Console.ReadLine();

            Console.WriteLine("Please choose the snake you would like to add:");
            snakeMenu.DisplayAllSnakes(snakeList);
            while (true)
            {
                Console.WriteLine("Name: ");
                string snakeName = Console.ReadLine();
                if (TypeChecker(snakeName, snakeList) == true)
                {
                    sName = snakeName;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input!");
                }
            }


            foreach (var ter in laTerList)
            {
                if (ter.ID == terId)
                {
                    foreach (var snake in snakeList)
                    {
                        if (snake.Name == sName)
                        {
                            ter.AddSnake(snake);
                            snakeList.Remove(snake);
                            Console.WriteLine($"Snake: {snake.Name} has been removed from the SnakeList.");
                            Console.WriteLine($"Snake: {snake.Name} has been added to the terrarium with ID: {ter.ID}.");
                            break;
                        }
                    }
                    break;
                }
            }
        }

        public string DestroyTerrarium(List<LandTerrarium> lanTerList, string id)
        {

            string message = "";
            foreach (var ter in lanTerList)
            {
                if (ter.ID == id)
                {
                    lanTerList.Remove(ter);
                    message = $"Terrarium with: {id} has been deleted.";
                    break;
                }
            }
            if (message == $"Terrarium with: {id} has been deleted.")
            {
                return message;
            }
            else
            {
                message = "Invalid ID";
                return message;
            }

        }

        public bool DidItDelete(List<LandTerrarium> laTerList, List<LandTerrarium> tempLaTerList)
        {
            bool equal = laTerList.SequenceEqual(tempLaTerList);
            return equal;
        }

        public void AddTerToList(LandTerrarium lanTer, List<LandTerrarium> lanTerList) //CHANGED LandTerrarium -> Terrarium
        {
            lanTerList.Add(lanTer);
        }

        public LandTerrarium CreateLaTerrarium(List<LandTerrarium> terList)
        {
            string id = util.IdGenerator();
            List<Snake> snakeList = new List<Snake>();
            LandTerrarium lanTer = new LandTerrarium(id, snakeList); //PROBLEM maybe change LandTerrarium to just Terrarium?
            return lanTer;
        }
        public void DisplayTerrarium(List<LandTerrarium> terList)
        {
            foreach (var ter in terList)
            {
                Console.WriteLine(ter.ToString());
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
