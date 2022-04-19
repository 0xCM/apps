//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    partial struct Root
    {
        internal static T @throw<T>([Caller] string caller = null, [Line] int? line = null, [File] string? path = null)
            => throw new Exception();

        public static NotSupportedException no<T>()
            => new NotSupportedException($"The type {typeof(T).Name} is not supported");

        public static T no<S,T>([Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            => Unsupported.raise<S,T>(caller, file, line);
    }
}