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
    public abstract class BaseFaction
    {
        public FactionTypes _factionType;// { get; protected set; }
        public Appearance _appearance;// { get; protected set; }
        public string _speciesName;// { get; protected set; }
        public string _empireName;// { get; protected set; }
        public string homeWorldType;// { get; protected set; }
        public string homeWorldName;// { get; protected set; }
        public string _description;// { get; protected set; }

        public abstract void CreateFaction();

        public BaseFaction(FactionTypes thisFactionType)
        {
            _factionType = thisFactionType;
        }

        public enum FactionTypes
        {
            IMPERIALIST,
            XENOIST,
            TECHNOLOGIST
        }
    }
}