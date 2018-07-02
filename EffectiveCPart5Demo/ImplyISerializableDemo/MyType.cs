using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ImplyISerializableDemo
{
    public class MyType : ISerializable
    {
        private string myLabel;

        [NonSerialized]
        private int myValue1;

        private const int DEFAULT_VALUE = 5;
        private int myValue2;

        protected MyType( SerializationInfo info, StreamingContext ct )
        {
            myLabel = info.GetString( "myLabel" );
            try
            {
                myValue2 = info.GetInt32( "myValue2" );
            }
            catch( SerializationException )
            {
                myValue2 = DEFAULT_VALUE;
            }
        }

        [SecurityPermission( SecurityAction.Demand, SerializationFormatter = true )]
        void ISerializable.GetObjectData( SerializationInfo info, StreamingContext context )
        {
            info.AddValue( "myLabel", myLabel );
            info.AddValue( "myValue2", myValue2 );

            WriteObjectData( info, context );
        }

        protected virtual void WriteObjectData( SerializationInfo info, StreamingContext context ) {}
    }
}