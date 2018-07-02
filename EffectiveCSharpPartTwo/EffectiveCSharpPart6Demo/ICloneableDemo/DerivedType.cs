using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneableDemo
{
    class DerivedType : BaseType, ICloneable
    {
        private double[] _Value;
        public DerivedType()
        {
            _Value = new double[ 10 ];
        }

        private DerivedType( DerivedType right ) : base( right )
        {
            _Value = right._Value.Clone() as double[];
        }

        public object Clone()
        {
            DerivedType dt = new DerivedType( this );
            return dt;
        }
    }
}
