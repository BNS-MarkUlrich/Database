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
        public string _appearance;// { get; protected set; }
        public string _speciesName;// { get; protected set; }
        public string _empireName;// { get; protected set; }
        public string homeWorldType;// { get; protected set; }
        public string homeWorldName;// { get; protected set; }
        public string _description;// { get; protected set; }

        public abstract void SetFactionType(FactionTypes aFactionType);
        public abstract FactionTypes GetFactionType();
        public abstract void SetAppearance(string anAppearance);
        public abstract string GetAppearance();
        public abstract void SetSpeciesName(string aSpeciesName);
        public abstract string GetSpeciesName();
        public abstract void SetEmpireName(string anEmpireName);
        public abstract string GetEmpireName();
        public abstract void SetHomeWorldType(string aHomeWorldType);
        public abstract string GetHomeWorldType();
        public abstract void SetHomeWorldName(string aHomeWorldName);
        public abstract string GetHomeWorldName();
        public abstract void SetDescription(string aDescription);
        public abstract string GetDescription();

        public abstract void GetAllFactionInfo();

        public enum FactionTypes
        {
            Empty,
            Imperialist,
            Xenoist,
            Technologist
        }
        public enum Appearances
        {
            Humanoid,
            Avian,
            Machine,
            Empty
        }
    }
}