using System.Globalization;
using CsvHelper;

namespace w1_basic_file_i_o_phenrichsbowe;

public class CharacterManager
{
  public bool Saving = false;
  private readonly string CharacterStoragePath = "characters.csv";
  private readonly List<Character> characters = [];
 
  /// <summary>
  /// Prompts the user for information about the new character and stores it in the characters list.
  /// </summary>
  public void CreateCharacter()
  {
    Character character = new();
    characters.Add(character);
  }

  public void ListCharacters()
  {
    Console.Clear();

    if (characters.Count == 0)
    {
      Console.WriteLine("Character list is empty try creating a character first.");
      return;
    }

    foreach (Character character in characters)
    {
      Console.WriteLine(character.ToString());
    }
  }

  public void LevelUpCharacter()
  {
    if (characters.Count == 0)
    {
      Console.WriteLine("Character list is empty try creating a chracter first.");
      return;
    }

    foreach (Character character in characters)
    {
      Console.WriteLine(character.ToString());
    }

    Character? characterToLevelUp = null;

    while (characterToLevelUp == null) {
      Console.Write("Enter the name of the character you would like to level up:");
      string? characterName = Console.ReadLine();

      characterToLevelUp = characters.Find(character => character.name == characterName);
    }

    string? levelsToAdd = "";
    uint numericLevelsToAdd = 0;

    while (!uint.TryParse(levelsToAdd, out numericLevelsToAdd)) {
      Console.WriteLine("Enter the amount of levels you would like to add to your character");
      levelsToAdd = Console.ReadLine();
    }

    characterToLevelUp.level += numericLevelsToAdd;
  }

  public void SaveToFile()
  {
    using var writer = new StreamWriter(CharacterStoragePath);
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    Saving = true;

    csv.WriteRecords(characters);

    Saving = false;
  }

  private void ReadFromFile() {
    if (!File.Exists(CharacterStoragePath))
    {
      Console.WriteLine("Character storage does not exist, creating it at " + CharacterStoragePath);

      FileStream fileStream = File.Create(CharacterStoragePath);
      fileStream.Close();
    }

    using (var reader = new StreamReader(CharacterStoragePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
      var records = csv.GetRecords<Character>().ToList();

      foreach (var record in records) {
        characters.Add(record);
      }
    }
  }

  public CharacterManager()
  {
    ReadFromFile();
  }
}