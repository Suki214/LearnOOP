using System;
using System.Collections;

namespace EffectiveCSharpPart6Demo
{
    public struct Customer:IComparable
    {
        private string myName;

        public string Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        private double myRevenue;

        public double Revene
        {
            get
            {
                return myRevenue;
            }
            set
            {
                myRevenue = value;
            }
        }

        public Customer( string name,double revenue )
        {
            myName = name;
            myRevenue = revenue;
        }

        //如果直接实现compareTO，那么每次比较都有可能发生boxing & UNboxing，效率低下
        //public int CompareTo( object obj )
        //{
        //    if(!( obj is Customer ))
        //    {
        //        throw new ArgumentException( "It is not a valid customer");
        //    }

        //    Customer comparedCustomer = (Customer) obj;
        //    return myName.CompareTo( comparedCustomer );
        //}

        //引入这个接口，那么只有用IComparable访问的时候才需要进行类型转换，
        //一般的会走CompareTo(Customer obj) section，类型不匹配直接编译错误
        int IComparable.CompareTo(object obj )
        {
            if(!(obj is Customer ))
            {
                throw new ArgumentException( "It is not a valid customer type");
            }

            Customer comparedCustomer = (Customer)obj;
            return myName.CompareTo(comparedCustomer );
        }

        public int CompareTo(Customer obj)
        {
            return myName.CompareTo( obj.Name );
        }

        public static bool operator >( Customer left, Customer right )
        {
            return left.CompareTo( right ) > 0;
        }
        public static bool operator <(Customer left, Customer right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >=(Customer left, Customer right)
        {
            return left.CompareTo(right) >= 0;
        }
        public static bool operator <=(Customer left, Customer right)
        {
            return left.CompareTo(right) <= 0;
        }

        private static RevenueComparer myRevenueComparer = null;

        public static IComparer RevenueComparer
        {
            get
            {
                if( myRevenueComparer is null )
                {
                    myRevenueComparer= new RevenueComparer();
                }

                return myRevenueComparer;
            }
        }
    }
}