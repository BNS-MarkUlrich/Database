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
            Faction human = new Faction();
            human.SetFactionType(BaseFaction.FactionTypes.Technologist);
            human.SetAppearance("Humanoid");
            human.SetEmpireName("Galactic Empire of Humanity");
            human.SetSpeciesName("Human");
            human.SetHomeWorldType("Continental");
            human.SetHomeWorldName("Earth");
            human.SetDescription("Humans rule.");
            database.AddFaction(human);

            Faction turian = new Faction();
            turian.SetFactionType(BaseFaction.FactionTypes.Imperialist);
            turian.SetAppearance("Avian");
            turian.SetEmpireName("Turian Hierachy");
            turian.SetSpeciesName("Turian");
            turian.SetHomeWorldType("Ecumenopolis");
            turian.SetHomeWorldName("Palaven");
            turian.SetDescription("Turians are spikey aliens.");
            database.AddFaction(turian);

            Faction asari = new Faction();
            asari.SetFactionType(BaseFaction.FactionTypes.Xenoist);
            asari.SetAppearance("Humanoid");
            asari.SetEmpireName("Asari Alliance");
            asari.SetSpeciesName("Asari");
            asari.SetHomeWorldType("Ecumenopolis");
            asari.SetHomeWorldName("Thessia");
            asari.SetDescription("Asari are all-female blue aliens");
            database.AddFaction(asari);

            Faction geth = new Faction();
            geth.SetFactionType(BaseFaction.FactionTypes.Technologist);
            geth.SetAppearance("Machine");
            geth.SetEmpireName("The Geth");
            geth.SetSpeciesName("Geth");
            geth.SetHomeWorldType("Arid");
            geth.SetHomeWorldName("Rannoch");
            geth.SetDescription("Geth are a machine race once created by the Quarians. They have since revolted and taken controls of the Quarian homeworld Rannoch");
            database.AddFaction(geth);
            //!Test Factions, Delete Later

            //!Instantiate Variables END

            //Instantiate Menu
            MainMenu mainMenu = new MainMenu(database);
            //!Instantiate Menu
        }
    }
}