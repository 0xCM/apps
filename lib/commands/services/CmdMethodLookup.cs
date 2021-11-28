//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public class CmdMethodLookup
    {
        public static CmdMethodLookup join(params CmdMethodLookup[] src)
        {
            var dst = create();
            foreach(var lookup in src)
                foreach(var (k,v) in lookup.Pairs)
                    dst.Add(k,v);
            return dst.Seal();
        }

        public static CmdMethodLookup create()
            => new CmdMethodLookup();

        readonly Dictionary<string,MethodInfo> Data;

        KeyValuePairs<string,MethodInfo> Pairs;

        bool Sealed;

        CmdMethodLookup()
        {
            Data = new();
            Pairs = KeyValuePairs<string,MethodInfo>.Empty;
        }

        public bool Add(string spec, MethodInfo runner)
        {
            if(Sealed)
                return false;
            else
                return Data.TryAdd(spec, runner);
        }

        public bool Find(string spec, out MethodInfo runner)
        {
            runner = default;
            if(!Sealed)
                return false;
            return Data.TryGetValue(spec, out runner);
        }

        public CmdMethodLookup Seal()
        {
            Pairs = Data.ToKVPairs();
            Sealed = true;
            return this;
        }

        public ReadOnlySpan<string> Specs
        {
            [MethodImpl(Inline)]
            get => Pairs.Keys;
        }

        public ReadOnlySpan<MethodInfo> Methods
        {
            [MethodImpl(Inline)]
            get => Pairs.Values;
        }
    }
}