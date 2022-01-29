using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class Faction : BaseFaction
    {

        public override void SetAppearance(string anAppearance)
        {
            _appearance = anAppearance;
        }

        public override void SetDescription(string aDescription)
        {
            _description = aDescription;
        }

        public override void SetEmpireName(string anEmpireName)
        {
            _empireName = anEmpireName;
        }

        public override void SetFactionType(FactionTypes aFactionType)
        {
            _factionType = aFactionType;
        }

        public override void SetHomeWorldName(string aHomeWorldName)
        {
            homeWorldName = aHomeWorldName;
        }

        public override void SetHomeWorldType(string aHomeWorldType)
        {
            homeWorldType = aHomeWorldType;
        }

        public override void SetSpeciesName(string aSpeciesName)
        {
            _speciesName = aSpeciesName;
        }

        public override string GetAppearance()
        {
            return _appearance;
        }

        public override string GetDescription()
        {
            return _description;
        }

        public override string GetEmpireName()
        {
            return _empireName;
        }

        public override FactionTypes GetFactionType()
        {
            return _factionType;
        }

        public override string GetHomeWorldName()
        {
            return homeWorldName;
        }

        public override string GetHomeWorldType()
        {
            return homeWorldType;
        }

        public override string GetSpeciesName()
        {
            return _speciesName;
        }

        public override void GetAllFactionInfo()
        {
            if (_empireName == null)
            {
                Console.WriteLine("\n---" + "Unnamed Empire" + "---");
            }
            else
            {
                Console.WriteLine("\n---" + GetEmpireName() + "---");
            }
            Console.WriteLine("Species Name    : " + GetSpeciesName());
            Console.WriteLine("Appearance Type : " + GetAppearance());
            if (_factionType == FactionTypes.Empty)
            {
                Console.WriteLine("Faction Type    : ");
            }
            else
            {
                Console.WriteLine("Faction Type    : " + GetFactionType());
            }
            Console.WriteLine("World Type      : " + GetHomeWorldType());
            Console.WriteLine("World Name      : " + GetHomeWorldName());
            Console.WriteLine("Description     : " + GetDescription());
        }
    }
}