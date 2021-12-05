//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public class SymSourceTypes
    {
        readonly Index<SymSourceType> Data;

        readonly Dictionary<string,SymSourceType> Index;

        internal SymSourceTypes(SymSourceType[] src)
        {
            Data = src;
            Index = new();
            foreach(var t in src)
            {
                Index.TryAdd(t.Name, t);
                var alias = t.Alias;
                var c = alias.Length;
                for(var i=0; i<c; i++)
                    Index.TryAdd(skip(alias,i), t);
            }
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public bool Find(string name, out SymSourceType dst)
            => Index.TryGetValue(name, out dst);

        public ReadOnlySpan<SymSourceType> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        [MethodImpl(Inline)]
        public static implicit operator SymSourceType[](SymSourceTypes src)
            => src.Data;

        public static SymSourceTypes Empty
            => new SymSourceTypes(sys.empty<SymSourceType>());
    }
}