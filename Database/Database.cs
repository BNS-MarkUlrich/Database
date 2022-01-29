using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    /// <summary>
    /// Keeps the Faction information and allows adding, editing and removing of Factions.
    ///     <para>
    ///         <description>Member Variables:</description>
    ///     </para>
    ///     <list type="bullet">
    ///         <item>
    ///             <term>_factions</term>
    ///             <description>Contains a list of factions</description>
    ///         </item>
    ///     </list>
    /// </summary>
    public class Database
    {
        private List<Faction> factions;

        public List<string> factionTypeFilter;
        public List<string> appearanceFilter;
        public List<string> homeWorldTypeFilter;
        public List<string> filterMenus;
        private List<string> databaseFilters;

        /// <summary>
        /// Instantiates a new Database.
        /// </summary>
        public Database()
        {
            factions = new List<Faction>();
            factionTypeFilter = new List<string>();
            appearanceFilter = new List<string>();
            //speciesNameFilter = new List<string>();
            //EmpireNameFilter = new List<string>();
            homeWorldTypeFilter = new List<string>();
            //homeWorldNameFilter = new List<string>();
            filterMenus = new List<string>();
            databaseFilters = new List<string>();

            filterMenus.Add("Faction Type Filters");
            filterMenus.Add("Appearance Type Filters");
            filterMenus.Add("HomeWorld Type Filters");

            databaseFilters.Add("None");

            factionTypeFilter.Add("Imperialist");
            factionTypeFilter.Add("Xenoist");
            factionTypeFilter.Add("Technologist");

            appearanceFilter.Add("Humanoid");
            appearanceFilter.Add("Avian");
            appearanceFilter.Add("Machine");

            homeWorldTypeFilter.Add("Continental");
            homeWorldTypeFilter.Add("Arid");
            homeWorldTypeFilter.Add("Ocean");
            homeWorldTypeFilter.Add("Ecumenopolis");
        }

        /// <summary>
        /// Add a Faction to the Database.
        /// </summary>
        public void AddFaction(Faction aFaction)
        {
            factions.Add(aFaction);
        }

        /// <summary>
        /// Remove a Faction from the Database.
        /// </summary>
        public void RemoveFaction(Faction aFaction)
        {
            factions.Remove(aFaction);
        }

        /// <returns>All Factions in the Database.</returns>
        public Faction[] GetAllFactions()
        {
            return factions.ToArray();
        }

        public List<string> GetDatabaseFilters()
        {
            return databaseFilters;
        }

        public void AddFilter(string aFilter)
        {
            databaseFilters.Add(aFilter);
        }
        public void RemoveFilter(string aFilter)
        {
            databaseFilters.Remove(aFilter);
        }
        public void ClearFilters()
        {
            databaseFilters.RemoveRange(1, databaseFilters.Count-1);
        }
    }
}