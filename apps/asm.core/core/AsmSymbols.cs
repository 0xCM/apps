//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Concurrent;
    using static core;

    public class AsmSymbols
    {
        static long Seq;

        static uint next()
            => (uint)inc(ref Seq);

        readonly ConcurrentDictionary<string,AsmSymbol> Lookup;

        public AsmSymbols()
        {
            Lookup = new();
        }

        public static AsmSymbol define(@string name, MemoryAddress location)
            => new AsmSymbol(next(), name, location);

        public AsmSymbol Mark(MemoryAddress location, @string name)
        {
            var symbol = define(name,location);
            Lookup[name] = symbol;
            return symbol;
        }

        public AsmSymbol this[@string name]
        {
            get
            {
                if(Lookup.TryGetValue(name, out var symbol))
                    return symbol;
                else
                    return AsmSymbol.Empty;
            }
        }

        public bool Locate(@string name, out MemoryAddress location)
        {
            if(Lookup.TryGetValue(name, out var symbol))
            {
                location = symbol.Location;
                return true;
            }
            else
            {
                location = MemoryAddress.Zero;
                return false;
            }
        }
    }
}