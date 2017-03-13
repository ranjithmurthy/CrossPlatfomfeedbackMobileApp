using System.Collections.ObjectModel;

namespace GroupingSampleListView
{
    public class VeggieModel
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public bool IsReallyAVeggie { get; set; }
        public string Image { get; set; }
    }

    public class GroupedVeggieModel : ObservableCollection<VeggieModel>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }

    public class Person
    {
        public Person(string name, int age, string location)
        {
            Name = name;
            Age = age;
            Location = location;
        }

        public string Name { get; }

        public int Age { get; private set; }

        public string Location { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}