using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Homeworld : Faction
    {
        public Homeworld()
        {
            ChooseHomeWorldType();
        }

        public void ChooseHomeWorldType()
        {
            Console.WriteLine("---HomeWorld Creator---\n1. Continental\n2. Arid\n3. Ocean");
            Console.Write("Choose Homeworld Type: ");
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
            Console.Write("Choose Homeworld Name: ");
            homeWorldName = Console.ReadLine();
            if (homeWorldName == "")
            {
                homeWorldName = "Home of the " + _speciesName;
            }
        }
    }
}