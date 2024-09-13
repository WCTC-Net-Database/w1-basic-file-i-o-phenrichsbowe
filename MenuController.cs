using w1_basic_file_i_o_phenrichsbowe;

public class MenuController
{
  public bool Alive = true;
  private uint MenuIndex = 0;
  private readonly uint[] MenuIndicies = { 1, 2, 3, 4 };
  private readonly CharacterManager characterManager = new();

  private bool IsMenuIndexValid(string menuIndex)
  {
    uint numericMenuIndex;

    if (!uint.TryParse(menuIndex, out numericMenuIndex))
    {
      return false;
    }

    if (!MenuIndicies.Contains(numericMenuIndex))
    {
      return false;
    }

    return true;
  }

  public void Update()
  {
    switch (MenuIndex)
    {
      case 0:
        PromptMenuSelection();
        break;
      case 1:
        ListCharacters();
        break;
      case 2:
        LevelUpCharacter();
        break;
      case 3:
        AddCharacter();
        break;
      case 4:
      default: 
        Shutdown();
        break;
    }
  }

  private void PromptMenuSelection()
  {
    Console.WriteLine("Select one of the following options:\n1: Display Characters\n2: Level Up Character\n3: Create Character\n4: Shutdown");

    string? selection = Console.ReadLine();

    while (string.IsNullOrEmpty(selection) || !IsMenuIndexValid(selection))
    {
      Console.Clear();
      Console.WriteLine("Invalid selection provided. Valid selections are:\n1: Display Characters\n2: Level Up Character\n3: Create Character\n4: Shutdown");
      selection = Console.ReadLine();
    }

    MenuIndex = uint.Parse(selection);
    Console.Clear();
  }

  private void ListCharacters() {
    characterManager.ListCharacters();
    MenuIndex = 0;
  }

  private void LevelUpCharacter() {
    characterManager.LevelUpCharacter();
    MenuIndex = 0;
  }

  private void AddCharacter() {
    characterManager.CreateCharacter();
    MenuIndex = 0;
  }

  private void Shutdown() {
    Console.WriteLine("Shutting down!");
    
    characterManager.SaveToFile();

    while (characterManager.Saving) {
      Console.WriteLine("Waiting to shutdown writing characters to storage.");
      Thread.Sleep(1000);
    }

    Alive = false;
  }

  public MenuController()
  {
    //Console.Clear();
    Console.WriteLine("Welcome to the character selection menu.");

    while (Alive) Update();
  }
}