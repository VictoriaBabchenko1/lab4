using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace lab4
{
    class MyComplex : IMyNumber<MyComplex>
    {
        private BigInteger re;
        private BigInteger im;

        public MyComplex(BigInteger re, BigInteger im)
        {
            this.re = re;
            this.im = im;
        }

        public override string ToString()
        {
            return $"{re}+{im}i";
        }

        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(re + that.re, im + that.im);
        }

        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(re - that.re, im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex((re * that.re) - (im * that.im), (im * that.re) + (re * that.im));
        }

        public MyComplex Divide(MyComplex that)
        {
            try
            {
                return new MyComplex(((re * that.re) + (im * that.im)) / (BigInteger.Pow(that.re, 2) + BigInteger.Pow(that.im, 2)),
                ((im * that.re) - (re * that.im)) / (BigInteger.Pow(that.re, 2) + BigInteger.Pow(that.im, 2)));
            }
            catch (Exception)
            {
                throw new DivideByZeroException("Devision by zero");
            }
        }
    }
}
