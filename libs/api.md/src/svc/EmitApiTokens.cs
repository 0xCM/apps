//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiMd
    {
        public Index<SymInfo> EmitApiTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = ApiTargets().Table<SymInfo>(tokens + "." +  name);
            TableEmit(syms, dst, TextEncodingKind.Unicode);
            return syms;
        }

        public ConstLookup<string,Index<SymInfo>> EmitApiTokens()
        {
            ApiTargets(tokens).Clear();
            var lookup = ApiTokens;
            var names = lookup.Keys;
            for(var i=0; i<names.Length; i++)
                EmitApiTokens(skip(names,i), lookup[skip(names,i)]);
            return lookup;
        }

        public Index<SymInfo> EmitApiTokens(ITokenGroup src, FS.FilePath dst)
        {
            var data = Symbols.syminfo(src.TokenTypes);
            TableEmit(data, dst, TextEncodingKind.Unicode);
            return data;
        }

        void EmitApiTokens(string name, Index<SymInfo> src)
            => TableEmit(src, ApiTargets(tokens).Table<SymInfo>(name), TextEncodingKind.Unicode);
    }
}