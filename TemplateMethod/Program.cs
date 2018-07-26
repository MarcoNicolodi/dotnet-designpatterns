using System;
using TemplateMethod.ReactComponent;
using TemplateMethod.PizzaExample;

namespace TemplateMethod
{

    class Program
    {
        static void Main(string[] args)
        {
            // pizza example
            var pizza = new PizzaExample.Pizza("Peperoni");
            pizza.Make();

            // simulate react component lifecycle with template method
            var component = new MyComponent();
            component.Update();
        }
    }
}
