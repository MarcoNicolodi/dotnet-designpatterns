using System;
using System.Collections.Generic;
using System.Linq;
using TemplateMethod.ReactComponent;
using static System.Console;

namespace TemplateMethod.ReactComponent
{
    public abstract class ReactComponent
    {
        protected Dictionary<string, object> props;
        private Dictionary<string, object> _nextProps;
        protected Dictionary<string, object> state;
        private Dictionary<string, object> _nextState;

        ///<summary>
        ///This is the template method
        ///</summary>
        public void Update()
        {
            if (ShouldComponentUpdate(_nextProps, _nextState))
            {
                Render();
                ComponentDidUpdate();
                return;
            }

            WriteLine("Didnt update");
        }

        internal abstract string Render();
        protected virtual void ComponentDidUpdate()
        {
            WriteLine("No-op");
        }

        protected virtual bool ShouldComponentUpdate(Dictionary<string, object> nextProps, Dictionary<string, object> nextState)
        {
            return true;
        }
    }

    public class MyComponent : ReactComponent
    {
        protected override bool ShouldComponentUpdate(Dictionary<string, object> nextProps, Dictionary<string, object> nextState)
        {
            if (nextProps?.FirstOrDefault(x => x.Key == "name").Value != props?.FirstOrDefault(x => x.Key == "name").Value)
            {
                return false;
            }

            return true;
        }

        internal override string Render()
        {
            return "<h1> Hello World </h1>";
        }

        protected override void ComponentDidUpdate()
        {
            WriteLine("Perform operations after DOM has rendered");
        }
    }

}
