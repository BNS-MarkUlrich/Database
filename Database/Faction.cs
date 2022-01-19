using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    /// <summary>
    /// Base class for all Factions.
    ///     <para>
    ///         <description>Member Variables:</description>
    ///     </para>
    ///     <list type="bullet">
    ///         <item>
    ///             <term>_name</term>
    ///             <description>Name of the Faction</description>
    ///         </item>
    ///     </list>
    /// </summary>
    public abstract class Faction
    {
        public string _appearance { get; private set; }
        public string speciesName { get; private set; }
        public string empireName { get; private set; }

        /// <summary>
        /// Constructor to set base values for a Faction.
        /// </summary>
        public Faction(string anAppearance, string aName)
        {
            this._appearance = anAppearance;
            this.speciesName = aName;
        }

        public abstract void GetUniqueProperties();
    }
}
