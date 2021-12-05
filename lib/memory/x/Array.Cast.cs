//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XArray
    {
        /// <summary>
        /// Populates a target array by casting each elements of a source aray to the target element type
        /// </summary>
        /// <param name="src">The source array</param>
        /// <typeparam name="T"></typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] Cast<T>(this object[] src)
        {
            var count = src.Length;
            var buffer = new T[count];
            for(var i=0; i<count; i++)
                buffer[i] = (T)src[i];
            return buffer;
        }
    }
}