//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public readonly struct CaSymbolLookup
    {
        readonly Dictionary<ulong,CaSymbol> Data;

        [MethodImpl(Inline)]
        internal CaSymbolLookup(CaSymbolKey[] src)
        {
            Data = src.Select(x => (x.Key,x.Symbol)).ToDictionary();
        }

        [MethodImpl(Inline)]
        public bool Search(ulong key, out CaSymbol value)
            => Data.TryGetValue(key,out value);
    }
}