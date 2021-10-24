using System;

namespace CS_math
{
    class Program
    {
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                // Setup code to generate random numbers
                Random n1 = new Random();   // Generate instance of random number generator
                int r_min = 1;              // Min value for random number generator
                int r_max = 10;             // Max number for random number generator

                // Generate random number between r_min and r_max
                int temp_x1 = n1.Next(r_min, r_max);    // Temporary values, used to make sure that operation is alway positive
                int temp_x2 = n1.Next(r_min, r_max);
                int x1 = 0;
                int x2 = 0;

                string math_string = ""; // Variable to store math string (+, -, *)
                int y = 0; // Variable to store result

                // Setup code to select math operation + correct answer
                int math_op = n1.Next(1, 5);  // Integer to select mathematical operation
                switch (math_op)
                {
                    case 1: // Addition - temp values are assigned to x1 and x2, respectively
                        x1 = temp_x1;
                        x2 = temp_x2;
                        y = x1 + x2;
                        math_string = "+";
                        break;

                    case 2: // Subtraction
                            // - max temp value is assigned to x1
                            // - min temp value is assined to x2 (i.e., only positive results expected)
                        if (temp_x1 > temp_x2)
                        {
                            x1 = temp_x1;
                            x2 = temp_x2;
                        }
                        else
                        {
                            x1 = temp_x2;
                            x2 = temp_x1;
                        }
                        y = x1 - x2;
                        math_string = "-";
                        break;

                    case 3: // Multiplication
                        x1 = temp_x1;
                        x2 = temp_x2;
                        y = x1 * x2;
                        math_string = "*";
                        break;

                    case 4: // Division
                        x2 = temp_x1;
                        y = temp_x2;
                        x1 = x2 * y;
                        math_string = "/";
                        break;
                }

                Console.WriteLine(x1 + " " + math_string + " " + x2 + " = " + y);
                
                // Setup for the incorrect answer
                int y_n_max = 3;    // Maximum number of wrong answers - Link to in-game settings
                int y_r_max = 0;    // Max value for wrong answers random number generator

                if (y == 0)
                { y_r_max = 2; }
                else
                { y_r_max = 2 * y; }

                int[] y_wrong = new int[y_n_max];   // Array to store values of wrong answers

                for (int j = 0; j < y_n_max; j++)
                {
                    y_wrong[j] = n1.Next(0, y_r_max);   // Generate random number between 0 a twice the right answer
                    Console.WriteLine("Incorrect answer " + j + " = " + y_wrong[j]);
                }
                
                Console.WriteLine(" ");
                                
            }
        }
    }
}
