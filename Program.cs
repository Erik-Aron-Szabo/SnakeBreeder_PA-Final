using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PA_Test
{
    public class Program
    {
        public static void Main(string[] args)
        {

            XML theXml = new XML();
            Utility util = new Utility();
            SnakeMenu snakeMenu = new SnakeMenu();

            List<Snake> snakeList = new List<Snake>();
            List<WaterTerrarium> waTerList = new List<WaterTerrarium>();
            List<LandTerrarium> lanTerList = new List<LandTerrarium>();
            LandTerrarium laTer;
            WaterTerrarium waTer;

            string terFilename = "LandTerrarium.xml";
            string waterFilename = "WaterTerrarium.xml";
            string snakeFilename = "JustSnakes.xml";
            

            if (!File.Exists("LandTerrarium.xml") || theXml.IsEmpty(terFilename))
            {
                laTer = new LandTerrarium(util.IdGenerator(), snakeList);
                lanTerList.Add(laTer);
                theXml.LandTerWriteToXmlFile(lanTerList, terFilename);
            }

            if (!File.Exists("JustSnakes.xml") || theXml.IsEmpty(snakeFilename))
            {
                Console.WriteLine("Please create a Snake first!"); //snake already exists

                snakeMenu.CreateSnake(snakeList);
            }

            if (!File.Exists("WaterTerrarium.xml") || theXml.IsEmpty(waterFilename))
            {
                waTer = new WaterTerrarium(util.IdGenerator(), snakeList);
                waTerList.Add(waTer);
                theXml.WaterTerWriteToXmlFile(waTerList, waterFilename);
            }

            snakeList = theXml.LoadObjectFromXmlFile(snakeFilename);
            waTerList = theXml.WaterTerLoadObjectFromXmlFile(waterFilename);
            lanTerList = theXml.LandTerLoadObjectFromXmlFile(terFilename);


            theXml.WriteToXmlFile(snakeList, snakeFilename);

            Menu mainMenu = new Menu();
            do
            {
                mainMenu.DisplayMainMenu();
                string choice = mainMenu.InputHandler("Type option with lowercase: ");
                if (mainMenu.Switch(choice, snakeList, lanTerList, waTerList, snakeFilename, terFilename, waterFilename))
                {
                    theXml.WaterTerWriteToXmlFile(waTerList, waterFilename);
                    theXml.LandTerWriteToXmlFile(lanTerList, terFilename);
                    theXml.WriteToXmlFile(snakeList, snakeFilename);
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}
