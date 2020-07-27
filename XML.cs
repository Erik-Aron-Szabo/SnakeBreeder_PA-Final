using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace PA_Test
{
    public class XML
    {

        public void WriteToXmlFile(List<Snake> snakes, string filename)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Snake>));

            try
            {
                FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write);
                writer.Serialize(file, snakes);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.ToString() + " " + filename));
            }
        }

        public List<Snake> LoadObjectFromXmlFile(string filename)
        {
            List<Snake> snakes = null;

            try
            {
                StreamReader xmlStream = new StreamReader(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Snake>));
                snakes = (List<Snake>)serializer.Deserialize(xmlStream);
                xmlStream.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine($"Error2 loading {filename}");
            }
            return snakes;
        }
        public void WaterTerWriteToXmlFile(List<WaterTerrarium> waTer, string filename) //serialize Abstracts instead of individual
        {
            //water terrarium
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<WaterTerrarium>));

            try
            {
                FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write); 
                writer.Serialize(file, waTer);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.ToString() + " " + filename));
            }
        }

        public List<WaterTerrarium> WaterTerLoadObjectFromXmlFile(string filename)
        {
            //water terrarium
            List<WaterTerrarium> returnObject = null;

            try
            {
                var xmlStream = new StreamReader(filename);
                var serializer = new XmlSerializer(typeof(List<WaterTerrarium>));
                returnObject = (List<WaterTerrarium>)serializer.Deserialize(xmlStream);
                xmlStream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine($"Error loading water {filename}");
            }
            return returnObject;
        }

        public void LandTerWriteToXmlFile(List<LandTerrarium> landTer, string filename)
        {
            //land terrarium
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(List<LandTerrarium>));

            try
            {
                FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.Write);//PROBLEM 
                writer.Serialize(file, landTer);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.ToString() + " " + filename));
                Console.WriteLine("LandTerrariumXML");
            }

        }



        public List<LandTerrarium> LandTerLoadObjectFromXmlFile(string filename)// sometimes, it changes it to "waterTerrarium" PROBLEM
        {
            //land terrarium
            List<LandTerrarium> returnObject = null;

            try
            {
                var xmlStream = new StreamReader(filename);
                var serializer = new XmlSerializer(typeof(List<LandTerrarium>));
                returnObject = (List<LandTerrarium>)serializer.Deserialize(xmlStream);
                xmlStream.Close();
            }
            catch (Exception)
            {
                Console.WriteLine($"Error loading LAND {filename}");
            }
            return returnObject;
        }

        public void LandToWaterChecker()
        {

        }

       

        public XML()
        {

        }

        public bool IsEmpty(string filename)
        {
            XmlDocument xDoc = new XmlDocument();
            int counter = 0;
            try
            {
                xDoc.Load(filename);
                foreach (var node in xDoc.DocumentElement)
                {
                    counter++;
                    if (counter >= 1)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return true;
            }
            return true;
            
        }
    }
}
