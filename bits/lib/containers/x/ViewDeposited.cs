//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Reflection.Emit;
    using System.Reflection;

    using static core;

    partial class XTend
    {
        /// <summary>
        /// Extracts the underlying buffer (without reallocation)
        /// </summary>
        /// <param name="list">The source list</param>
        /// <typeparam name="T">The element type</typeparam>
        public static T[] Storage<T>(this List<T> list)
            => ArrayList<T>.Getter(list);

        public static ReadOnlySpan<T> ViewDeposited<T>(this List<T> src)
        {
            var count = src.Count;
            var storage = @readonly(src.Storage());
            return slice(storage,0,count);
        }

        public static Span<T> EditDeposited<T>(this List<T> src)
        {
            var count = src.Count;
            var storage = @span(src.Storage());
            return slice(storage,0,count);
        }
    }

    static class ArrayList<T>
    {
        public static Func<List<T>, T[]> Getter;

        /// <summary>
        /// Cribbed this from https://stackoverflow.com/questions/4972951/listt-to-t-without-copying
        /// </summary>
        static ArrayList()
        {
            var attribs = MethodAttributes.Static | MethodAttributes.Public;
            var cc = CallingConventions.Standard;
            var dm = new DynamicMethod("get", attribs, cc, typeof(T[]), new Type[] { typeof(List<T>) }, typeof(ArrayList<T>), true);
            var il = dm.GetILGenerator();

            // Load List<T> argument
            il.Emit(OpCodes.Ldarg_0);
            // Replace argument by field
            il.Emit(OpCodes.Ldfld, typeof(List<T>).GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance));
            // Return field
            il.Emit(OpCodes.Ret);

            Getter = (Func<List<T>, T[]>)dm.CreateDelegate(typeof(Func<List<T>, T[]>));
        }
    }
}