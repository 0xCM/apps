//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public class RegResolvers
        {
            static ConcurrentDictionary<string, int> _Resolvers = new();

            static ConcurrentDictionary<int, string> _ResolverLookup = new();

            static int _ResolverSeq = 0;

            [MethodImpl(Inline)]
            static int ResolverSeq()
                => inc(ref _ResolverSeq);

            public static RegResolver resolver(string src)
            {
                var id =  _Resolvers.GetOrAdd(src, _ => ResolverSeq());
                _ResolverLookup.TryAdd(id,src);
                return new RegResolver(id);
            }

            public static string name(RegResolver src)
                => src.ResolverId >=0 ? _ResolverLookup[src.ResolverId] : EmptyString;
        }
    }
}