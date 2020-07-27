using System;
using System.Collections.Generic;
using System.Text;

namespace PA_Test
{
    [Serializable]
    public class LandTerrarium : Terrarium
    {
        public override void AddSnake(Snake snake)
        {
            if (snake.Type.ToLower() == "land")
            {
                SnakeList.Add(snake);
            }
            else
            {
                throw new Exception("Unable to add snake to land terrarium!");
            }
        }

        public override void DisplayContents()
        {
            throw new NotImplementedException();
        }

        public LandTerrarium(string id, List<Snake> snakes, string type = "Land")
        {
            ID = id;
            SnakeList = snakes;
            Type = type;
        }

        public LandTerrarium(string id, string type = "Land")
        {
            ID = id;
            Type = type;
        }

        public LandTerrarium()
        {

        }

        public override string ToString()
        {
            string snakes = "";
            foreach (var snake in this.SnakeList)
            {
                snakes += $"Snake's Name: {snake.Name}; Snake's Type: {snake.Type}\n";
            }
            return $"ID: {this.ID}\n{snakes}\nType: {this.Type}\n";
        }
        public override void SnakeChecker(List<Snake> snakeList)
        {
            foreach (var snake in snakeList)
            {
                if (snake.Type != "Land" || snake.Type != "land")
                {
                    Console.WriteLine("Invalid Snake type! (It is not 'land/Land')");
                }
                else
                {
                    this.SnakeList.Add(snake);
                    snakeList.Remove(snake);
                }
            }
        }

    }
}
