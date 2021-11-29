using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Human : Faction
    {
        private string description;
        private string _homeWorld;
        private string empireName;

        public Human(string anAppearance, string name) : base(anAppearance, name)
        {

        }

        public override void GetUniqueProperties()
        {
            //throw new NotImplementedException();
            description = "description";
            _homeWorld = "Earth";
            empireName = "Galactic Union of Humanity";

            Console.WriteLine("Description: {0}", description);
            Console.WriteLine("Homeworld: {0}", _homeWorld);
            Console.WriteLine("Empire Name: {0}", empireName);
        }
    }
}