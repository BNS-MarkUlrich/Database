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
    class Faction
    {
        public string name;
        
        /// <summary>
        /// Constructor to set base values for a Faction.
        /// </summary>
        public Faction(string aName)
        {
            name = aName;
        }
    }
}
