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
            //string temp_input; //temporary variable while developing

            Boolean ready = true;
            ConsoleKeyInfo user_input; //using the ConsoleKeyInfo object/struct to store the key stroke https://learn.microsoft.com/en-us/dotnet/api/system.console.readkey?view=net-10.0 
            
            
            //loop for main program
            while (ready)
            {
                Display_menu(); //initial menu display
                //Console.WriteLine("Enter X to exit");
                //temp_input = Console.ReadLine(); //here to stop infinite loop while developing
                
                user_input = Console.ReadKey();
                switch (user_input.Key)
                {
                    case ConsoleKey.A:
                        Add_text();
                        break;

                    case ConsoleKey.D:
                        Display_data();
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
                //if(temp_input == "x" || temp_input == "X") //turn this if statement into a case when keystroke input is established
                //{
                //}
            }
            Console.WriteLine("successfully exited"); //debug line
            //
            //


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
         * DESCRIPTION  : Adds text to the file
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Add_text()
        {
            Console.WriteLine("Please enter the text you would like to add to the file\n");
            Console.ReadLine();
            
            //add text to file
            
            Console.WriteLine("\nText added successfully, press any key to continue...");
            Console.ReadKey(); //readkey to block the program
            Clear_screen();

            //no return needed for void return type
        }


        /*
         * METHOD       : Display_data()
         * 
         * DESCRIPTION  : Displays the data in the file line-by-line
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_data()
        {
            Clear_screen();
            //pseudocode:
            //for each string in list
            //{
            //    print({ count} + ": " + {string})
            //}
            Console.WriteLine();
            Console.WriteLine("End of data");
            Console.WriteLine();

            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey(); //readkey to block the program
            Clear_screen();

        }
    }
}
