using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public abstract class Faction
    {
        public string _appearance { get; private set; }
        public string name { get; private set; }
       

        public Faction(string anAppearance, string aName)
        {
            this._appearance = anAppearance;
            this.name = aName;
        }

        public abstract void GetUniqueProperties();
    }
}
