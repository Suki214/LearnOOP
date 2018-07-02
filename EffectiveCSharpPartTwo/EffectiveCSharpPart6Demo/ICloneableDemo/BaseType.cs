using System;

namespace ICloneableDemo
{
    class BaseType : ICloneable
    {
        private string myLabel;
        private int[] myValue;

        //provide constructor method for serived class to implement, then the derived class can have the right clone
        public BaseType()
        {
            myLabel = "Class Name";
            myValue = new int[ 10 ];
        }

        public BaseType( BaseType right )
        {
            myLabel = right.myLabel;
            myValue = right.myValue.Clone() as int[];
        }

        public object Clone()
        {
            BaseType rVal = new BaseType();
            rVal.myLabel = myLabel;
            for( int i = 0; i < myValue.Length; i++ )
            {
                rVal.myValue[ i ] = myValue[ i ];
            }

            return rVal;
        }
    }
}