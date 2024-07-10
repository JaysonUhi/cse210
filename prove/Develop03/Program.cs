// I added multiple verses and have the program pick one randomly.
// I added statements to show when all words are hidden as well as an exit statement.
// I have it hiding a single word at a time because that is whats easier for me to
// be able to memorize verses. That number can be changed in scripture.cs

using System;

class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture();

        AddNewScriptures(scripture);

        scripture.SelectRandomScripture();

        Random random = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Press ENTER to quit.");
                break;
            }

            scripture.HideNextRandomWord();

            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide a random word, or type 'quit' to exit.");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                break;
            }
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void AddNewScriptures(Scripture scripture)
    {
        scripture.AddScripture(new ScriptureReference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.");
        
        scripture.AddScripture(new ScriptureReference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy.");
        
        scripture.AddScripture(new ScriptureReference("Mosiah", 2, 17), "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God.");
        
        scripture.AddScripture(new ScriptureReference("2 Nephi", 31, 20), "Wherefore, ye must press forward with a steadfastness in Christ, having a perfect brightness of hope, and a love of God and of all men. Wherefore, if ye shall press forward, feasting upon the word of Christ, and endure to the end, behold, thus saith the Father: Ye shall have eternal life.");
        
        scripture.AddScripture(new ScriptureReference("Doctrine and Covenants", 58, 27), "Verily I say, men should be anxiously engaged in a good cause, and do many things of their own free will, and bring to pass much righteousness.");

        scripture.AddScripture(new ScriptureReference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life");

        scripture.AddScripture(new ScriptureReference("Moroni", 10, 4, 5), "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost.; And by the power of the Holy Ghost ye may know the truth of all things.");

        scripture.AddScripture(new ScriptureReference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart and lean not unto thine own understanding.; In all thy ways acknowledge him, and he shall direct thy paths.");

    }
}
