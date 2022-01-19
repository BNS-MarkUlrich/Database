using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Homeworld
    {
        public string homeWorldType { get; private set; }
        public string homeWorldName { get; private set; }

        public Homeworld()
        {
            ChooseHomeWorldType();
        }

        public void ChooseHomeWorldType()
        {
            Console.WriteLine("Choose Homeworld Type: \n1. Continental\n2. Arid\n3. Ocean");
            homeWorldType = Console.ReadLine();
            if (homeWorldType == "1" || homeWorldType.ToLower() == "continental")
            {
                homeWorldType = "Continental";
                ChooseHomeWorldName();
            }
            else if (homeWorldType == "2" || homeWorldType.ToLower() == "arid")
            {
                homeWorldType = "Arid";
                ChooseHomeWorldName();
            }
            else if (homeWorldType == "3" || homeWorldType.ToLower() == "ocean")
            {
                homeWorldType = "Ocean";
                ChooseHomeWorldName();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                ChooseHomeWorldType();
            }
        }
        public void ChooseHomeWorldName()
        {
            Console.WriteLine("Choose Homeworld Name: ");
            homeWorldName = Console.ReadLine();
            if (homeWorldName == "")
            {
                Console.WriteLine("Home of the " + "Human");
            }
        }
    }
}