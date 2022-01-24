using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Faction : BaseFaction
    {
        private string _console;
        public override void CreateFaction()
        {
            Console.WriteLine("---Faction Creator---\n1. Militarist\n2. Xenophile\n3. Materialist");
            Console.Write("Choose Faction Type: ");
            _console = Console.ReadLine();
            if (_console == "1" || _console.ToLower() == "militarist")
            {
                _factionType = FactionTypes.IMPERIALIST;
            }
            else if (_console == "2" || _console.ToLower() == "xenophile")
            {
                _factionType = FactionTypes.XENOIST;
            }
            else if (_console == "3" || _console.ToLower() == "materialist")
            {
                _factionType = FactionTypes.TECHNOLOGIST;
            }
            else
            {
                Console.WriteLine("Invalid Input");
                CreateFaction();
            }
        }
    }
}