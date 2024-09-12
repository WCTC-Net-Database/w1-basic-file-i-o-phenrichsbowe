using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic;

namespace w1_basic_file_i_o_phenrichsbowe;

public class CharacterManager
{
  public bool Saving = false;
  private readonly string CharacterStoragePath = "characters.csv";
  private List<Character> characters = new List<Character> {};
 

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
    if (!characters.Any())
    {
      Console.WriteLine("Character list is empty try creating a chracter first.");
      return;
    }

    Console.WriteLine("Select the character you would like to level up:");

    foreach (Character character in characters)
    {
      Console.WriteLine(character.ToString());
    }
  }

  public void Save()
  {
    using var writer = new StreamWriter(CharacterStoragePath);
    using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
    Saving = true;

    csv.WriteRecords(characters);

    Saving = false;
  }

  private void SaveToFile() {
    
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