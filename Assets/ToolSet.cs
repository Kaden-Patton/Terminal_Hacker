using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public namespace TS {

    public class Toolset
    {

        public void ShowMainMenu()
        {
                Terminal.ClearScreen();
                Terminal.WriteLine("Welcome to terminal hacker\nVersion 1.337\n");
                Terminal.WriteLine("You may type menu to return to this screen at any time.\nYou may also type quit to exit the game.\n");
                Terminal.WriteLine("This is a work in progress developmental build.");

                Terminal.WriteLine("Type help for a list of commands.");

                Terminal.WriteLine("Enter your selection: ");
        }

        public void CheckInput(string input)
        {
            baseComCheck(input);

            if (ContainCheck(input, "test"))
            {
                //StartCoroutine("testfunc");
                Terminal.ClearScreen();
            }
        }


        //-----------------------------------------
        //
        //
        //
        //
        //             Private Stuff
        //
        //
        //
        //----------------------------------------
        IDictionary<string, string> commands = new Dictionary<string, string>();

        private void AddCommandHelp(string key, string value)
        {
            
            commands.Add(key, value);
        }

        private void RunInMenu()
        {

        }

        private bool ContainCheck(string input, string check)
        {
            if (input.ToLower().Contains(check))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void baseComCheck(string input)
        {
            if (ContainCheck(input, "menu"))
            {
                ShowMainMenu();
            }
            else if (ContainCheck(input, "clear"))
            {
                Terminal.ClearScreen();
            }
            else if (ContainCheck(input, "quit"))
            {
                Application.Quit();
            }
            else if (ContainCheck(input, "credits"))
            {
                Terminal.ClearScreen();
                Terminal.WriteLine("Terminal Hacker was made by Kaden Patton");
                Terminal.WriteLine("Some assets imported from Ben Tristem and various other artists.\n");
                Terminal.WriteLine("Thank you for playing my game!\nType reset to go back to the main menu!");
            }
        }
    }

}