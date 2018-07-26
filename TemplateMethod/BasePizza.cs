using System.Collections.Generic;
using static System.Console;

namespace TemplateMethod.PizzaExample
{
    public abstract class BasePizza
    {
        protected List<string> components = new List<string>();
        public string Flavor { get; set; }
        public void Make()
        {
            AddDough();
            AddBorder();
            AddBorderEmbilishments();
            AddFlavor();
            AddFlavorEmbilishments();
            Cook();
        }

        private void Cook()
        {
            WriteLine("Cooked a pizza with:");
            components.ForEach(c => WriteLine(c));
        }

        internal abstract void AddFlavorEmbilishments();
        internal abstract void AddBorderEmbilishments();

        private void AddFlavor()
        {
            components.Add($"Flavor: {Flavor}");
        }

        private void AddDough()
        {
            components.Add("Dough");
        }

        private void AddBorder()
        {
            components.Add("Border");
        }
    }
}
