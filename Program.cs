using System;

class CollegeFootballExperience
{
    static void Main(string[] args)
    {
        // Welcome message
        Console.WriteLine("Welcome to the College Football Experience Finder!");

        try
        {
            // Ask the user what kind of football experience he/she wants 
            string enjoymentLevel = AskForEnjoymentLevel();
            Console.WriteLine($"You’re looking for an {enjoymentLevel} experience. Let's see what we can recommend...");

            // Based on their enjoyment level, suggest a stadium
            string recommendedStadium = RecommendStadium(enjoymentLevel);
            Console.WriteLine($"We think the best stadium for you is: {recommendedStadium}");

            // Based on the stadium, recommend a game to attend
            string recommendedGame = RecommendGame(recommendedStadium);
            Console.WriteLine($"The game you should attend is: {recommendedGame}");

            // Finally, summarize the recommendation
            SummarizeRecommendation(recommendedStadium, recommendedGame);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Oops, something went wrong: {ex.Message}");
        }
    }

    // Ask the user what kind of experience they want
    static string AskForEnjoymentLevel()
    {
        Console.WriteLine("What kind of football experience are you looking for?");
        Console.WriteLine("Options: Boring, Average, Fun, Epic");
        string userChoice = Console.ReadLine().Trim();

        // Keep asking if the input is not valid
        while (string.IsNullOrEmpty(userChoice) || !IsValidEnjoymentLevel(userChoice))
        {
            Console.WriteLine("That’s not a valid option. Please choose: Boring, Average, Fun, Epic.");
            userChoice = Console.ReadLine().Trim();
        }

        return CapitalizeFirstLetter(userChoice);
    }

    // Check if the enjoyment level input is valid
    static bool IsValidEnjoymentLevel(string input)
    {
        string[] validOptions = { "boring", "average", "fun", "epic" };
        return Array.Exists(validOptions, option => option == input.ToLower());
    }

    // Capitalize the first letter of the input to format it nicely
    static string CapitalizeFirstLetter(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        return char.ToUpper(input[0]) + input.Substring(1).ToLower();
    }

    // Suggest a stadium based on the user's enjoyment level
    static string RecommendStadium(string enjoymentLevel)
    {
        switch (enjoymentLevel.ToLower())
        {
            case "boring":
                return "Neyland Stadium";
            case "average":
                return "Jordan-Hare Stadium";
            case "fun":
                return "Tiger Stadium";
            case "epic":
                return "Saban Field at Bryant-Denny Stadium";
            default:
                return "an unknown stadium"; // Fallback, but this shouldn't happen due to validation
        }
    }

    // Suggest a game based on the stadium choice
    static string RecommendGame(string stadium)
    {
        switch (stadium)
        {
            case "Neyland Stadium":
                return "Kent State vs Neyland Stadium";
            case "Jordan-Hare Stadium":
                return "Kentucky vs Jordan-Hare Stadium";
            case "Tiger Stadium":
                return "Alabama vs Tiger Stadium";
            case "Saban Field at Bryant-Denny Stadium":
                return "Auburn vs Saban Field";
            default:
                return "no game available"; // Fallback case
        }
    }

    // Provide a nice summary of the recommendation
    static void SummarizeRecommendation(string stadium, string game)
    {
        Console.WriteLine();
        Console.WriteLine("Here’s your full recommendation:");
        Console.WriteLine($"Stadium: {stadium}");
        Console.WriteLine($"Game: {game}");
        Console.WriteLine("Enjoy your game day experience!");
    }
}
