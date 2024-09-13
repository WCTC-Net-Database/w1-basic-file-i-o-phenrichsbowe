namespace w1_basic_file_i_o_phenrichsbowe;

/// <summary>
/// This is a character class!
/// </summary>
public class Character
{
  public string name { get; set; }
  public string characterClass { get; set; }
  public uint level { get; set; }
  public string equipment { get; set; }

  /// <summary>
  /// Gets the name of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterName()
  {
    string? characterName = "";

    while (string.IsNullOrEmpty(characterName))
    {
      Console.Write("Enter your character's name: ");
      characterName = Console.ReadLine();
    }

    return characterName;
  }
  /// <summary>
  /// Gets the class of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterClass()
  {
    string? characterClass = "";

    while (string.IsNullOrEmpty(characterClass))
    {
      Console.Write("Enter your character's class: ");
      characterClass = Console.ReadLine();
    }

    return characterClass;
  }
  /// <summary>
  /// Gets the level of the users character and does basic input validation
  /// </summary>
  static private uint PromptCharacterLevel()
  {
    uint characterLevel = 0;
    bool isValidLevel = false;

    while (!isValidLevel)
    {
      Console.Write("Enter your character's level: ");
      isValidLevel = uint.TryParse(Console.ReadLine(), out characterLevel);
    }

    return characterLevel;
  }
  /// <summary>
  /// Gets the equipment of the users character and does basic input validation
  /// </summary>
  static private string PromptCharacterEquipment()
  {
    Console.Write("Enter your character's equipment (separate items with a '|'): ");

    string? characterEquipment = Console.ReadLine();

    return characterEquipment ?? "";
  }

    public override string ToString()
    {
      return $"Name: {name}, {characterClass}, {level}, {string.Join("|", equipment)}";
    }

    public Character(string? name = null, string? characterClass = null, uint? level = null, string? equipment = null) {
      this.name = name ?? PromptCharacterName();
      this.characterClass = characterClass ?? PromptCharacterClass();
      this.level = level ?? PromptCharacterLevel();
      this.equipment = equipment ?? PromptCharacterEquipment();
    }
}