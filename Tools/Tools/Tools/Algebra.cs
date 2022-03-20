//using System.Windows.Media.Imaging;
//using System.Windows.Media;
//Version 0.3

//You sould import from nuget the System.Drawing.Common
///Allow unsafe code in the project properties for the <seealso cref="Tools.Imageing.GenericImage.ToBitmap"/>()

using System;
using Tools.Extensions;

/// <summary>
/// Holds a veriaty of tools to handle efficent programms.
/// </summary>
namespace Tools
{
    public class Algebra
    {
        /// <summary>
        /// A already instanciated <see cref="Random"/> object.
        /// </summary>
        public static Random Random = new Random();

        /// <summary>
        /// Generates a Unique Randomized Guid.
        /// </summary>
        /// <returns></returns>
        public static Guid GenerateRandomGuid()
        {
            return new Guid(Random.Next(int.MinValue, int.MaxValue), (short)Random.Next(short.MinValue, short.MaxValue),
                (short)Random.Next(short.MinValue, short.MaxValue), (byte)Random.Next(byte.MinValue, byte.MaxValue),
                (byte)Random.Next(byte.MinValue, byte.MaxValue), (byte)Random.Next(byte.MinValue, byte.MaxValue)
                , (byte)Random.Next(byte.MinValue, byte.MaxValue), (byte)Random.Next(byte.MinValue, byte.MaxValue)
                , (byte)Random.Next(byte.MinValue, byte.MaxValue), (byte)Random.Next(byte.MinValue, byte.MaxValue)
                , (byte)Random.Next(byte.MinValue, byte.MaxValue));
        }
        /// <summary>
        /// returns true if the two <seealso cref="double"/>s are the same number untill the 3rd
        /// decimal digit.
        /// <para>
        /// for example:
        /// </para>
        /// <para>
        /// 1.3334 == 1.3335     =>true
        /// </para><para>
        /// 1.334 == 1.335       =>false
        /// </para>
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool AlmostEquals(double left, double right)
        {
            return left.ToDecimalPlaces(3) == right.ToDecimalPlaces(3);
        }
        /// <summary>
        /// return the upper rounding product of d.
        /// </summary>
        /// <param name="d">examples of inputs-outputs
        /// <para>
        /// 2=>2, 2.2=>3, 2.5=>3, 2.99=>3, -2=>-2, -2.5=>-2....
        /// </para>
        /// </param>
        /// <returns></returns>
        public static int Round(double d)
        {
            if (((int)d) - d != 0)
                return d < 0 ? (int)d : (int)(d + 1);
            return (int)d;
        }
    }
}