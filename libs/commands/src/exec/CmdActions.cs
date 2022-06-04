//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Correlates command names with command realizations
    /// </summary>
    public class CmdActions
    {
        public static CmdActionDispatcher dispatcher(ICmdProvider provider, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(discover(provider), fallback);

        public static CmdActionDispatcher dispatcher(ReadOnlySpan<ICmdProvider> providers, Func<string,CmdArgs,Outcome> fallback = null)
            => new CmdActionDispatcher(discover(providers), fallback);

        public static CmdActions discover(ICmdProvider provider)
        {
            var type = provider.GetType();
            var actions = dict<string,CmdActionInvoker>();
            var src = type.InstanceMethods().Tagged<CmdOpAttribute>().Select(x => (x.Name, x));
            foreach(var (name, method) in src)
                actions.TryAdd(name,new CmdActionInvoker(name, provider, method));

            var lookup = CmdActions.create();
            foreach(var (name,action) in actions)
                lookup.Add(action.Method.Tag<CmdOpAttribute>().MapValueOrDefault(m => m.CommandName, action.Method.Name), action);
            return lookup.Seal();
        }

        public static CmdActions discover(ReadOnlySpan<ICmdProvider> providers)
        {
            var count = providers.Length;
            var lookups = alloc<CmdActions>(count);
            for(var i=0; i<count; i++)
                seek(lookups,i) = discover(skip(providers,i));
            return join(lookups);
        }

        public static CmdActions join(params CmdActions[] src)
        {
            var dst = create();
            foreach(var lookup in src)
                foreach(var (k,v) in lookup.Pairs)
                    dst.Add(k,v);
            return dst.Seal();
        }

        public static CmdActions create()
            => new CmdActions();

        readonly Dictionary<string,CmdActionInvoker> Data;

        KeyValuePairs<string,CmdActionInvoker> Pairs;

        bool Sealed;

        CmdActions()
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

        public CmdActions Seal()
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