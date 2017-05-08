using System;

namespace Niscon.Raynok.Models
{
    public class AdminMenuItem
    {
        public AdminMenuItem() { }

        public AdminMenuItem(string name, Action menuAction = null)
        {
            Name = name;
            MenuAction = menuAction;
        }

        public string Name { get; set; }
        public Action MenuAction { get; set; }
    }
}
