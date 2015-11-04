namespace Scratch
{
    public abstract class ComponentBase
    {
        private Components _componentsInstance;

        protected Components Components
        {
            get
            {
                return _componentsInstance ?? (_componentsInstance = Components.Access());
            }
        }
    }
}
