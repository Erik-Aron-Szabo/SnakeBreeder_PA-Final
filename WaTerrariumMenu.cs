using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PA_Test
{
    public class WaTerrariumMenu // Wa = Water
    {
        Utility util = new Utility();

        public void WaTerrariumMenuDisplay()
        {
            Console.WriteLine("Water Terrarium Menu");
            Console.WriteLine("(1) Create (Terrarium)");
            Console.WriteLine("(2) Destroy (Terrarium)");
            Console.WriteLine("(3) Display");
            Console.WriteLine("(4) Add snake to terrarium");
            Console.WriteLine("(5) back");
            Console.WriteLine("(6) Exit");
        }

        
        public List<WaterTerrarium> WaTerrariumSwitch(string choice, List<Snake> snakeList, string snakeFilename, List<WaterTerrarium> waTerList, string waterFilename)
        {
            SnakeMenu snakeMenu = new SnakeMenu();
            XML theXml = new XML();
            List<WaterTerrarium> tempWaterList = waTerList;

            //maybe a WHILE here?
            while (true)
            {
                try
                {
                    if (choice == "create" || choice == "1")
                    {
                        AddTerToList(CreateWaTerrarium(waTerList), waTerList);
                        theXml.WaterTerWriteToXmlFile(waTerList, waterFilename);
                        Console.WriteLine("Water terrarium successfully created.");
                        break;

                    }
                    else if (choice == "destroy" || choice == "2")
                    {
                        while (true)
                        {
                            Console.WriteLine("ID: ");
                            string id = Console.ReadLine();
                            string msg = $"Terrarium with: {id} has been deleted.";
                            if (DestroyTerrarium(waTerList, id) == msg)
                            {
                                Console.WriteLine(msg);
                                break;
                            }
                            Console.WriteLine("Invalid id!");
                        }
                        theXml.WaterTerWriteToXmlFile(waTerList, waterFilename);
                        break;

                    }

                    else if (choice == "display" || choice == "3")
                    {
                        DisplayTerrarium(waTerList);
                        break;
                    }
                    else if (choice == "add" || choice == "4")
                    {
                        AddSnakeToTer(snakeList, waTerList, snakeMenu);
                        Console.WriteLine("Done");
                        theXml.WaterTerWriteToXmlFile(waTerList, waterFilename);
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
           

            return waTerList;
        }


        public void AddSnakeToTer(List<Snake> snakeList, List<WaterTerrarium> waTerList, SnakeMenu snakeMenu)
        {
            Console.WriteLine("Please choose the terrarium you would like to add the snake to:");
            DisplayTerrarium(waTerList);
            Console.WriteLine("ID: ");
            string terId = Console.ReadLine();

            Console.WriteLine("Please choose the snake you would like to add:");
            snakeMenu.DisplayAllSnakes(snakeList);
            while (true)
            {
                Console.WriteLine("Name: ");
                string snakeName = Console.ReadLine();
                foreach (var ter in waTerList)
                {
                    if (ter.ID == terId)
                    {
                        foreach (var snake in snakeList)
                        {
                            if (snake.Name == snakeName)
                            {
                                try
                                {
                                    ter.AddSnake(snake);
                                }
                                catch (Exception ex)
                                {

                                    throw ex;
                                }

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
        }

        public string DestroyTerrarium(List<WaterTerrarium> waTerList, string id)
        {

            string message = "";
            foreach (var ter in waTerList)
            {
                if (ter.ID == id)
                {
                    waTerList.Remove(ter);
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

        public bool DidItDelete(List<WaterTerrarium> waTerList, List<WaterTerrarium> tempWaTerList)
        {
            bool equal = waTerList.SequenceEqual(tempWaTerList);
            return equal;
        }

        public void AddSnakeToTerrarium(string id, List<WaterTerrarium> waTerList, List<Snake> snakeList)
        {

            foreach (var ter in waTerList)
            {
                if (ter.ID == id)
                {
                    foreach (var snake in snakeList)
                    {
                        Console.WriteLine("Name of the snake:");
                        string name = Console.ReadLine();
                        if (name == snake.Name)
                        {
                            ter.AddSnake(snake);
                        }
                    }

                }
            }
        }

        public void AddTerToList(WaterTerrarium waTer, List<WaterTerrarium> waTerList) //CHANGED LandTerrarium -> Terrarium
        {
            waTerList.Add(waTer);
        }

        public string DisplayTerrarium(List<WaterTerrarium> waTerList)
        {
            Console.WriteLine("Existing Terrariums:");
            foreach (var ter in waTerList)
            {
                Console.WriteLine(ter.ToString());
                Console.WriteLine("-------------------------------");
            }
            return "Done!";
        }

        public WaterTerrarium CreateWaTerrarium(List<WaterTerrarium> waTerList)
        {
            string id = util.IdGenerator();
            List<Snake> snakeList = new List<Snake>();
            WaterTerrarium lanTer = new WaterTerrarium(id, snakeList); //PROBLEM maybe change LandTerrarium to just Terrarium?
            return lanTer;
        }
    }
}
