using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class MainMenu
    {
        private MainMenus _mainMenu;
        private FactionCreatorMenus _createFactionMenu;
        private FactionNameMenus _setFactionMenu;
        private HomeWorldMenus _setHomeWorldMenu;
        private DatabaseMenus _databaseMenu;

        private Database database;
        private string consoleInput;

        public MainMenu()
        {
            StartMenu();
        }

        public void StartMenu()
        {
            Console.WriteLine("Welcome to Mark's Faction Database!");
            Console.WriteLine("\nPress (SPACE) to Continue...");
            if (Console.ReadKey().Key == ConsoleKey.Spacebar)
            {
                SetUpMainMenu();
            }
            else
            {
                Console.Clear();
                StartMenu();
            }
        }

        public void SetUpMainMenu()
        {
            Console.Clear();
            Console.WriteLine("\n---Main Menu--- \n 1. Create Faction \n 2. Access Database \n 3. Exit Program");
            Console.Write("Choose Menu: ");
            consoleInput = Console.ReadLine();
            if (consoleInput == "1" || consoleInput.ToLower() == "Create Faction")
            {
                _mainMenu = MainMenus.FactionCreationMenu;
                CreateFactionMenu();
            }
            else if (consoleInput == "2" || consoleInput.ToLower() == "Access Database")
            {
                _mainMenu = MainMenus.FactionDatabaseMenu;
                CreateFactionMenu();
            }
            else if (consoleInput == "3" || consoleInput.ToLower() == "Exit Program")
            {
                _mainMenu = MainMenus.ExitProgramMenu;
                CreateFactionMenu();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                SetUpMainMenu();
            }
        }

        public void CreateFactionMenu()
        {
            switch (_mainMenu)
            {
                case MainMenus.FactionCreationMenu:
                    Console.Clear();
                    Console.Write("\n---Faction Creator Menu--- \n1.Set Faction Type \n2.Set Appearance Type \n3. Set Faction Names \n4. Set HomeWorld \n5. Set Description \n6. Save Faction \n7. Back To Main Menu \nChoose Option: ");
                    consoleInput = Console.ReadLine();
                    if (consoleInput == "1")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetFactionTypeMenu;
                    }
                    else if (consoleInput == "2")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetAppearanceTypeMenu;
                    }
                    else if (consoleInput == "3")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetFactionNameMenu;
                    }
                    else if (consoleInput == "4")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetHomeWorldMenu;
                    }
                    else if (consoleInput == "5")
                    {
                        _createFactionMenu = FactionCreatorMenus.SetDescriptionMenu;
                    }
                    else if (consoleInput == "6")
                    {
                        _createFactionMenu = FactionCreatorMenus.SaveFactionMenu;
                    }
                    else if (consoleInput == "7")
                    {
                        SetUpMainMenu();
                    }
                    break;
                case MainMenus.FactionDatabaseMenu:
                    break;
                case MainMenus.ExitProgramMenu:
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
            SaveFactionMenu,
            BackToCreatorMenu
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
            AddFilterMenu,
            BackToDatabaseMenu
        }
    }
}
