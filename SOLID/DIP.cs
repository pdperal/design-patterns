using System.Collections.Generic;
using System.Linq;

namespace SOLID
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IRelationShipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    // low-level

    public class RelationShips : IRelationShipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();
        public List<(Person, Relationship, Person)> Relations => relations;

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations.Where(x => x.Item1.Name == "Jhon" && x.Item2 == Relationship.Parent).Select(r => r.Item3);
        }
    }

    public class DIP 
    {
        public DIP(IRelationShipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("Jhon"))
            {
                System.Console.WriteLine($"Jhon has a child caller {p.Name}");
            }
        }

        public static void Main()
        {
            var parent = new Person { Name = "Jhon" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationShips = new RelationShips();
            relationShips.AddParentAndChild(parent, child1);
            relationShips.AddParentAndChild(parent, child2);

            new DIP(relationShips);

            System.Console.ReadKey();
        }
    }
}
