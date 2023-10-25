using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace lab4
{
    class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        protected BigInteger nom;
        protected BigInteger denom;

        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (IsDenomValid(denom))
            {
                this.nom = nom;
                this.denom = denom;
                Simplify();
            }
        }

        public MyFrac(int nom, int denom)
        {
            if (IsDenomValid(denom))
            {
                this.nom = new BigInteger(nom);
                this.denom = new BigInteger(denom);
                Simplify();
            }
        }

        private bool IsDenomValid(BigInteger denom)
        {
            if (denom != 0)
            {
                return true;
            }
            else
            {
                throw new DivideByZeroException("The denominator must not contain zero value");
            }
        }
        private void Simplify()
        {
            BigInteger gcd = BigInteger.GreatestCommonDivisor(nom, denom);
            nom = nom / gcd;
            denom = denom / gcd;
        }
        
        public override string ToString()
        {
            return $"{nom}/{denom}";
        }

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(nom * that.denom + that.nom * denom, denom * that.denom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(nom * that.denom - that.nom * denom, denom * that.denom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(nom * that.nom, denom * that.denom);
        }

        public MyFrac Divide(MyFrac that)
        {
            try
            {
                return new MyFrac(nom * that.denom, denom * that.nom);
            }
            catch (Exception)
            {
                throw new DivideByZeroException("Devision by zero");
            }
        }

        public int CompareTo(MyFrac other)
        {
            //decimal thisDecimalValue = (decimal)nom / (decimal)denom;
            //decimal otherDecimalValue = (decimal)other.nom / (decimal)other.denom;

            //if (thisDecimalValue > otherDecimalValue)
            //{
            //    return 1;
            //}

            //if (thisDecimalValue < otherDecimalValue)
            //{
            //    return -1;
            //}

            //return 0;

            decimal thisDecimalValue = (decimal)nom / (decimal)denom;
            decimal otherDecimalValue = (decimal)other.nom / (decimal)other.denom;

            return thisDecimalValue.CompareTo(otherDecimalValue);
        }
    }
}
