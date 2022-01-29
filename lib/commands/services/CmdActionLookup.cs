//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    using static core;

    /// <summary>
    /// Correlates command names with command realizations
    /// </summary>
    public class CmdActionLookup
    {
        public static CmdActionLookup discover(ICmdProvider provider)
        {
            var type = provider.GetType();
            var actions = dict<string,CmdActionInvoker>();
            var src = type.InstanceMethods().Tagged<CmdOpAttribute>().Select(x => (x.Name, x));
            foreach(var (name, method) in src)
                actions.TryAdd(name,new CmdActionInvoker(name, provider, method));

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

        readonly Dictionary<string,CmdActionInvoker> Data;

        KeyValuePairs<string,CmdActionInvoker> Pairs;

        bool Sealed;

        CmdActionLookup()
        {
            Data = new();
            Pairs = KeyValuePairs<string,CmdActionInvoker>.Empty;
        }

        public bool Add(string spec, CmdActionInvoker runner)
        {
            if(Sealed)
                return false;
            else
                return Data.TryAdd(spec, runner);
        }

        public bool Find(string spec, out CmdActionInvoker runner)
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

        public ReadOnlySpan<CmdActionInvoker> Actions
        {
            [MethodImpl(Inline)]
            get => Pairs.Values;
        }
    }
}