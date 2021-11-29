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
            Faction human = new Human("Humanoid", "Human");
            //Faction borg = new Faction("Borg");
            //database.AddItem(borg);
            database.AddItem(human);

            foreach(Faction f in database.GetAllItems())
            {
                Console.WriteLine("Appearance: {0}", f._appearance);
                Console.WriteLine("Name: {0}", f.name);
                f.GetUniqueProperties();
            }

            database.GetAllItems();
        }
    }
}
