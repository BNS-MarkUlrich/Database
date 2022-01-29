using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class MainMenu : Core
    {
        private MainMenus _mainMenu;
        private FactionCreatorMenus _createFactionMenu;
        private FactionNameMenus _setFactionNamesMenu;
        private HomeWorldMenus _setHomeWorldMenu;
        private DatabaseMenus _setDatabaseMenu;

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
                    Console.Write("\n---Faction Database--- \n1. Add Filter \n2. Back To Main Menu\n");
                    int i = 0;
                    for (i = 0; i < database.GetAllItems().Length; i++)
                    {
                        if (database.GetAllItems()[i]._empireName == null)
                        {
                            Console.WriteLine((i + 3) + ". " + "Unnamed Emprire" + "(" + i + ")");
                        }
                        else
                        {
                            Console.WriteLine((i + 3) + ". " + database.GetAllItems()[i]._empireName);
                        }
                    }
                    Console.Write("Choose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _setDatabaseMenu = DatabaseMenus.DatabaseSearchEngine;
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
                        currentFaction = database.GetAllItems()[Int32.Parse(consoleInput) - 3];
                        currentFaction.GetAllFactionInfo();
                        _setDatabaseMenu = DatabaseMenus.FactionOptions;
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
                        _setFactionNamesMenu = FactionNameMenus.SetSpeciesNameMenu;
                        SetFactionNames();
                    }
                    else if (consoleInput == "2")
                    {
                        _setFactionNamesMenu = FactionNameMenus.SetEmpireNameMenu;
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
                        _setHomeWorldMenu = HomeWorldMenus.SetHomeWorldTypeMenu;
                        SetHomeWorld();
                    }
                    else if (consoleInput == "2")
                    {
                        _setHomeWorldMenu = HomeWorldMenus.SetHomeWorldNameMenu;
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
                        currentFaction.SetDescription(consoleInput);
                        /*if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {

                        }*/
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
            switch (_setFactionNamesMenu)
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
            switch (_setHomeWorldMenu)
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
            switch (_setDatabaseMenu)
            {
                case DatabaseMenus.DatabaseSearchEngine:
                    // Implement DatabaseSearchEngine
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
                            currentFaction = database.GetAllItems()[Int32.Parse(savedConsoleInput) - 3];
                            currentFaction.GetAllFactionInfo();
                            _setDatabaseMenu = DatabaseMenus.FactionOptions;
                            DatabaseEngine();
                        }
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
                default:
                    break;
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
            FactionOptions
        }
    }
}