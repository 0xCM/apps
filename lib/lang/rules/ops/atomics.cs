//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct rules
    {
        public static ConstLookup<string,Atoms<string>> atomics(FS.FilePath src)
        {
            var map = textmap(src);
            var productions = map.Productions;
            var count = productions.Length;
            var dst = dict<string,Atoms<string>>();
            for(var i=0; i<count; i++)
            {
                ref readonly var production = ref skip(productions,i);
                if(production.YieldsSeq)
                {
                    var list = production as SeqProduction;
                    var name = list.Source.Content;
                    var elements = core.map(list.Target.Terms, e => Terms.atom(e.Format()));
                    dst[name] = elements;
                }
                else
                {
                    var name = production.Source.Format();
                    dst[name] = array<Atom<string>>(Terms.atom(production.Target.Format()));
                }
            }
            return dst;
        }
    }
}