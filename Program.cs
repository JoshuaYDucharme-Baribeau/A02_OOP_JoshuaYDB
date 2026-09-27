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
                Display_menu(); //menu display

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
                        
                        if(saved_text.Count > 0) //if there are any strings in the list to remove
                        {
                            saved_text = Remove_line(saved_text);
                        }
                        else //if there are no strings in the list to remove
                        {
                            Display_error_message
                                (
                                    "There are no saved lines to remove. Please add a line before removing one.",
                                    "Press any key to return to the menu..."
                                );
                        }

                        break;

                    case ConsoleKey.S:
                        Get_valid_file_name(saved_text);
                        break;

                    case ConsoleKey.X:

                        Clear_screen();
                        Console.WriteLine("Are you sure (Y or N)?");
                        user_input = Console.ReadKey();
                        if(user_input.Key == ConsoleKey.Y)
                        {
                            ready = false;
                            Clear_screen();
                        }
                        else // i.e. if input is not Y or y
                        {
                            //do nothing to continue looping to the menu
                        }
                        break;

                    default:
                        //no menu option selected, display an error
                        Display_error_message
                            (
                                "Invalid selection. Choose an operation based on the characters in brackets <>.",
                                "Press any key to return to the menu..."
                            );
                        break;

                }
                //Console.WriteLine("LAST INPUT:" + user_input.KeyChar + " \n"); //output for debugging purposes
            }
            
            //Console.WriteLine("successfully exited"); //debug line

        }


        /*
         * METHOD       : Clear_screen
         * 
         * DESCRIPTION  : clears the UI (i.e. clears the cli display).
         *                Although a method for this exists in the System namespace, 
         *                I use it frequently so I wanted my own method that I 
         *                could modify if I needed.
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
         * METHOD       : Display_menu
         * 
         * DESCRIPTION  : displays the main menu
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_menu()
        {
            Clear_screen(); //clear the screen before anything
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


        private static void Block_program(string message_prompt = "Press any key to continue...") //sets a default param to make the param optional.
        {
            Console.WriteLine(message_prompt);
            Console.ReadKey();
        }


        /*
         * METHOD       : Display_error_message
         * 
         * DESCRIPTION  : displays an informative error message
         * 
         * PARAMETERS   : NONE
         * 
         * RETURNS      : NOTHING
         */
        private static void Display_error_message(string error_message = "An error has occurred.", string message_prompt = "Press any key to try again...") //Two default params
        {
            //Clear_screen();
            Console.WriteLine("\n\n" + error_message);
            Block_program(message_prompt);
        }



        /*
         * METHOD       : Add_text
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
            Boolean invalid_string_flag = true; //flag to denote that the user_string is invalid (i.e. null or empty)

            while (invalid_string_flag)
            {
                Clear_screen();

                //just in time declaration to reset the value of user_string in each loop (in case of invalid input)
                string? user_string; //the '?' of 'string?' allows the string to be null, which allows for the below validation

                Console.WriteLine("Please enter the line of text you would like to add to the list:\n");
                user_string = Console.ReadLine();

                //if user_string is null or only whitespace
                if (string.IsNullOrWhiteSpace(user_string)) 
                {
                    //display an error and block program (Display_error_message calls a method to block the program)
                    Display_error_message("The line of text you enter must not be blank."); //uses the default param for the Block_program method
                    
                }
                //else, i.e. if user_string is not null or only whitespace
                else
                {
                    //add string to the list
                    saved_text.Add(user_string);
                    invalid_string_flag = false; //string is valid, changes flag to false to exit loop
                }

            }

            Console.WriteLine("Text added successfully.");
            Block_program("Press any key to return to the menu...");

            return saved_text;
        }


        /*
         * METHOD       : Display_data
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

            foreach (string item in saved_text)
            {
                int temp_line_num = saved_text.IndexOf(item) + 1; //the line number, starting at 1. Just in time declaration to keep the scope local to the loop
                Console.WriteLine(temp_line_num + ": " + item);
            }

            //explicitly writing blank lines separately for assignment readability
            // could be condensed with escape characters such as \n
            Console.WriteLine();
            Console.WriteLine("End of data");
            Console.WriteLine();

            Block_program("Press any key to return to the menu...");

        }


        /*
         * METHOD       : Remove_line
         * 
         * DESCRIPTION  : Removes a string from the list passed in the parameter
         *                and returns the new list. The dtring that is removed is
         *                based on user input, who is prompted to enter a line number.
         *                The line number is the index+1 (since the index is 0 based)
         * 
         * PARAMETERS   : List<string> saved_text: (Shadowed name) a list that holds the strings of the user
         * 
         * RETURNS      : List<string> saved_text: (shadowed name) returns the updated list after a line was removed
         */
        private static List<string> Remove_line(List<string> saved_text)
        {
            Boolean invalid_input = true; //flag to control the while loop and denote that the input is invalid (i.e. null or empty, index does not exist, invalid input)
            int index_for_deletion; //index of the line the user wants to delete

            while (invalid_input)
            {
                Clear_screen();
                //just in time declaration to reset the value of user_input in each loop (in case of invalid input or line not found)
                string? user_input; //input from the user, '?' allows the input to be null (will be handled by validation)
                
                Console.WriteLine("Please enter the line number you would like to remove from the list:\n");
                user_input = Console.ReadLine();

                //if user_string is null or only whitespace
                if (string.IsNullOrWhiteSpace(user_input)) 
                {
                    Display_error_message
                        (
                            "The line number you enter must not be blank.",
                            "Press any key to enter a different line number..."
                        );
                }
                else //if user_string is not null or only whitespace
                {
                    //check if the string is parsable to an int
                    if (Int32.TryParse(user_input, out index_for_deletion) && index_for_deletion > 0) //checks if input was a parsable int, and if that int was lager than 0
                    {
                        index_for_deletion -= 1; //decrease the value by 1 to match the actual index instead of line number

                        //check if the string at the index exists (should be between (-1) and (saved_text.Count) EXCLUSIVELY)
                        if (index_for_deletion > -1 && index_for_deletion < saved_text.Count) //if the indicated line exists, this check prevents RemoveAt() from throwing an excception
                        {
                            saved_text.RemoveAt(index_for_deletion); //remove the string at the index in question
                            invalid_input = false; //changing the flag to false in order to exit the loop

                            Console.WriteLine($"\nLine {index_for_deletion + 1} removed successfully.");
                            Block_program("Press any key to continue...");

                        }
                        else //if the indicated line does not exist
                        {
                            Display_error_message
                                (
                                    "The line number you entered does not exist.",
                                    "Press any key to enter a different line number..."
                                );
                        }

                    }
                    else //i.e. if the input was not parsable to an int or was smaller than 1 (covers letters, symbols, zero, negative numbers and non-integers)
                    {
                        Display_error_message
                            (
                                "Invalid input. Enter only integers greater than 0.",
                                "Press any key to enter a different line number..."
                            );
                    }

                }

            }

            return saved_text;

        }

        private static void Get_valid_file_name(List<string> saved_text)
        {
            Boolean invalid_file_name = true;
            string? file_name;

            while (invalid_file_name)
            {
                Clear_screen();
                Console.WriteLine("Enter the name of the file to which you would like to save the data." +
                    "\nNB: Do not use spaces or symbols. Be sure to specify a file extension:\n");
                file_name = Console.ReadLine();

                //Preventing null or blank filenames, as well as preventing sympols and spaces to accommodate a broader range of file systems
                //Regex might be preferable here if there were more specific requirements. This covers most bases
                if (string.IsNullOrEmpty(file_name) || file_name.Any(char.IsWhiteSpace) || file_name.Any(char.IsSymbol))
                {
                    Display_error_message
                        (
                            "The file name may not be blank or contain spaces or special characters.",
                            "Press any key to enter a different file name."
                        );
                }
                //if filename contains valid chars,call the method to open and write to the file
                else
                {
                    Write_to_file(file_name, saved_text);
                    //exit the loop by changing the flag
                    invalid_file_name = false;
                    Console.WriteLine($"\nData saved successfully to {file_name}.");
                    Block_program("Press any key to continue...");

                }

            }

        }

        private static void Write_to_file(string file_name, List<string> saved_text)
        {
            //specifiying the namespace for clarity and evaluation of the instructor
            System.IO.FileStream my_file_stream;
            System.IO.StreamWriter my_stream_writer;
            
            //
            my_file_stream = File.OpenWrite(file_name);
            my_stream_writer = new StreamWriter(my_file_stream);

            //write each element of the list to the file, line by line
            foreach (string element in saved_text)
            {
                my_stream_writer.WriteLine(element);
            }
            //close when finished
            my_stream_writer.Close();
            my_file_stream.Close();
        }

    }
}
