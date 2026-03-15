using System;
//---------------------------------
// STRETCH: Create a menu for the user to choose between memorizing a random scripture or entering one to study. This allows 
// the user to either select a random scripture from a predefined list or input their own scripture reference and text for memorization. 
// This part of the program uses the class RandomScripture to get a random scripture and the Reference class to create a reference
// based on user input. The user is prompted to enter the book, chapter, and verse(s) for the scripture they want to study, and then 
// they can input the scripture text. The program then proceeds with the memorization process as before.
// ---------------------------------

/// <summary>
/// The RandomScripture class manages a collection of Scripture objects and provides functionality to retrieve a random scripture. 
/// It initializes a list of scriptures with predefined references and texts, and uses a Random object to select and return a 
/// random scripture when requested.
/// </summary>
public class RandomScripture
{
    // -- MEMBER VARIABLES --
    private List<Scripture> _scriptures;
    private Random _random;


    // -- CONSTRUCTORS --

    /// <summary>
    /// The constructor initializes the RandomScripture object by creating a list of Scripture objects with 
    /// predefined references and texts. It also initializes a Random object for later use in selecting random 
    /// scriptures.
    /// </summary>
    public RandomScripture()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        Reference reference1 = new Reference("Jacob", 4, 5);
        Scripture scripture1 = new Scripture(reference1, "Behold, they believed in Christ and worshiped the Father in his name, and also we worship the Father in his name. And for this intent we keep the law of Moses, it pointing our souls to him; and for this cause it is sanctified unto us for righteousness, even as it was accounted unto Abraham in the wilderness to be obedient unto the commands of God in offering up his son Isaac, which is a similitude of God and his Only Begotten Son.");
        _scriptures.Add(scripture1);

        Reference reference2 = new Reference("Ether", 12, 6);
        Scripture scripture2 = new Scripture(reference2, "And now, I would commend you to seek this Jesus of whom the prophets and apostles have written, that the grace of God the Father, and also the Lord Jesus Christ, and the Holy Ghost, which beareth record of them, may be and abide in you forever. Amen.");
        _scriptures.Add(scripture2);

        Reference reference3 = new Reference("Alma", 37, 6);
        Scripture scripture3 = new Scripture(reference3, "By small and simple things are great things brought to pass; and small means in many instances doth confound the wise.");
        _scriptures.Add(scripture3);

        Reference reference4 = new Reference("Ezekiel", 25, 17);
        Scripture scripture4 = new Scripture(reference4, "The path of the righteous man is beset on all sides by the inequities of the selfish and the tyranny of evil men. Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for he is truly his brother’s keeper and the finder of lost children. And I will strike down upon thee with great vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is the Lord when I lay My vengeance upon thee.");
        _scriptures.Add(scripture4);
    }


    // -- METHODS --

    /// <summary>
    /// The GetRandomScripture method selects and returns a random Scripture object from the list of scriptures. It uses the Random object to generate a random index and retrieves the corresponding Scripture from the list.
    /// </summary>
    /// <returns>A random Scripture object.</returns>
    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }

}