//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public sealed class TextMap
    {
        ConstLookup<string,string> Data;

        Index<IProduction> _Productions;

        internal TextMap(ConstLookup<string,string> src, IProduction[] productions)
        {
            Data = src;
            _Productions = productions;
        }

        public ReadOnlySpan<string> Inputs
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public ReadOnlySpan<IProduction> Productions
        {
            [MethodImpl(Inline)]
            get => _Productions;
        }

        public string Apply(string src)
        {
            if(Data.Find(src, out var dst))
                return dst;
            else
                return src;
        }
    }
}