namespace Alexon.Chemistry.Elements.Base
{
    public class Element<T> where T : Atom
    {
        public static T Create()
        {
            T element = Activator.CreateInstance<T>();

            return element;
        }

    }
}
