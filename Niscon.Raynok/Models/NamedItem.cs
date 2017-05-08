using System.Windows;

namespace Niscon.Raynok.Models
{
    public class NamedItem<T> : DependencyObject
    {
        public NamedItem() { }

        public NamedItem(string name, T item)
        {
            Name = name;
            Item = item;
        }

        public string Name { get; set; }
        public T Item { get; set; }
    }

    public class NamedItem : NamedItem<object>
    {
        public NamedItem() : base() { }
        public NamedItem(string name, object item) : base(name, item) { }
    }
}
