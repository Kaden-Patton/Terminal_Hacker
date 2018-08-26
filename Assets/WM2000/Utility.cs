public static class StringExtension
{
    public static string Anagram(this string str) // Note use of this
    {
        string attempt = Shuffle(str);
        while (attempt == str)
        {
            attempt = Shuffle(str);
        }
        return attempt;
    }


    // Based on something we got from the web, not re-written for clarity
    private static string Shuffle(string str)
    {
        char[] characters = str.ToCharArray(); // take the string and put each character into an array
        System.Random randomRange = new System.Random(); // create a new range for randomness
        int numberOfCharacters = characters.Length; // get the length of the newly created array of characters and store it to an int
        while (numberOfCharacters > 1) // While the number of characters is greater than 1
        {
            numberOfCharacters--; // Subtract 1 from the integer representation of how many characters are in our array
            int index = randomRange.Next(numberOfCharacters + 1); // Get a random integer that is less than our total number of characters and assign it to this index value
            var value = characters[index]; // Current targeted value is whatever character is at the index previously defined
            characters[index] = characters[numberOfCharacters]; // The character we are targeting now equals the index in our array of how much stuff we have in the array still
            characters[numberOfCharacters] = value; // lost me.
        }
        return new string(characters); // give them the shuffled string
    }

 

}