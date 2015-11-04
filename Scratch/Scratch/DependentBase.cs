namespace Scratch
{
    public abstract class DependentBase
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
