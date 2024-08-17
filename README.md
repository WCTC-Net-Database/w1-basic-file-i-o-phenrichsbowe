### Week 1: Introduction to C# and Console Applications, Basic C# Concepts and File I/O
- Overview of the course
- Review C# basics
  - Variables and Data Types
  - Operators
  - Control Structures
    - if, else if, else
    - switch
  - Loops
    - for
    - foreach
    - while
    - do while
  - Arrays and Lists
  - Functions
  - Exception Handling
- Setting up a console application
- Lecture: In this assignment, students will practice basic file I/O operations in C# by reading and writing RPG character data from a text file. The character data is stored in a simple CSV format, with each line representing a character and each character's data separated by a comma. The program reads the character data, levels up each character, and then writes the updated character data back to the file.
- Assignment: Write a simple console application that takes user input and displays output. Then, create a program that reads from and writes to a text file, demonstrating basic file I/O operations. The program should include creating a menu to Read and Write the file, as well as a menu option to "level up" a character.
- Stretch Goal: Implement [CsvHelper](https://joshclose.github.io/CsvHelper/)

## Sample Code
 ```csharp
class Program
{
    static void Main()
    {
        Console.Write("Enter your character's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your character's class: ");
        string characterClass = Console.ReadLine();

        Console.Write("Enter your character's level: ");
        int level = int.Parse(Console.ReadLine());

        Console.Write("Enter your character's equipment (separate items with a '|'): ");
        string[] equipment = Console.ReadLine().Split('|');

        Console.WriteLine($"Welcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");
    }
}
```
## Sample Data File: input.txt
```
John,Fighter,1,10,sword|shield|potion
Jane,Wizard,2,6,staff|robe|book
Bob,Rogue,3,8,dagger|lockpick|cloak
Alice,Cleric,4,12,mace|armor|potion
```
