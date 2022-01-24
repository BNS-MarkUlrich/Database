using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class MainMenu
    {
        private MainMenus _mainMenu;
        private FactionCreatorMenus _createFactionMenu;
        private FactionNameMenus _setFactionNamesMenu;
        private HomeWorldMenus _setHomeWorldMenu;
        private DatabaseMenus _databaseMenu;

        private Database database;
        private string consoleInput;

        public MainMenu()
        {
            StartUpMenu();
        }

        public void StartUpMenu()
        {
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
                    Console.Write("\n---Faction Creator Menu--- \n1. Set Faction Type \n2. Set Appearance Type \n3. Set Faction Names \n4. Set HomeWorld \n5. Set Description \n6. Save Faction \n7. Back To Main Menu \nChoose Option: ");
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
                    database = new Database();
                    Faction testFaction = new Faction(BaseFaction.FactionTypes.IMPERIALIST);
                    Faction testFaction1 = new Faction(BaseFaction.FactionTypes.TECHNOLOGIST);
                    testFaction._empireName = "Galactic Empire of Humanity";
                    testFaction._speciesName = "Human";
                    testFaction.homeWorldType = "Continental";
                    testFaction.homeWorldName = "Earth";
                    testFaction._description = "Humans rule.";
                    testFaction1._empireName = "Test Empire1";
                    database.AddFaction(testFaction);
                    database.AddFaction(testFaction1);
                    Console.Write("\n---Faction Database--- \n1. Add Filter \n2. Back To Main Menu\n");
                    int i = 0;
                    for (i = 0; i < database.GetAllItems().Length; i++)
                    {
                        Console.WriteLine((i+3) + ". " + database.GetAllItems()[i]._empireName);
                    }
                    Console.Write("Choose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _databaseMenu = DatabaseMenus.AddFilterMenu;
                        // Create Database Function
                    }
                    else if (consoleInput == "2")
                    {
                        StartMenus();
                    }
                    else if (Int32.Parse(consoleInput) >= 3)
                    {
                        Console.Clear();
                        Console.WriteLine("---" + database.GetAllItems()[Int32.Parse(consoleInput) - 3]._empireName + "---");
                        Console.WriteLine("Species Name: " + database.GetAllItems()[Int32.Parse(consoleInput) - 3]._speciesName);
                        //Console.WriteLine("Appearance Type: " + database.GetAllItems()[Int32.Parse(consoleInput)-3]._appearance.ToString());
                        Console.WriteLine("Faction Type: " + database.GetAllItems()[Int32.Parse(consoleInput) - 3]._factionType.ToString());
                        Console.WriteLine("World Type: " + database.GetAllItems()[Int32.Parse(consoleInput) - 3].homeWorldType);
                        Console.WriteLine("World Name: " + database.GetAllItems()[Int32.Parse(consoleInput) - 3].homeWorldName);
                        Console.WriteLine("Description: " + database.GetAllItems()[Int32.Parse(consoleInput) - 3]._description);
                        Console.Write("\nGo Back To Database? y/n \n");
                        consoleInput = Console.ReadLine();
                        if (consoleInput == "y")
                        {
                            StartMenus();
                        }
                        else
                        {
                            StartMenus();
                        }
                    }
                    else
                    {
                        StartMenus();
                    }
                    break;
                case MainMenus.ExitProgramMenu:
                    // Implement Exit
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
                    // Implement FactionType
                    break;
                case FactionCreatorMenus.SetAppearanceTypeMenu:
                    // Implement Appearance
                    break;
                case FactionCreatorMenus.SetFactionNameMenu:
                    Console.Clear();
                    Console.Write("\n---Faction Names Menu--- \n1. Set Species Name \n2. Set Empire Name \n3. Back To Faction Creation Menus \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _setFactionNamesMenu = FactionNameMenus.SetSpeciesNameMenu;
                    }
                    else if (consoleInput == "2")
                    {
                        _setFactionNamesMenu = FactionNameMenus.SetEmpireNameMenu;
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
                    Console.Write("\n---HomeWorld Menu--- \n1. Set HomeWorld Type \n2. Set HomeWorld Name \n3. Back To Faction Creation Menus \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _setHomeWorldMenu = HomeWorldMenus.SetHomeWorldTypeMenu;
                    }
                    else if (consoleInput == "2")
                    {
                        _setHomeWorldMenu = HomeWorldMenus.SetHomeWorldNameMenu;
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
                    // Implement Description
                    break;
                case FactionCreatorMenus.SaveFactionMenu:
                    // Implement Save
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
            AddFilterMenu
        }
    }
}
