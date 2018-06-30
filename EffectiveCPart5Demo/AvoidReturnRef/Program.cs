namespace AvoidReturnRef
{
    class Program
    {
        static void Main( string[] args )
        {
            var myData = new MyBusinessObject();
            myData.BindingList.Clear();
            myData.CollectionData.Clear();
        }
    }
}