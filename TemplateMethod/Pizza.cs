namespace TemplateMethod.PizzaExample
{
    public class Pizza : BasePizza
    {
        public Pizza(string flavor)
        {
            Flavor = flavor;
        }
        internal override void AddBorderEmbilishments()
        {
            components.Add("Cheddar border");
        }

        internal override void AddFlavorEmbilishments()
        {
            components.Add("Extra cheese");
        }
    }
}
