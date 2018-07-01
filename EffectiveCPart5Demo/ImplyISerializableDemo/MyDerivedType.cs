using System.Runtime.Serialization;

namespace ImplyISerializableDemo
{
    class MyDerivedType : MyType
    {
        private int myDerivedValue;

        private MyDerivedType( SerializationInfo info, StreamingContext ct ) : base( info, ct )
        {
            myDerivedValue = info.GetInt32( "myDerivedValue" );
        }

        protected override void WriteObjectData( SerializationInfo info, StreamingContext context )
        {
            info.AddValue( "myDerivedValue", myDerivedValue );
        }
    }
}