//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Creates an instance of a type and casts the instance value as specified by a type parameter
        /// </summary>
        /// <typeparam name="T">The cast instance type</typeparam>
        /// <param name="t">The type for which an instance will be created</param>
        /// <param name="args">Arguments matched with/passed to an instance constructor defined by the type</param>
        [MethodImpl(Inline)]
        public static T Instantiate<T>(this Type t, params object[] args)
            => (T)Activator.CreateInstance(t, args);
    }
}