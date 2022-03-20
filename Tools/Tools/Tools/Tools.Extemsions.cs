﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
//Version 0.4.0.1

namespace Tools
{
    /// <summary>
    /// Holds a verity of extension methods that can be found very helpful.
    /// </summary>
    namespace Extensions
    {
        /// <summary>
        /// Holds a sorting style.
        /// </summary>
        public enum SortStyle
        {
            /// <summary>
            /// Avarage case: O(n*n)<para>Worst case: O(n*n)</para>
            /// </summary>
            Bubble_Sort = 0xB0B1E,
            /// <summary>
            /// Avarage case: O(n*logn)<para>Worst case: O(n*logn)</para>
            /// </summary>
            Merge_Sort = 0x17E78E,
            /// <summary>
            /// Avarage case: O(n*logn)<para>Worst case: O(n*logn)</para>
            /// </summary>
            Insertion_Sort = 0x1CE7,
            /// <summary>
            /// Randomizing the list until its sorted.
            /// <para>Best case: O(1)<para>Avarage case: O(n!)</para></para>
            /// </summary>
            Bogo_Sort = 0xB080

        }
        public static class Extensions
        {
            #region ArrayRanking
            /// <summary>
            /// returns a singel dimensional array that is an equivilant to the two dimensional array 'target'
            /// </summary>
            /// <param name="target"></param>
            /// <returns></returns>
            public static T[] Reduce<T>(this T[,] target)
            {
                var arr = new T[target.GetLength(0) * target.GetLength(1)];
                int index = 0;
                foreach (var item in target)
                {
                    arr[index++] = item;
                }
                return arr;
            }
            /// <summary>
            /// tries to return the one dimensional array 'targert' to its original two dimensional array.
            /// </summary>
            /// <param name="target"></param>
            /// <returns></returns>
            public static T[,] Expande<T>(this T[] target, int firstDimensionSize)
            {
                T[,] r = new T[firstDimensionSize, Algebra.Round(target.Length / firstDimensionSize)];
                int target_index = 0; ;
                for (int i = 0; i < firstDimensionSize; i++)
                    for (int j = 0; j < r.GetLength(1); j++, target_index++)
                        r[i, j] = target[target_index];
                return r;
            }
            #endregion
            #region Sorting
            /// <summary>
            /// A method to use in the <see cref="Sort(T[], Compare)"/> which sorts two elements by the prefered propety.
            /// <para>
            /// should return True if item1 is "smaller" than item2.
            /// </para>
            /// <para>
            /// If returns the opposite it may reverse the order of the list.
            /// </para>
            /// </summary>
            /// <param name="item1"></param>
            /// <param name="item2"></param>
            /// <returns></returns>
            public delegate bool Compare<T>(T item1, T item2);
            /// <summary>
            /// Sorting the array with <see cref="Compare"/> as the logic of the comparing method.
            /// </summary>
            /// <param name="array"></param>
            /// <param name="method"></param>
            /// <returns></returns>
            public static IList<T> Sort<T>(this IList<T> array, Compare<T> method)
            {
                for (int i = 0; i < array.Count; i++)
                    for (int j = i; j < array.Count; j++)
                        if (method(array[j], array[i]))
                        {
                            array.Swap(j, i);
                        }
                return array;
            }
            /// <summary>
            /// Sorting this <see cref="IList{T}"/> object using <see cref="IComparable.CompareTo(T?)"/>
            /// </summary>
            /// <typeparam name="T">The type if this <see cref="IList{T}"/></typeparam>
            /// <param name="list">this object.</param>
            /// <param name="style">The sorting algoritm to use.</param>
            /// <returns></returns>
            public static IList<T> Sort<T>(this IList<T> list, SortStyle style) where T : IComparable
            {
                if (style == SortStyle.Merge_Sort)
                    return MergeSort(list);
                if (style == SortStyle.Insertion_Sort)
                    return InsertionSort(list);
                if (style == SortStyle.Bogo_Sort)
                    return BogoSort(list);
                return BubbleSort(list);
            }
            #region BogoSort
            private static IList<T> BogoSort<T>(this IList<T> list) where T : IComparable
            {
                Random rnd = new();
                for (int i = 0; i < (int)SortStyle.Bogo_Sort; i++)
                {
                    if (list.IsSorted())
                        return list;
                    list.Shuffle(rnd);
                }
                return list;
            }
            private static bool IsSorted<T>(this IList<T> list) where T : IComparable
            {
                if (list.Count == 0)
                    return true;
                var prev = list[0];
                for (int i = 1; i < list.Count; i++)
                    if (list[i].CompareTo(prev) < 0)
                        return false;
                return true;
            }
            #endregion
            #region InsertionSort
            /// <summary>
            /// Handles an insertion sort.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            /// <returns></returns>
            private static IList<T> InsertionSort<T>(IList<T> list) where T : IComparable
            {
                List<T> r = new();
                foreach (var item in list)
                {
                    r.InsertToSorted(item);
                }
                return r;
            }
            /// <summary>
            /// Inserting a variable to a sorted list.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            /// <param name="item"></param>
            private static void InsertToSorted<T>(this IList<T> list, T item) where T : IComparable
            {
                int ub = list.Count, lb = -1;
                while (ub - lb > 1)
                {
                    int index = (ub + lb) / 2;
                    int result = list[index].CompareTo(item);
                    if (result == 0)
                    {
                        list.Insert(index, item);
                        return;
                    }
                    if (result > 0)
                        ub = index;
                    else
                        lb = index;
                }
                list.Insert(lb + 1, item);
            }
            #endregion
            #region MergeSort
            /// <summary>
            /// Merge sorts <paramref name="list"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            /// <returns></returns>
            private static IList<T> MergeSort<T>(IList<T> list) where T : IComparable
            {
                return mergesort(list);
            }
            /// <summary>
            /// <see cref="MergeSort{T}(IList{T})"/> helper.
            /// </summary>
            private static IList<T> mergesort<T>(IList<T> l1) where T : IComparable
            {
                if (l1.Count == 1)
                    return l1;
                List<T> left = new();
                left.AddRange(l1.SubList(0, l1.Count / 2));
                List<T> right = new();
                right.AddRange(l1.SubList(l1.Count / 2));
                left = mergesort(left) as List<T>;
                right = mergesort(right) as List<T>;
                return merge(right, left);
            }
            private static IList<T> merge<T>(List<T> l1, List<T> l2) where T : IComparable
            {
                List<T> r = new();
                while (l1.Count > 0)
                {
                    if (l2.Count == 0)
                    {
                        r.AddRange(l1);
                        return r;
                    }
                    if (l1[0].CompareTo(l2[0]) < 0)
                    {
                        r.Add(l1[0]);
                        l1.RemoveAt(0);
                    }
                    else
                    {
                        r.Add(l2[0]);
                        l2.RemoveAt(0);
                    }
                }
                r.AddRange(l2);
                return r;
            }
            #endregion
            #region BubbleSort
            /// <summary>
            /// bubble sorts the <paramref name="list"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="list"></param>
            private static IList<T> BubbleSort<T>(IList<T> list) where T : IComparable
            {
                for (int i = list.Count - 1; i > -1; i--)
                {
                    int maxI = i;
                    for (int j = i; j > -1; j--)
                    {
                        if (list[maxI].CompareTo(list[j]) < 0)
                            maxI = j;
                    }
                    list.Swap(maxI, i);
                }
                return list;
            }
            #endregion
            #endregion
            #region Listing
            /// <summary>
            /// Returns an array which his elements are a sub-sequence of this array.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="me"></param>
            /// <param name="startIndex">The index to start to copy this array from.</param>
            /// <param name="length">The length of the sub array.</param>
            /// <returns></returns>
            public static IEnumerable<T> SubList<T>(this IEnumerable<T> me, int startIndex = 0, int length = -1)
            {
                if (length < 0)
                    length = me.Count() - startIndex;
                T[] r = new T[length];
                for (int i = 0; i < length; i++)
                    r[i] = me.ElementAt(i + startIndex);
                return r;
            }
            /// <summary>
            /// Swaps the elements in <paramref name="index1"/> and <paramref name="index2"/>
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="me"></param>
            /// <param name="index1"></param>
            /// <param name="index2"></param>
            public static void Swap<T>(this IList<T> me, int index1, int index2)
            {
                var temp = me[index1];
                me[index1] = me[index2];
                me[index2] = temp;
            }
            /// <summary>
            /// Shuffles this List.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="me"></param>
            /// <param name="rnd"></param>
            public static void Shuffle<T>(this IList<T> me, Random rnd = null)
            {
                if (rnd is null)
                    rnd = new Random();
                int length = me.Count;
                for (int i = 0; i < length; i++)
                {
                    me.Swap(i, rnd.Next(0, length));
                }
            }
            /// <summary>
            /// Returns a string that represents this <see cref="IEnumerable{T}"/> with human-friendly syntax.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="toStringLogic">Overloading the string represntive method of each element.</param>
            /// <returns></returns>
            public static string ToString<T>(this IEnumerable<T> me, Func<T, string> toStringLogic = null)
            {
                string r = " {";
                if (toStringLogic is null)
                    foreach (var item in me)
                    {
                        if (item is ValueType)
                            r += item + ", ";
                        else
                            r += item.ToString() + ", ";
                    }
                else
                    foreach (var item in me)
                    {
                        r += toStringLogic(item) + ", ";
                    }
                return r + "}";
            }
            /// <summary>
            /// Returns this collection of <see cref="char"/>s as string.
            /// </summary>
            /// <param name="me">The <see cref="char"/> collection.</param>
            /// <returns></returns>
            public static string AsString(this IEnumerable<char> me)
            {
                string r = "";
                foreach (var item in me)
                {
                    r += item;
                }
                return r;
            }
            /// <summary>
            /// Adds the elements of the specified collection to the end of the <see cref="IList{T}"/>.
            /// </summary>
            /// <typeparam name="T">The generic type of the List collection</typeparam>
            /// <param name="me">The list to add to.</param>
            /// <param name="collection">The collection of elements to add.</param>
            /// <exception cref="ArgumentNullException">Collection is null</exception>
            public static void AddRange<T>(this IList<T> me, IEnumerable<T> collection)
            {
                if(me is List<T> l)
                {
                    l.AddRange(collection);
                    return;
                }
                foreach(var item in collection)
                {
                    me.Add(item);
                }
            }
            /// <summary>
            /// Returns a string which has the same characters as <paramref name="arr"/>
            /// </summary>
            /// <param name="arr">The <seealso cref="char"/>[] to convert.</param>
            /// <returns></returns>
            public static string AsString(this char[] arr)
            {
                return new string(arr);
            }
            /// <summary>
            /// Finds the index of the first instance in <paramref name="list"/> that follows
            /// the specifed condictions.
            /// </summary>
            /// <typeparam name="T">The type of the list.</typeparam>
            /// <param name="list">An Enumerable to look at.</param>
            /// <param name="predicate">A function that tells the conditions that the element should have.</param>
            /// <returns></returns>
            public static int Find<T>(this IEnumerable<T> list,Predicate<T> predicate)
            {
                for (int i = 0; i < list.Count(); i++)
                {
                    if (predicate.Invoke(list.ElementAt(i)))
                        return i;
                }
                return -1;
            }
            #endregion
            #region getters
            /// <summary>
            /// Returns the Maximum value of the <see cref="IEnumerable{T}"/>.
            /// </summary>
            /// <typeparam name="T">Should implement the <see cref="IComparable"/></typeparam>
            /// <param name="me"></param>
            /// <returns></returns>
            public static T GetMax<T>(this IEnumerable<T> me) where T : IComparable
            {
                T max = me.ElementAt(0);
                foreach (var item in me)
                    if (item.CompareTo(max) > 0)
                        max = item;
                return max;
            }
            /// <summary>
            /// Returns the Minumum value of the <see cref="IEnumerable{T}"/>.
            /// </summary>
            /// <typeparam name="T">Should implement the <see cref="IComparable"/></typeparam>
            /// <param name="me"></param>
            /// <returns></returns>
            public static T GetMin<T>(this IEnumerable<T> me) where T : IComparable
            {
                T min = me.ElementAt(0);
                foreach (var item in me)
                    if (item.CompareTo(min) < 0)
                        min = item;
                return min;
            }
            /// <summary>
            /// Returns the index of the 'biggest' element of the <see cref="IEnumerable{T}"/>.
            /// </summary>
            /// <typeparam name="T">Should implement the <see cref="IComparable"/></typeparam>
            /// <param name="me"></param>
            /// <returns></returns>
            public static int GetMaxIndex<T>(this IEnumerable<T> me) where T : IComparable
            {
                int maxIndex = 0;
                int length = me.Count();
                for (int i = 1; i < length; i++)
                {
                    if (me.ElementAt(i).CompareTo(me.ElementAt(maxIndex)) > 0)
                        maxIndex = i;

                }
                return maxIndex;
            }
            /// <summary>
            /// Returns the index of the 'minimum' value of the <see cref="IEnumerable{T}"/>.
            /// </summary>
            /// <typeparam name="T">Should implement the <see cref="IComparable"/></typeparam>
            /// <param name="me"></param>
            /// <returns></returns>
            public static int GetMinIndex<T>(this IEnumerable<T> me) where T : IComparable
            {
                int minIndex = 0;
                int length = me.Count();
                for (int i = 1; i < length; i++)
                {
                    if (me.ElementAt(i).CompareTo(me.ElementAt(minIndex)) < 0)
                        minIndex = i;

                }
                return minIndex;
            }
            #endregion
            #region ColorHandling
            /// <summary>
            /// Multiplies all <paramref name="color"/>'s values (except opacity) by <paramref name="number"/>
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            public static Color Multiply(this Color color, double number)
            {
                double[] d = new double[] { color.R * number, color.G * number, color.B * number };
                for (int i = 0; i < 3; i++)
                {
                    if (d[i] > 255)
                        d[i] = 255;
                    if (d[i] < 0)
                        d[i] = 0;
                }
                return Color.FromArgb(color.A, (int)d[0], (int)d[1], (int)d[2]);
            }
            /// <summary>
            /// Divides all <paramref name="color"/>'s values (except opacity) by <paramref name="number"/>
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            public static Color Divide(this Color color, double number)
            {
                return Multiply(color, 1 / number);
            }
            /// <summary>
            /// Adds <paramref name="number"/> to all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            public static Color Add(this Color color, int number)
            {
                int[] colors = new int[] { color.R + number, color.G + number, color.B + number };
                for (int i = 0; i < 3; i++)
                {
                    if (colors[i] > 255)
                        colors[i] = 255;
                    if (colors[i] < 0)
                        colors[i] = 0;
                }
                return Color.FromArgb(color.A, colors[0], colors[1], colors[2]);
            }
            /// <summary>
            /// Adds <paramref name="color1"/> to all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="color1"></param>
            /// <returns></returns>
            public static Color Add(this Color color, Color color1)
            {
                int[] colors = new int[] { color.R + color1.R, color.G + color1.G, color.B + color1.B };
                for (int i = 0; i < 3; i++)
                {
                    if (colors[i] > 255)
                        colors[i] = 255;
                    if (colors[i] < 0)
                        colors[i] = 0;
                }
                return Color.FromArgb(color.A, colors[0], colors[1], colors[2]);
            }
            /// <summary>
            /// Subs <paramref name="number"/> from all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="number"></param>
            /// <returns></returns>
            public static Color Sub(this Color color, int number)
            {
                return Add(color, 0 - number);
            }
            /// <summary>
            /// Subs <paramref name="color1"/> from all <paramref name="color"/>'s values. (except opecity)
            /// </summary>
            /// <param name="color"></param>
            /// <param name="color1"></param>
            /// <returns></returns>
            public static Color Sub(this Color color, Color color1)
            {
                return Add(color, color1.Multiply(-1));
            }
            /// <summary>
            /// Gets the 32-bit ARGB value of this <see cref="Color"/> structure as <see cref="uint"/>.
            /// </summary>
            /// <param name="color">extended instance.</param>
            /// <returns>The 32-bit ARGB value of this <see cref="Color"/>.</returns>
            public static uint ToUArgb(this Color color)
            {
                unchecked
                {
                    return (uint)color.ToArgb();
                }
            }
            #endregion
            #region Reflecting
            public static IEnumerable<Type> GetAllDerivedClasses(this Type type,IEnumerable<Assembly> Assemblies)
            {
                List<Type> r = new List<Type>();
                //Assemblies = Assemblies.ToDictionary<Assembly,int>();
                foreach(var a in Assemblies)
                {
                    var add=a.GetTypes().Where((cl) => { return cl.IsClass && cl.IsSubclassOf(type); });
                    r.AddRange(add);
                }
                return r;
            }
            public static IEnumerable<Type> GetAllDerivedClasses(this Type type)
            {
                var r = new List<Assembly>(){ Assembly.GetEntryAssembly(),Assembly.GetAssembly(type)};
                return type.GetAllDerivedClasses(r);
            }
            #endregion
            /// <summary>
            /// returns the distance between the two points.
            /// </summary>
            /// <param name="point1"></param>
            /// <param name="point"></param>
            /// <returns></returns>
            public static double Distance(this Point point1, Point point)
            {
                double dx = point.X - point1.X;
                double dy = point.Y - point1.Y;
                return Math.Sqrt(dx * dx + dy * dy);
            }
            #region Random
            /// <summary>
            /// Returns a random value of the <see cref="Enum"/> <paramref name="e"/>
            /// </summary>
            /// <param name="rnd">The random instance.</param>
            /// <param name="e">An instance of an <see cref="Enum"/> object.</param>
            /// <returns></returns>
            public static Enum Next(this Random rnd,Enum e)
            {
                var arr = Enum.GetValues(e.GetType());
                return arr.GetValue(rnd.Next(arr.Length)) as Enum;
            }
            /// <summary>
            /// Returns a random value of the <see cref="Enum"/> <paramref name="e"/>
            /// </summary>
            /// <param name="rnd">The random instance.</param>
            /// <param name="e">An instance of an <see cref="Enum"/> object.</param>
            /// <returns></returns>
            public static Enum Next(this Random rnd,Type enumType)
            {
                if (enumType.IsEnum == false)
                    throw new ArgumentException($"{nameof(enumType)} is NOT an Enum!");
                var arr = Enum.GetValues(enumType);
                return arr.GetValue(rnd.Next(arr.Length)) as Enum;
            }
            /// <summary>
            /// Return a random value of the <see cref="Enum"/> <typeparamref name="T"/>.
            /// </summary>
            /// <typeparam name="T">An <see cref="Enum"/> type.</typeparam>
            /// <param name="rnd">The <see cref="Random"/> instance who gets the random value.</param>
            /// <returns></returns>
            public static T Next<T>(this Random rnd)where T : Enum
            {
                return (T)rnd.Next(typeof(T));
            }
            #endregion
            #region Primitievs
            /// <summary>
            /// Returns the number to the defined decimal places.
            /// </summary>
            /// <param name="num"></param>
            /// <param name="decimalPlaces"></param>
            /// <returns></returns>
            public static string ToDecimalPlaces(this double num,int decimalPlaces=0)
            {
                if (decimalPlaces < 0)
                    return num + "";
                return num.ToString("N" + decimalPlaces);
            }
            #endregion
        }

    }
}
