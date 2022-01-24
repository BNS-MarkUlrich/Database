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

        /// <summary>
        /// Instantiates a new list of Factions.
        /// </summary>
        public Database()
        {
            factions = new List<Faction>();
        }

        /// <summary>
        /// Allows you to add new Factions to the list.
        /// </summary>
        public void AddFaction(Faction aFaction)
        {
            factions.Add(aFaction);
        }

        /// <returns>All items in the list.</returns>
        public Faction[] GetAllItems()
        {
            return factions.ToArray();
        }
    }
}