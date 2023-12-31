﻿using DB;
using DigitalGameStore.Browse;
using DigitalGameStore.InterestList;
using DigitalGameStore.RecommendGames;
using DigitalGameStore.UI;

namespace DigitalGameStore.Login;

public class Menu {

    private Context? _context;

    public void MainMenu()
    {

        string additionalText = "(Use the arrows to select an option)";
        string[] menuOptions = { "Browse Games", "Interest list", "Recommendations", "Exit" };
        MenuLogic mainMenu = new MenuLogic(additionalText, menuOptions);

        int selectedIndex = mainMenu.Start();

        switch (selectedIndex)
        {
            case 0:
				BrowseMenu(); // On enter --> Add game to interest list or read more about game or back
				break;
            case 1:
				InterestList(); // Browse your games (edit/delete) --> add more games --> BrowseMenu()
                break;
			case 2:
                RecommendGamesList(); // Browse recommended games --> add to interestlist (Refreshes recommendedgameslist)
				break;
			case 3:
                Environment.Exit(0);
                break;
        }
    }

    public void BrowseMenu()
    {


            BrowseAll listAll = new BrowseAll();

            string prompt = "(Use the arrows to select an option)";
            string[] options = { "All Games", "Previous Menu" };
            MenuLogic mainMenu = new MenuLogic(prompt, options);

            int selectedIndex = mainMenu.Start();

            switch (selectedIndex)
            {

                case 0:
                    Console.WriteLine("Here are all the games: ");
                    listAll.AllGames();
                    break;
                case 1:
                    MainMenu();
                    break;
        }

    }

	public async void InterestList()
	{

		AddGame addGame = new AddGame();
		DeleteGame deleteGame = new DeleteGame();
		DisplayList displayList = new DisplayList();

		string prompt = "(Use the arrows to select an option)";
		string[] options = { "Display List", "Add Interest", "Delete Interest", "Back to main menu" };
		MenuLogic mainMenu = new MenuLogic(prompt, options);

		int selectedIndex = mainMenu.Start();

		switch (selectedIndex)
		{

			case 0:
				Console.WriteLine("Here is your Interest List: ");
				displayList.DisplayIntrests();
				InterestList();
				break;
			case 1:
				Console.WriteLine("What game would you like to add from your interest list?: ");
				int addInput = int.Parse(Func.ReadInput());
				addGame.Add(addInput);
				InterestList();
				break;
			case 2:
				Console.WriteLine("What game would you like to delete from your interest list?: ");
				int deleteInput = int.Parse(Func.ReadInput());
				deleteGame.Delete(deleteInput);
				InterestList();
				break;
			case 3:
				MainMenu();
				break;

		}
	}

	public async void RecommendGamesList()
    {
        InterestAnalyzer userInterest = new InterestAnalyzer();
        GameRecommender gameRecommender = new GameRecommender();

        string prompt = "(Use the arrows to select an option)";
        string[] options = { "Display top 5 recommended list", "Back to main menu" };
        MenuLogic mainMenu = new MenuLogic(prompt, options);

        int selectedIndex = mainMenu.Start();

        switch (selectedIndex)
        {

            case 0:
                Console.WriteLine("Here is your Interest List: ");
                await gameRecommender.RecommendGames(userInterest);
                RecommendGamesList();
                break;
            case 1:
                MainMenu();
                break;

        }
    }

}
