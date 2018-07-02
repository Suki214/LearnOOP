using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveCSharpPart6Demo
{
    public class RevenueComparer:IComparer
    {
        int IComparer.Compare( object left, object right )
        {
            if( !(left is Customer) )
            {
                throw new ArgumentException( "x is not a valid customer" );
            }

            if (!(right is Customer))
            {
                throw new ArgumentException( "x is not a valid customer" );
            }

            Customer leftCustomer = (Customer) left;
            Customer rightCustomer = (Customer) right;

            return leftCustomer.Revene.CompareTo( rightCustomer.Revene );
        }
    }
}
