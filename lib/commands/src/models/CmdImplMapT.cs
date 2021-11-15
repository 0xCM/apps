//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public class CmdImplMap<T>
    {
        Dictionary<T,MethodInfo> Data;

        public CmdImplMap()
        {
            Data = new();
        }

        public ReadOnlySpan<T> Keys
            => Data.Keys.ToReadOnlySpan();

        [MethodImpl(Inline)]
        public bool Find(T cmd, out MethodInfo method)
            => Data.TryGetValue(cmd, out method);

        [MethodImpl(Inline)]
        public bool Add(T cmd, MethodInfo method)
            => Data.TryAdd(cmd, method);

        public MethodInfo this[T cmd]
        {
            [MethodImpl(Inline)]
            get => Data[cmd];

            [MethodImpl(Inline)]
            set => Data[cmd] = value;
        }
    }
}