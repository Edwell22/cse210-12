using System;

//This  Class  represent a word in the scripture
public class ScriptureWord {
  public string Text { get; set; }
  public bool IsHidden { get; set; }
}

// Class to represent the scripture reference
public class ScriptureReference {
  public string Book { get; set; }
  public int Chapter { get; set; }
  public int? StartVerse { get; set; }
  public int? EndVerse { get; set; }
}

// Class to represent the scripture itself
public class Scripture {
  public ScriptureReference Reference { get; set; }
  public List<List<ScriptureWord>> Verses { get; set; }

  public Scripture(string book, int chapter, int? startVerse = null, int? endVerse = null) {
    Reference = new ScriptureReference {
      Book = book,
      Chapter = chapter,
      StartVerse = startVerse,
      EndVerse = endVerse
    };
    Verses = new List<List<ScriptureWord>>();
  }

  public void AddVerse(List<ScriptureWord> verse) {
    Verses.Add(verse);
  }

  // Method to hide a few random words in the scripture
  public void HideRandomWords(int count) {
    // Get a list of all words in the scripture
    var allWords = new List<ScriptureWord>();
    foreach (var verse in Verses) {
      allWords.AddRange(verse);
    }

    // Hide a few random words
    var random = new Random();
    var hiddenCount = 0;
    while (hiddenCount < count) {
      var randomIndex = random.Next(allWords.Count);
      if (!allWords[randomIndex].IsHidden) {
        allWords[randomIndex].IsHidden = true;
        hiddenCount++;
      }
    }
  }

  public override string ToString() {
    var scriptureText = $"{Reference.Book} {Reference.Chapter}";
    if (Reference.StartVerse != null) {
      scriptureText += $":{Reference.StartVerse}";
      if (Reference.EndVerse != null && Reference.EndVerse != Reference.StartVerse) {
        scriptureText += $"-{Reference.EndVerse}";
      }
    }
    scriptureText += "\n";
    foreach (var verse in Verses) {
      foreach (var word in verse) {
        scriptureText += word.IsHidden ? "_____" : word.Text;
        scriptureText += " ";
      }
      scriptureText += "\n";
    }
    return scriptureText;
  }
}

// The main program
public class Program {
  static void Main(string[] args) {
    // Create therevised `Scripture` object with multiple verses
    var scripture = new Scripture("John", 3, 16);
    scripture.AddVerse(new List<ScriptureWord> {
      new ScriptureWord { Text = "For God so loved the" },
      new ScriptureWord { Text = "world", IsHidden = true },
      new ScriptureWord { Text = "that he gave his one and only Son," },
      new ScriptureWord { Text = "that whoever believes in him shall not perish but have eternal life." }
    });
    scripture.AddVerse(new List<ScriptureWord> {
      new ScriptureWord { Text = "For God did not send his Son into the world to condemn the world, but to save the world through him." }
    });

    // Display the complete scripture
    Console.Clear();
    Console.WriteLine(scripture);

    // Prompt the user to press enter or type quit
    Console.WriteLine("\nPress enter to continue or type 'quit' to end");
    var input = Console.ReadLine();

    while (input.ToLower() != "quit") {
      // Hide a few random words
      scripture.HideRandomWords(3);

      // Display the scripture with hidden words
      Console.Clear();
      Console.WriteLine(scripture);

      // Prompt the user to press enter or type quit
      Console.WriteLine("\nPress enter to continue or type 'quit' to end");
      input = Console.ReadLine();
    }

    // End the program
    Console.WriteLine("\nGoodbye!");
  }
}