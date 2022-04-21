public class Student
{
    public static void Main()
    {
        int[] dice;
        int sides;

        do
        {
            sides = IsValidInt("Please put the amount of sides you want for your dice as an integer.");
            dice = randNum(sides);
            if (sides == 6)
            {
                Console.WriteLine(D6Combos(dice[0], dice[1]));
            }
            else
            {
                Console.WriteLine(OtherCombos(dice[0], dice[1], sides));
            }
        } while (RunAgain());
    }

    public static int[] randNum(int sides)
    {
        var rand = new Random();
        int[] diceNums = { -1, -1 };

        for (int i = 0; i < diceNums.Length; i++)
        {
            diceNums[i] = rand.Next(sides) + 1;
        }

        Console.WriteLine("You rolled a " + diceNums[0] + " and a " + diceNums[1] + " with a total of " + (diceNums[0] + diceNums[1]) + ".");


        return diceNums;
    }

    public static string D6Combos(int dieZero, int dieOne)
    {
        string output = "";

        switch (dieZero + dieOne)
        {
            case 7 or 11:
                output = output + "Win: A total of 7 or 11!";
                break;
            case 2 or 3 or 12:
                output = output + "Craps: A total of 2, 3, or 12!";
                switch (dieZero, dieOne) // A total of any of these is a craps.
                {
                    case (1, 1):
                        output = output + "\nSnake Eyes: Two 1s!";
                        break;
                    case (1, 2) or (2, 1):
                        output = output + "\nAce Deuce: A 1 and 2!";
                        break;
                    case (6, 6):
                        output = output + "\nBox Cars: Two 6s!";
                        break;
                }
                break;
        }
        return output;
    }

    public static string OtherCombos(int dieZero, int dieOne, int sides)
    {
        string output = "";

        if (dieOne == dieZero)
        {
            output = "\nWin: You rolled doubles!";
        }
        else if (dieZero + dieOne >= Math.Ceiling(1.8 * (double)sides))
        {
            output = "\nWin: Your total is at least 90% of the maximum roll.";
        }
        else if (dieZero + dieOne <= Math.Floor(.2 * (double)sides))
        {
            output = "\nWin: Your total is at most 10% of the maximum roll.";
        }
        else if (sides % dieZero == 0 || sides % dieOne == 0)
        {
            output = "\nWin: At least one of your dice divides " + sides + ".";
        }
        return output;
    }

    public static bool RunAgain()
    {
        string input = GetInput("Would you like to run again? y/n");

        if (input == "y")
        {
            return true;
        }
        else if (input == "n")
        {
            Console.WriteLine("Goodbye.");
            return false;
        }
        else
        {
            Console.WriteLine("I didn't get that. Let's try again.");
            return RunAgain();
        }
    }

    public static string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine().ToLower().Trim();

        if (input.Length == 0)
        {
            Console.WriteLine("You must enter something. Let's try again.");
            return GetInput(prompt);
        }
        return input;
    }

    public static int IsValidInt(string prompt)
    {
        string input = GetInput(prompt);

        if (int.TryParse(input, out int output) && output >= 1)
        {
            return output;
        }
        else
        {
            Console.WriteLine("That is not an integer above 0.");
            return IsValidInt(input);
        }
    }
}