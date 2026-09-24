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
            string temp_input; //temporary variable while developing

            Boolean ready = true;
            
            //loop for main program
            while (ready)
            {
                Display_menu(); //initial menu display
                //await a keypress (switch case?)


                //case "x" or "X"
                Console.WriteLine("Enter X to exit");
                temp_input = Console.ReadLine(); //here to stop infinite loop while developing
                if(temp_input == "x" || temp_input == "X") //turn this if statement into a case when keystroke input is established
                {
                    ready = false;
                }
            }
            Console.WriteLine("success");
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

            //no return needed for void return type
        }


        /*
         * METHOD       : Display_menu()
         * 
         * DESCRIPTION  : clears the UI (i.e. clears the cli display)
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_menu()
        {
            Console.WriteLine("My menu \n\n");
            //no return needed for void return type
        }


        /*
         * METHOD       : Display_error_message()
         * 
         * DESCRIPTION  : displays an informative error message
         * 
         * PARAMETERS   : 
         * 
         * RETURNS      : 
         */
        private static void Display_error_message()
        {

        }
    }
}
