using System;

namespace CampusLink
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\n--- CampusLink Menu ---");
                Console.WriteLine("1. Register Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Sort Students");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Gender (Male/Female): ");
                        string gender = Console.ReadLine();

                        Console.Write("Age: ");
                        if (int.TryParse(Console.ReadLine(), out int age))
                        {
                            Student student = new Student(name, gender, age);
                            manager.Add(student);
                            Console.WriteLine($"Student {student.Name} added with ID {student.StudentID}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid age!");
                        }
                        break;

                    case "2":
                        Console.WriteLine("\n--- Student Roster ---");
                        foreach (var s in manager.List())
                        {
                            Console.WriteLine($"ID: {s.StudentID}, Name: {s.Name}, Gender: {s.Gender}, Age: {s.Age}");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Student ID to edit: ");
                        string editId = Console.ReadLine();
                        Console.Write("New Name (leave blank to skip): ");
                        string newName = Console.ReadLine();
                        Console.Write("New Gender (leave blank to skip): ");
                        string newGender = Console.ReadLine();
                        Console.Write("New Age (leave blank to skip): ");
                        string ageInput = Console.ReadLine();
                        int? newAge = int.TryParse(ageInput, out int parsedAge) ? parsedAge : (int?)null;

                        if (manager.Edit(editId, string.IsNullOrEmpty(newName) ? null : newName,
                                                  string.IsNullOrEmpty(newGender) ? null : newGender,
                                                  newAge))
                        {
                            Console.WriteLine("Student updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Student ID to delete: ");
                        string deleteId = Console.ReadLine();
                        if (manager.Delete(deleteId))
                            Console.WriteLine("Student deleted successfully.");
                        else
                            Console.WriteLine("Student not found.");
                        break;

                    case "5":
                        Console.Write("Sort by Name or Age? ");
                        string sortBy = Console.ReadLine();
                        var sorted = manager.Sort(sortBy);
                        Console.WriteLine($"\n--- Students Sorted by {sortBy} ---");
                        foreach (var s in sorted)
                        {
                            Console.WriteLine($"ID: {s.StudentID}, Name: {s.Name}, Gender: {s.Gender}, Age: {s.Age}");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}

