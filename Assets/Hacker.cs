using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game config data
    string[] level1Passwords = { "seat", "quiet", "books", "return", "cart" };
    string[] level2Passwords = { "prisoner", "password", "fucker", "wallet", "handcuff" };
    string[] level3Passwords = { "thermonuclear", "aerodynamics", "supercomputer", "telescope", "nebula" };
    enum Screen { MainMenu, Password, Win };


    // Stuff that changes
    Screen currentScreen;
    int level;
    string password;

    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();

	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        level = 0;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to terminal hacker\nVersion 1.337\n");
        Terminal.WriteLine("You may type reset to return to this screen at any time.\nYou may also type quit to exit the game.\n");


        Terminal.WriteLine("Select your target:");
        Terminal.WriteLine("1. The Rock Springs public library");
        Terminal.WriteLine("2. The Rock Springs police.");
        Terminal.WriteLine("3. The National Aeronautics and Space Agency. (NASA)\n");

        Terminal.WriteLine("Enter your selection: ");
        
    }

    void RunInMainMenu(string input)
    {
        bool isValidLevel = (input == "1" || input == "2" || input == "3");
        if (isValidLevel)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please select a valid level.");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;

        Terminal.ClearScreen();

        GeneratePassword();

        Terminal.WriteLine("Hint: " + password.Anagram());
        Terminal.WriteLine("Hack the password and enter it here: ");
    }

    void GeneratePassword()
    {
        int index;
        switch (level)
        {
            case 1:
                index = UnityEngine.Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index];
                break;

            case 2:
                index = UnityEngine.Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index];
                break;

            case 3:
                index = UnityEngine.Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index];
                break;
            default:
                Debug.LogError("Invalid level number. Seeing this means you broke the matrix. Well done moron.");
                break;
        }
    }

    void OnUserInput(string input)
    {
        CheckInput(input);
    }

    void CheckInput(string input)
    {
        if (input == "reset" || input == "Reset")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "Quit")
        {
            Application.Quit();
        }
        else if (input == "credits" || input == "Credits")
        {
            Terminal.ClearScreen();
            Terminal.WriteLine("Terminal Hacker was made by Kaden Patton");
            Terminal.WriteLine("Some assets imported from Ben Tristem\n");
            Terminal.WriteLine("Thank you for playing my game!\nType reset to go back to the main menu!");
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunInMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            GuessPassword(input);
        }
    }

    void GuessPassword(string input)
    {
        if(input == password)
        {
            ShowLevelReward();
            Terminal.WriteLine("\nEnter the reset command to re-scramble the passwords and play again");
        }
        else
        {
            AskForPassword();
        }
    }

    //void DisplayWinScreen()
    //{

    //    ShowLevelReward();

    //}

    void ShowLevelReward()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();

        switch (level)
        {
            case 1:
                Terminal.WriteLine("Good job! Unlimited knowledge awaits you...");
                Terminal.WriteLine(@"
      __..._   _...__
 _..-^      `Y`      ^-._
\ Once upon |           /
\\  a time..|          //
\\\         |         ///
\\\ _..-- -.|.-- -.._ ///
\\`_..-- -.Y.-- -.._`//             
");     
                break;

            case 2:
                Terminal.WriteLine("Opening all cell doors...");
                Terminal.WriteLine(@"
     OOOOOOOOOOOOOOOOOOOOOOO 
   _|_                     _|_ 
  / @ \        _          / @ \
 //---\\      ( )        //---\\
((     ))      T        ((     ))
 \\___//       |         \\___//
  '---'        |E         '---'
");
                break;

            case 3:
                Terminal.WriteLine("Houston, we have a problem...");
                Terminal.WriteLine(@"
                           *     .--.
                                / /  `
               +               | |
                      '         \ \__,
                  *          +   '--'  *
                      +   /\
         +              .'  '.   *
                *      /======\      +
                      ;:.  _   ;
                      |:. (_)  |
                      |:.  _   |
            +         |:. (_)  |          *
                      ;:.      ;
                    .' \:.    / `.
                   / .-'':._.'`-. \
                   |/    /||\    \|
                 _..--`````````--.._
           _.- ^``                    ``^ -._
         - ^                                ^ -
");
                break;

            default:
                Debug.LogError("Impossible level number accessed. What the fuck.");
                break;
        }
    }



} // End of class
