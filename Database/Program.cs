using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class Program
    {
        static void Main()
        {
            Core programCore = new Core();
            programCore.InstantiateCore();
            /*Database database = new Database();
            
            Homeworld homeworld = new Homeworld();
            //homeworld.ChooseHomeWorldType();

            Faction faction = new Faction();
            faction.CreateFaction();
            database.AddFaction(faction);

            foreach (Faction f in database.GetAllItems())
            {
                //Console.WriteLine(faction._empireName.ToString());
                //Console.WriteLine(faction._speciesName.ToString());
                //Console.WriteLine(faction._appearance.ToString());
                Console.WriteLine(f._factionType.ToString());
                //Console.WriteLine(f.homeWorldType);
                Console.WriteLine(f.homeWorldName);
                //Console.WriteLine(faction._description.ToString());
            }

            //database.GetAllItems();*/
        }
    }
}