//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public class CoffObjInfo
    {
        Dictionary<string, List<CoffSymbol>> SymbolLookup;

        public CoffObj Source {get;}

        Index<TextLine> Data {get;}

        public string FormatKind {get; internal set;}

        public CoffObjInfo(CoffObj src, TextLine[] data)
        {
            Source = src;
            Data = data;
            SymbolLookup = new();
            FormatKind = EmptyString;
        }

        public void AddSymbol(in CoffSymbol src)
        {
            if(SymbolLookup.TryGetValue(src.Name, out var bucket))
            {
                bucket.Add(src);
            }
            else
            {
                bucket = core.list<CoffSymbol>();
                bucket.Add(src);
                SymbolLookup[src.Name] = bucket;
            }
        }

        public ReadOnlySpan<TextLine> DataLines
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Source.IsNonEmpty && Data.Count != 0;
        }

        public static CoffObjInfo Empty
            = new CoffObjInfo(CoffObj.Empty, sys.empty<TextLine>());
    }
}