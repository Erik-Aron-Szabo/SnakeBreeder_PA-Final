using System;
using System.Collections.Generic;
using System.Text;

namespace PA_Test
{
    [Serializable]
    public abstract class Terrarium
    {
        public string ID { get; set; }
        public List<Snake> SnakeList {get; set;}  // how many snakes can be housed there
        public string Type { get; set; }


        public abstract void AddSnake(Snake snake); //abba a tipusu terrariumba bele lehet e rakni a snake-t (Type alapjan)

        public abstract void DisplayContents();

        public abstract override string ToString();

        public abstract void SnakeChecker(List<Snake> snakeList);

    }
}
