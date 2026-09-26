/*
 * FILE             : Program.cs
 * PROJECT          : Assignment 2
 * PROGRAMMER       : Joshua Ducharme-Baribeau
 * FIRST VERSION    : September 24 2026
 * DESCRIPTION      : C# Source file for "Program.cs" containing "Program" class
 */

namespace A02_OOP_JoshuaYDB
{
    /*
     * NAME     : Program
     * PURPOSE  : This class offers a user a menu with various options that use 
     *          : I/O to control manipulate data within a file
     */
    internal class Program
    {
        static void Main(string[] args)
        {

            Boolean ready = true; //flag for the menu, will terminate the loop when False
            ConsoleKeyInfo user_input; //using the ConsoleKeyInfo object/struct to store the key stroke (See https://learn.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-10.0) 
            
            List<string> saved_text = new List<string>(); //the list in which the user will add text
            
            //loop for main program
            while (ready)
            {
                Display_menu(); //initial menu display

                user_input = Console.ReadKey();
                switch (user_input.Key)
                {
                    case ConsoleKey.A:
                        saved_text = Add_text(saved_text);
                        break;

                    case ConsoleKey.D:
                        Display_data(saved_text);
                        break;

                    case ConsoleKey.R:
                        //foo
                        Clear_screen();
                        break;

                    case ConsoleKey.S:
                        //foo
                        Clear_screen();
                        break;

                    case ConsoleKey.X:
                        ready = false;
                        Clear_screen();
                        break;
                    
                    default:
                        //no menu option selected, display an error
                        Display_error_message();
                        break;

                }
                Console.WriteLine("LAST INPUT:" + user_input.KeyChar + " \n"); //output for debugging purposes
            }

            Console.WriteLine("successfully exited"); //debug line
        
        }


        /*
         * METHOD       : Clear_screen()
         * 
         * DESCRIPTION  : clears the UI (i.e. clears the cli display)
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Clear_screen()
        {
            Console.Clear();
            //no return needed for void return type
        }


        /*
         * METHOD       : Display_menu()
         * 
         * DESCRIPTION  : displays the main menu
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_menu()
        {
            //Main menu's WriteLine. Concatenated for code readability
            Console.WriteLine
                (
                "<A>dd a new line of text data\n" +
                "<D>isplay all the data\n" +
                "<R>emove a line of text data\n" +
                "<S>ave the data to a file\n" +
                "E<X>it the program\n" +
                "Please choose the operation you would like to perform:\n\n"
                );
            
            //no return needed for void return type
        }


        /*
         * METHOD       : Display_error_message()
         * 
         * DESCRIPTION  : displays an informative error message
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_error_message()
        {
            Console.WriteLine("\nAN ERROR HAS OCCURRED\n\n");
            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey(); //readkey to block the program
            Clear_screen();
            //no return needed for void return type
        }


        /*
         * METHOD       : Add_text()
         * 
         * DESCRIPTION  : Adds a string of user inputted text to the list passed in the parameter
         *                and returns the new list. This is preferable than a static list as it
         *                should manage the memory a little better and avoids static variables
         * 
         * PARAMETERS   : List<string> saved_text: (Shadowed name) a list that holds the strings of the user
         * 
         * RETURNS      : List<string> saved_text: (shadowed name) returns the list with the newly added string
         */
        private static List<string> Add_text(List<string> saved_text)
        {
            Clear_screen();
            Boolean invalid_string_flag = true; //flag to denote that the user_string is valid (i.e. not null or empty)

            while(invalid_string_flag)
            {

                //just in time declaration to reset the value of user_string in each loop (in case of invalid input)
                string? user_string; //the '?' of 'string?' allows the string to be null, which allows for the below validation

                Console.WriteLine("Please enter the line of text you would like to add to the list:\n");
                user_string = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(user_string)) //if user_string is null or only whitespace
                {
                    Console.WriteLine("\nThe line of text you enter must not be blank. Press any key to try again...");
                    Console.ReadKey(); //readkey to block the program so the user can read the error
                    Clear_screen();
                    continue; //skips remaining code of the while loop, preferable to an empty if statement
                }
                else //if user_string is not null or only whitespace
                {
                    //add string to the list
                    saved_text.Add(user_string);
                    invalid_string_flag = false; //string is valid, changes flag to false to exit loop
                }

            }

            Console.WriteLine("\nText added successfully, press any key to continue...");
            Console.ReadKey(); //readkey to block the program so the user can read
            Clear_screen();

            return saved_text;
        }


        /*
         * METHOD       : Display_data()
         * 
         * DESCRIPTION  : Displays the data in the file line-by-line
         * 
         * PARAMETERS   : List<string> saved_text: (shadowed name) a list that holds the strings added by the user
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_data(List<string> saved_text)
        {
            Clear_screen();
            //pseudocode:
            //for each string in list
            //{
            //    print({count} + ": " + {string})
            //}
            foreach(string item in saved_text)
            {
                int temp_line_num = saved_text.IndexOf(item) + 1; //the line number, starting at 1. Just in time declaration to keep the scope local to the loop
                Console.WriteLine( temp_line_num + ": " + item);
            }

            Console.WriteLine();
            Console.WriteLine("End of data");
            Console.WriteLine();

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(); //readkey to block the program
            Clear_screen();

        }
    }
}
