using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    class Program
    {
        static void Main()
        {
            Database database = new Database();
            //Faction human = new Human("Humanoid", "Human");
            //Faction borg = new Faction("Borg");
            //database.AddItem(borg);
            //database.AddItem(human);
            Homeworld earth = new Homeworld();

            foreach(Faction f in database.GetAllItems())
            {
                f.GetUniqueProperties();
            }

            database.GetAllItems();
        }
    }
}