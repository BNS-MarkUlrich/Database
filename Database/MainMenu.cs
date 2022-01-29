using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class MainMenu : Core
    {
        private MainMenus _mainMenu;
        private FactionCreatorMenus _createFactionMenu;
        private FactionNameMenus _factionNamesMenus;
        private HomeWorldMenus _homeWorldMenus;
        private DatabaseMenus _databaseMenus;
        private FilterMenus _filterMenus;

        private Database database;
        private Faction currentFaction;

        private bool editing;

        private string consoleInput;
        private string savedConsoleInput;

        public MainMenu(Database coreDatabase)
        {
            database = coreDatabase;
            StartUpMenu();
        }

        public void StartUpMenu()
        {
            Console.Title = "Mark's Faction Database";
            Console.WriteLine("Welcome to Mark's Faction Database!");
            Console.WriteLine("\nPress (SPACE) to Continue...");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                StartMenus();
            }
            else
            {
                Console.Clear();
                StartUpMenu();
            }
        }

        public void StartMenus()
        {
            Console.Clear();
            Console.WriteLine("\n---Main Menu--- \n 1. Create Faction \n 2. Access Database \n 3. Exit Program");
            Console.Write("Choose Menu: ");
            consoleInput = Console.ReadLine();
            if (consoleInput == "1" || consoleInput.ToLower() == "Create Faction")
            {
                currentFaction = new Faction();
                _mainMenu = MainMenus.FactionCreationMenu;
                MainMenuFunc();
            }
            else if (consoleInput == "2" || consoleInput.ToLower() == "Access Database")
            {
                _mainMenu = MainMenus.FactionDatabaseMenu;
                MainMenuFunc();
            }
            else if (consoleInput == "3" || consoleInput.ToLower() == "Exit Program")
            {
                _mainMenu = MainMenus.ExitProgramMenu;
                MainMenuFunc();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                StartMenus();
            }
        }

        public void MainMenuFunc()
        {
            switch (_mainMenu)
            {
                case MainMenus.FactionCreationMenu:
                    Console.Clear();
                    currentFaction.GetAllFactionInfo();
                    Console.Write("\n---Faction Editor--- \n1. Set Faction Type \n2. Set Appearance Type \n3. Set Faction Names \n4. Set HomeWorld \n5. Set Description \n6. Save Faction \n7. <--Back \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetFactionTypeMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "2")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetAppearanceTypeMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "3")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetFactionNameMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "4")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetHomeWorldMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "5")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetDescriptionMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "6")
                    {
                        _createFactionMenu = FactionCreatorMenus.SaveFactionMenu;
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "7")
                    {
                        currentFaction.SetDescription(savedConsoleInput);
                        StartMenus();
                    }
                    else
                    {
                        MainMenuFunc();
                    }
                    break;
                case MainMenus.FactionDatabaseMenu:
                    Console.Clear();
                    editing = false;
                    Console.Write("\n---Faction Database--- \n1. Search Engine \n2. <--Back\n\nFactions:\n");
                    ListAllFactions(3);
                    Console.Write("\nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _databaseMenus = DatabaseMenus.DatabaseSearchEngine;
                        DatabaseEngine();
                    }
                    else if (consoleInput == "2")
                    {
                        StartMenus();
                    }
                    else if (Int32.Parse(consoleInput) >= 3)
                    {
                        savedConsoleInput = consoleInput;
                        Console.Clear();
                        currentFaction = database.GetAllFactions()[Int32.Parse(consoleInput) - 3];
                        currentFaction.GetAllFactionInfo();
                        _databaseMenus = DatabaseMenus.FactionOptions;
                        DatabaseEngine();
                    }
                    else
                    {
                        // Reset back to start of Case
                        MainMenuFunc(); // Delete Later
                    }
                    break;
                case MainMenus.ExitProgramMenu:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public void FactionCreationMenu()
        {
            switch (_createFactionMenu)
            {
                case FactionCreatorMenus.SetFactionTypeMenu:
                    Console.Clear();
                    Console.Write("\n---Faction Types Menu--- \n1. Imperialist \n2. Xenoist \n3. Technologist \n4. <--Back \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        currentFaction.SetFactionType(BaseFaction.FactionTypes.Imperialist);
                        MainMenuFunc();
                    }
                    else if (consoleInput == "2")
                    {
                        currentFaction.SetFactionType(BaseFaction.FactionTypes.Xenoist);
                        MainMenuFunc();
                    }
                    else if (consoleInput == "3")
                    {
                        currentFaction.SetFactionType(BaseFaction.FactionTypes.Technologist);
                        MainMenuFunc();
                    }
                    else if (consoleInput == "4")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        FactionCreationMenu();
                    }
                    break;
                case FactionCreatorMenus.SetAppearanceTypeMenu:
                    Console.Clear();
                    Console.Write("\n---Appearances Menu--- \n1. Humanoid \n2. Avian \n3. Machine \n4. <--Back \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        currentFaction.SetAppearance("Humanoid");
                        MainMenuFunc();
                    }
                    else if (consoleInput == "2")
                    {
                        currentFaction.SetAppearance("Avian");
                        MainMenuFunc();
                    }
                    else if (consoleInput == "3")
                    {
                        currentFaction.SetAppearance("Machine");
                        MainMenuFunc();
                    }
                    else if (consoleInput == "4")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        FactionCreationMenu();
                    }
                    break;
                case FactionCreatorMenus.SetFactionNameMenu:
                    Console.Clear();
                    Console.Write("\n---Faction Names Menu--- \n1. Set Species Name \n2. Set Empire Name \n3. <--Back \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _factionNamesMenus = FactionNameMenus.SetSpeciesNameMenu;
                        SetFactionNames();
                    }
                    else if (consoleInput == "2")
                    {
                        _factionNamesMenus = FactionNameMenus.SetEmpireNameMenu;
                        SetFactionNames();
                    }
                    else if (consoleInput == "3")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        FactionCreationMenu();
                    }
                    break;
                case FactionCreatorMenus.SetHomeWorldMenu:
                    Console.Clear();
                    Console.Write("\n---HomeWorld Menu--- \n1. Set HomeWorld Type \n2. Set HomeWorld Name \n3. <--Back \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _homeWorldMenus = HomeWorldMenus.SetHomeWorldTypeMenu;
                        SetHomeWorld();
                    }
                    else if (consoleInput == "2")
                    {
                        _homeWorldMenus = HomeWorldMenus.SetHomeWorldNameMenu;
                        SetHomeWorld();
                    }
                    else if (consoleInput == "3")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        FactionCreationMenu();
                    }
                    break;
                case FactionCreatorMenus.SetDescriptionMenu:
                    Console.Clear();
                    Console.Write("\n---Description Menu--- \n1. <--Back \nEnter Description: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        savedConsoleInput = currentFaction.GetDescription();
                        currentFaction.SetDescription(consoleInput);
                        MainMenuFunc();
                    }
                    break;
                case FactionCreatorMenus.SaveFactionMenu:
                    if (currentFaction.GetEmpireName() == null)
                    {
                        Console.WriteLine("Save Faction " + "Unnamed Empire" + "? y/n");
                    }
                    else
                    {
                        Console.WriteLine("Save Faction " + currentFaction.GetEmpireName() + "? y/n");
                    }
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "y")
                    {
                        if (editing == false)
                        {
                            database.AddFaction(currentFaction);
                            StartMenus();
                        }
                        else
                        {
                            StartMenus();
                        }
                    }
                    else if (consoleInput == "n")
                    {
                        currentFaction.SetDescription(savedConsoleInput);
                        MainMenuFunc();
                    }
                    else
                    {
                        FactionCreationMenu();
                    }
                    break;
                default:
                    break;
            }
        }
        
        public void SetFactionNames()
        {
            switch (_factionNamesMenus)
            {
                case FactionNameMenus.SetSpeciesNameMenu:
                    Console.Clear();
                    Console.Write("\n---Species Name Menu--- \n1. <--Back \nEnter Species Name: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        FactionCreationMenu();
                    }
                    else
                    {
                        currentFaction.SetSpeciesName(consoleInput);
                        /*if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }*/
                        FactionCreationMenu();
                    }
                    break;
                case FactionNameMenus.SetEmpireNameMenu:
                    Console.Clear();
                    Console.Write("\n---Empire Name Menu--- \n1. <--Back \nEnter Empire Name: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        FactionCreationMenu();
                    }
                    else
                    {
                        currentFaction.SetEmpireName(consoleInput);
                        /*if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }*/
                        FactionCreationMenu();
                    }
                    break;
                default:
                    break;
            }
        }

        public void SetHomeWorld()
        {
            switch (_homeWorldMenus)
            {
                case HomeWorldMenus.SetHomeWorldTypeMenu:
                    Console.Clear();
                    Console.Write("\n---HomeWorld Type Menu--- \n1. Continental \n2. Arid \n3. Ocean \n4. Ecumenopolis World \n5. <--Back \nChoose HomeWorld Type: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        currentFaction.SetHomeWorldType("Continental");
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "2")
                    {
                        currentFaction.SetHomeWorldType("Arid");
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "3")
                    {
                        currentFaction.SetHomeWorldType("Ocean");
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "4")
                    {
                        currentFaction.SetHomeWorldType("Ecumenopolis");
                        FactionCreationMenu();
                    }
                    else if (consoleInput == "5")
                    {
                        FactionCreationMenu();
                    }
                    else
                    {
                        SetHomeWorld();
                    }
                    break;
                case HomeWorldMenus.SetHomeWorldNameMenu:
                    Console.Clear();
                    Console.Write("\n---HomeWorld Name Menu--- \n1. <--Back \nEnter HomeWorld Name: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        FactionCreationMenu();
                    }
                    else
                    {
                        currentFaction.SetHomeWorldName(consoleInput);
                        /*if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }*/
                        FactionCreationMenu();
                    }
                    break;
                default:
                    break;
            }
        }

        public void DatabaseEngine()
        {   
            switch (_databaseMenus)
            {
                case DatabaseMenus.DatabaseSearchEngine:
                    Console.Clear();
                    Console.WriteLine("\n---Database Search Engine---");
                    ShowFilters();
                    Console.Write("\n1. Filters\n2. Search\n3. Clear Filters\n4. <--Back\nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                        DatabaseEngine();
                    }
                    else if (consoleInput == "2")
                    {
                        // Implement Search Results
                        Console.Clear();
                        Console.Write("\n---Showing Search Results---\n");
                        ShowFilters();
                        Console.Write("\n1. <--Back\n");
                        ShowSearchResults();
                        Console.Write("Choose Option: ");
                        consoleInput = Console.ReadLine();
                        if (Int32.Parse(consoleInput) >= 2)
                        {
                            savedConsoleInput = consoleInput;
                            Console.Clear();
                            currentFaction = database.GetAllFactions()[Int32.Parse(consoleInput) - 2];
                            currentFaction.GetAllFactionInfo();
                            _databaseMenus = DatabaseMenus.FactionOptions;
                            DatabaseEngine();
                        }
                        else
                        {
                            DatabaseEngine();
                        }
                    }
                    else if (consoleInput == "3")
                    {
                        database.ClearFilters();
                        DatabaseEngine();
                    }
                    else if (consoleInput == "4")
                    {
                        database.ClearFilters();
                        MainMenuFunc();
                    }
                    else
                    {
                        DatabaseEngine();
                    }
                    break;
                case DatabaseMenus.FactionOptions:
                    Console.Write("\n1. Edit Faction\n2. Remove Faction\n3. <--Back\nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        editing = true;
                        _mainMenu = MainMenus.FactionCreationMenu;
                        MainMenuFunc();
                    }
                    else if (consoleInput == "2")
                    {
                        Console.Write("Are you sure? y/n\n");
                        consoleInput = Console.ReadLine();
                        if (consoleInput == "y")
                        {
                            database.RemoveFaction(currentFaction);
                            MainMenuFunc();
                        }
                        else
                        {
                            Console.Clear();
                            currentFaction = database.GetAllFactions()[Int32.Parse(savedConsoleInput) - 3];
                            currentFaction.GetAllFactionInfo();
                            _databaseMenus = DatabaseMenus.FactionOptions;
                            DatabaseEngine();
                        }
                    }
                    else if (consoleInput == "3")
                    {
                        MainMenuFunc();
                    }
                    else
                    {
                        DatabaseEngine();
                    }
                    break;
                case DatabaseMenus.DatabaseSearchEngineFilters:
                    Console.Clear();
                    Console.WriteLine("\n---Filters Menu---");
                    Console.Write("1. " + database.filterMenus[0] + "\n2. " + database.filterMenus[1] + "\n3. " + database.filterMenus[2] + "\n4. <--Back\nChoose Filter Type: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        ChooseFactionTypeFilter();
                    }
                    else if (consoleInput == "2")
                    {
                        ChooseAppearanceTypeFilter();
                    }
                    else if (consoleInput == "3")
                    {
                        ChooseHomeWorldType();
                    }
                    else if (consoleInput == "4")
                    {
                        _databaseMenus = DatabaseMenus.DatabaseSearchEngine;
                        DatabaseEngine();
                    }
                    else
                    {
                        DatabaseEngine();
                    }
                    break;
                default:
                    break;
            }
        }

        public void ListAllFactions(int startListNumberAtValue)
        {
            int i = 0;
            for (i = 0; i < database.GetAllFactions().Length; i++)
            {
                ListFactionsInRange(startListNumberAtValue, i);
            }
        }

        public void ListFactionsInRange(int startListNumberAtValue, int IndexNumber)
        {
            if (database.GetAllFactions()[IndexNumber]._empireName == null)
            {
                Console.WriteLine((IndexNumber + startListNumberAtValue) + ". " + "Unnamed Emprire" + "(" + IndexNumber + ")");
            }
            else
            {
                Console.WriteLine((IndexNumber + startListNumberAtValue) + ". " + database.GetAllFactions()[IndexNumber]._empireName);
            }
        }

        public void ShowSearchResults()
        {
            int f = 0;
            database.GetDatabaseFilters();
            if (database.GetDatabaseFilters().Count >= 4)
            {
                foreach (Faction faction in database.GetAllFactions())
                {
                    bool containtsFactionType = database.GetDatabaseFilters().Contains(faction.GetFactionType().ToString());
                    bool containsAppearance = database.GetDatabaseFilters().Contains(faction.GetAppearance().ToString());
                    bool containsHomeWorldType = database.GetDatabaseFilters().Contains(faction.GetHomeWorldType().ToString());
                    if (containtsFactionType && containsAppearance && containsHomeWorldType)
                    {
                        if (faction._empireName == null)
                        {
                            Console.WriteLine((f + 2) + ". " + "Unnamed Emprire" + "(" + f + ")");
                            f++;
                        }
                        else
                        {
                            Console.WriteLine((f + 2) + ". " + faction._empireName);
                            f++;
                        }
                    }
                }
            }
            else if (database.GetDatabaseFilters().Count == 3)
            {
                foreach (Faction faction in database.GetAllFactions())
                {
                    bool containtsFactionType = database.GetDatabaseFilters().Contains(faction.GetFactionType().ToString());
                    bool containsAppearance = database.GetDatabaseFilters().Contains(faction.GetAppearance().ToString());
                    bool containsHomeWorldType = database.GetDatabaseFilters().Contains(faction.GetHomeWorldType().ToString());
                    if (containtsFactionType && containsAppearance || containsAppearance && containsHomeWorldType || containsHomeWorldType && containtsFactionType)
                    {
                        if (faction._empireName == null)
                        {
                            Console.WriteLine((f + 2) + ". " + "Unnamed Emprire" + "(" + f + ")");
                            f++;
                        }
                        else
                        {
                            Console.WriteLine((f + 2) + ". " + faction._empireName);
                            f++;
                        }
                    }
                }
            }
            else if (database.GetDatabaseFilters().Count == 2)
            {
                foreach (Faction faction in database.GetAllFactions())
                {
                    bool containtsFactionType = database.GetDatabaseFilters().Contains(faction.GetFactionType().ToString());
                    bool containsAppearance = database.GetDatabaseFilters().Contains(faction.GetAppearance().ToString());
                    bool containsHomeWorldType = database.GetDatabaseFilters().Contains(faction.GetHomeWorldType().ToString());
                    if (containtsFactionType || containsAppearance || containsHomeWorldType)
                    {
                        if (faction._empireName == null)
                        {
                            Console.WriteLine((f + 2) + ". " + "Unnamed Emprire" + "(" + f + ")");
                            f++;
                        }
                        else
                        {
                            Console.WriteLine((f + 2) + ". " + faction._empireName);
                            f++;
                        }
                    }
                }
            }
        }

        public void ShowFilters()
        {
            Console.Write("Current Filters: ");
            if (database.GetDatabaseFilters().Count == 1)
            {
                Console.Write(database.GetDatabaseFilters()[0]);
            }
            else
            {
                for (int i = 1; i < database.GetDatabaseFilters().Count; i++)
                {
                    if (i < database.GetDatabaseFilters().Count - 1)
                    {
                        Console.Write(database.GetDatabaseFilters()[i] + " - ");
                    }
                    else
                    {
                        Console.Write(database.GetDatabaseFilters()[i]);
                    }
                }
            }
        }

        public void ChooseFactionTypeFilter()
        {
            Console.Clear();
            Console.WriteLine("\n---" + database.filterMenus[0] + "---");
            for (int i = 0; i < database.factionTypeFilter.Count; i++)
            {
                if (database.factionTypeFilter[i].Contains(database.factionTypeFilter[i]))
                {
                    database.RemoveFilter(database.factionTypeFilter[i]);
                }
                Console.WriteLine(i + 1 + ". " + database.factionTypeFilter[i]);
                if (i + 1 >= database.factionTypeFilter.Count)
                {
                    Console.WriteLine(i + 2 + ". <--Back");
                    Console.Write("Choose Filter: ");
                }
            }
            consoleInput = Console.ReadLine();
            if (consoleInput == "1")
            {
                database.AddFilter(database.factionTypeFilter[0]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "2")
            {
                database.AddFilter(database.factionTypeFilter[1]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "3")
            {
                database.AddFilter(database.factionTypeFilter[2]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "4")
            {
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else
            {
                ChooseFactionTypeFilter();
            }
        }

        public void ChooseAppearanceTypeFilter()
        {
            Console.Clear();
            Console.WriteLine("\n---" + database.filterMenus[1] + "---");
            for (int i = 0; i < database.appearanceFilter.Count; i++)
            {
                if (database.appearanceFilter[i].Contains(database.appearanceFilter[i]))
                {
                    database.RemoveFilter(database.appearanceFilter[i]);
                }
                Console.WriteLine(i + 1 + ". " + database.appearanceFilter[i]);
                if (i + 1 >= database.appearanceFilter.Count)
                {
                    Console.WriteLine(i + 2 + ". <--Back");
                    Console.Write("Choose Filter: ");
                }
            }
            consoleInput = Console.ReadLine();
            if (consoleInput == "1")
            {
                database.AddFilter(database.appearanceFilter[0]);
                database.RemoveFilter(database.appearanceFilter[1]);
                database.RemoveFilter(database.appearanceFilter[2]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "2")
            {
                database.AddFilter(database.appearanceFilter[1]);
                database.RemoveFilter(database.appearanceFilter[0]);
                database.RemoveFilter(database.appearanceFilter[2]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "3")
            {
                database.AddFilter(database.appearanceFilter[2]);
                database.RemoveFilter(database.appearanceFilter[0]);
                database.RemoveFilter(database.appearanceFilter[1]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "4")
            {
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else
            {
                ChooseAppearanceTypeFilter();
            }
        }

        public void ChooseHomeWorldType()
        {
            Console.Clear();
            Console.WriteLine("\n---" + database.filterMenus[2] + "---");
            for (int i = 0; i < database.homeWorldTypeFilter.Count; i++)
            {
                if (database.homeWorldTypeFilter[i].Contains(database.homeWorldTypeFilter[i]))
                {
                    database.RemoveFilter(database.homeWorldTypeFilter[i]);
                }
                Console.WriteLine(i + 1 + ". " + database.homeWorldTypeFilter[i]);
                if (i + 1 >= database.homeWorldTypeFilter.Count)
                {
                    Console.WriteLine(i + 2 + ". <--Back");
                    Console.Write("Choose Filter: ");
                }
            }
            consoleInput = Console.ReadLine();
            if (consoleInput == "1")
            {
                database.AddFilter(database.homeWorldTypeFilter[0]);
                database.RemoveFilter(database.homeWorldTypeFilter[1]);
                database.RemoveFilter(database.homeWorldTypeFilter[2]);
                database.RemoveFilter(database.homeWorldTypeFilter[3]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "2")
            {
                database.AddFilter(database.homeWorldTypeFilter[1]);
                database.RemoveFilter(database.homeWorldTypeFilter[0]);
                database.RemoveFilter(database.homeWorldTypeFilter[2]);
                database.RemoveFilter(database.homeWorldTypeFilter[3]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "3")
            {
                database.AddFilter(database.homeWorldTypeFilter[2]);
                database.RemoveFilter(database.homeWorldTypeFilter[0]);
                database.RemoveFilter(database.homeWorldTypeFilter[1]);
                database.RemoveFilter(database.homeWorldTypeFilter[3]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "4")
            {
                database.AddFilter(database.homeWorldTypeFilter[3]);
                database.RemoveFilter(database.homeWorldTypeFilter[0]);
                database.RemoveFilter(database.homeWorldTypeFilter[1]);
                database.RemoveFilter(database.homeWorldTypeFilter[2]);
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else if (consoleInput == "5")
            {
                _databaseMenus = DatabaseMenus.DatabaseSearchEngineFilters;
                DatabaseEngine();
            }
            else
            {
                ChooseAppearanceTypeFilter();
            }
        }


        public enum MainMenus
        {
            FactionCreationMenu,
            FactionDatabaseMenu,
            ExitProgramMenu,
        }
        public enum FactionCreatorMenus
        {
            SetFactionTypeMenu,
            SetAppearanceTypeMenu,
            SetFactionNameMenu,
            SetHomeWorldMenu,
            SetDescriptionMenu,
            SaveFactionMenu
        }
        public enum FactionNameMenus
        {
            SetSpeciesNameMenu,
            SetEmpireNameMenu,
        }
        public enum HomeWorldMenus
        {
            SetHomeWorldTypeMenu,
            SetHomeWorldNameMenu
        }
        public enum DatabaseMenus
        {
            DatabaseSearchEngine,
            FactionOptions,
            DatabaseSearchEngineFilters
        }
        public enum FilterMenus
        {
            FactionTypeFilterMenu,
            AppearanceTypeFilterMenu,
            HomeWorldTypeFilterMenu
        }
    }
}