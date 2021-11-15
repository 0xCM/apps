//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct CodeSymbolLookup
    {
        readonly Dictionary<ulong,CodeSymbol> Data;

        [MethodImpl(Inline)]
        internal CodeSymbolLookup(CodeSymbolKey[] src)
        {
            Data = src.Select(x => (x.Key,x.Symbol)).ToDictionary();
        }

        [MethodImpl(Inline)]
        public bool Search(ulong key, out CodeSymbol value)
            => Data.TryGetValue(key,out value);
    }
}