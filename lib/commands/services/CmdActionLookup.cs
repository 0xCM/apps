//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    /// <summary>
    /// Correlates command names with command realizations
    /// </summary>
    public class CmdActionLookup
    {
        public static CmdActionLookup discover(ICmdProvider provider)
        {
            var type = provider.GetType();
            var actions = dict<string,CmdAction>();
            var src = type.InstanceMethods().Tagged<CmdOpAttribute>().Select(x => (x.Name, x));
            foreach(var (name, method) in src)
                actions.TryAdd(name,new CmdAction(name, provider,method));

            var lookup = CmdActionLookup.create();
            foreach(var (name,action) in actions)
                lookup.Add(action.Method.Tag<CmdOpAttribute>().MapValueOrDefault(m => m.CommandName, action.Method.Name), action);
            return lookup.Seal();
        }

        public static CmdActionLookup discover(ReadOnlySpan<ICmdProvider> providers)
        {
            var count = providers.Length;
            var lookups = alloc<CmdActionLookup>(count);
            for(var i=0; i<count; i++)
                seek(lookups,i) = discover(skip(providers,i));
            return join(lookups);
        }

        public static CmdActionLookup join(params CmdActionLookup[] src)
        {
            var dst = create();
            foreach(var lookup in src)
                foreach(var (k,v) in lookup.Pairs)
                    dst.Add(k,v);
            return dst.Seal();
        }

        public static CmdActionLookup create()
            => new CmdActionLookup();

        readonly Dictionary<string,CmdAction> Data;

        KeyValuePairs<string,CmdAction> Pairs;

        bool Sealed;

        CmdActionLookup()
        {
            Data = new();
            Pairs = KeyValuePairs<string,CmdAction>.Empty;
        }

        public bool Add(string spec, CmdAction runner)
        {
            if(Sealed)
                return false;
            else
                return Data.TryAdd(spec, runner);
        }

        public bool Find(string spec, out CmdAction runner)
        {
            runner = default;
            if(!Sealed)
                return false;
            return Data.TryGetValue(spec, out runner);
        }

        public CmdActionLookup Seal()
        {
            Pairs = Data.ToKVPairs();
            Sealed = true;
            return this;
        }

        public ReadOnlySpan<string> Specs
        {
            [MethodImpl(Inline)]
            get => Pairs.Keys.Sort();
        }

        public ReadOnlySpan<CmdAction> Actions
        {
            [MethodImpl(Inline)]
            get => Pairs.Values;
        }
    }
}