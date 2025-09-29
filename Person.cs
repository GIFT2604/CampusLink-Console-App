namespace CampusLink
{
    public class Person
    {
        // Encapsulation with properties
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Person(string name, string gender, int age)
        {
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}
