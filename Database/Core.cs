using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    /// <summary>
    /// This class will instantiate all the necessary variables before the MainMenu is started. Is called in Program.Main.
    /// </summary>
    public class Core
    {
        private Database database;

        public void InstantiateCore()
        {
            //Instantiate Variables
            database = new Database();

            //Test Factions, Delete Later
            Faction testFaction = new Faction();
            testFaction.SetFactionType(BaseFaction.FactionTypes.Technologist);
            testFaction.SetAppearance("Humanoid");
            testFaction.SetEmpireName("Galactic Empire of Humanity");
            testFaction.SetSpeciesName("Human");
            testFaction.SetHomeWorldType("Continental");
            testFaction.SetHomeWorldName("Earth");
            testFaction.SetDescription("Humans rule.");


            database.AddFaction(testFaction);
            //!Test Factions, Delete Later

            //!Instantiate Variables END

            //Instantiate Menu
            MainMenu mainMenu = new MainMenu(database);
            //!Instantiate Menu
        }
    }
}