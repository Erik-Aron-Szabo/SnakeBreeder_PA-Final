using System;
using System.Collections.Generic;
using System.Text;

namespace PA_Test
{
    public class Menu
    {
        public XML theXml = new XML();


        public void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("(1) Water Terrarium Menu");
            Console.WriteLine("(2) Land Terrarium Menu");
            Console.WriteLine("(3) Snakes Menu");
            Console.WriteLine("(4) Exit");
        }


        public string InputHandler(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;
        }

        public List<Snake> CreateSnakeList()
        {
            List<Snake> snakeList2 = new List<Snake>();
            return snakeList2;
        }


        public bool Switch(string choice, List<Snake> snakeList, List<LandTerrarium> lanTerList, List<WaterTerrarium> waTerList, string snakeFilename, string terFilename, string waterFilename) //MISSING waTer
        {
            SnakeMenu snakeMenu = new SnakeMenu();
            WaTerrariumMenu waTerrariumMenu = new WaTerrariumMenu();
            LaTerrariumMenu laTerrariumMenu = new LaTerrariumMenu();
            try
            {
                if (choice == "snake" || choice == "3")
                {

                    snakeMenu.DisplaySnakeMenu();
                    string ui = Console.ReadLine();
                    theXml.WriteToXmlFile(snakeMenu.SnakeSwitch(ui, snakeList,  waTerList, lanTerList, snakeFilename), snakeFilename);
                    return true;
                }
                else if (choice == "land" || choice == "2") //LAND
                {
                    laTerrariumMenu.LaTerrariumMenuDisplay();
                    string ui = Console.ReadLine();
                    theXml.LandTerWriteToXmlFile(laTerrariumMenu.LaTerrariumSwitch(ui, snakeList, snakeFilename,lanTerList, terFilename), terFilename);
                    return true;

                }
                else if (choice == "water" || choice == "1") //WATER
                {
                    waTerrariumMenu.WaTerrariumMenuDisplay();
                    string ui = Console.ReadLine();
                    theXml.WaterTerWriteToXmlFile(waTerrariumMenu.WaTerrariumSwitch(ui, snakeList, snakeFilename, waTerList, waterFilename), waterFilename);
                    return true;

                }
                
                else if (choice == "exit" || choice == "4")
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }



        public Menu()
        {

        }
    }
}
