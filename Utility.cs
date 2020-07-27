using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace PA_Test
{
    public class Utility
    {

        public string IdGenerator()
        {

            List<int> szamok = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<string> betu = new List<string> { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "h"};
            List<string> special = new List<string> { "!", "@", "#", "$", "%", "&", "*", "(", ")", "*"};
            Random r = new Random();
            string id = "";
            id += szamok[r.Next(0, 9)] + betu[r.Next(0, 12)] + special[r.Next(0, 9)] + betu[r.Next(0,12)];
            return id;
           
        }

        public string FoodIdGenerator()
        {
            List<int> szamok = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            List<string> betu = new List<string> { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "h"};
            List<string> special = new List<string> { "!", "@", "#", "$", "%", "&", "*", "(", ")", "*" };
            Random r = new Random();
            string id = "";
            id += szamok[r.Next(0, 12)] + betu[r.Next(0, 9)] + special[r.Next(0, 9)] + betu[r.Next(0, 12)];
            return "F" + id;

        }




    }
}
