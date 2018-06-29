namespace CheeseCatMouse
{
    public class Cheese
    {
        private string myType;

        public string Type
        {
            get
            {
                return myType;
            }
            set
            {
                myType = value;
            }
        }

        public Cheese( string type )
        {
            myType = type;
        }
    }
}