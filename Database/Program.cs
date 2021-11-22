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
            Faction human = new Faction("Human");
            Faction borg = new Faction("Borg");
            database.AddItem(borg);
            database.AddItem(human);
            foreach(Faction f in database.GetAllItems())
            {
                Console.WriteLine("Faction: {0}", f._name);
            }
            database.GetAllItems();
        }
    }
}
