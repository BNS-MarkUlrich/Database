using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Database
    {
        private List<Faction> _factions;

        public Database()
        {
            _factions = new List<Faction>();
        }

        public void AddItem(Faction faction)
        {
            _factions.Add(faction);
        }

        public Faction[] GetAllItems()
        {
            return _factions.ToArray();
        }
    }
}
