//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = ApiMdKind;

    partial class ApiMd
    {
        public Index<SymInfo> EmitApiTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = ApiTargets().Table<SymInfo>(tokens + "." +  name);
            AppSvc.TableEmit(syms, dst, TextEncodingKind.Unicode);
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
            AppSvc.TableEmit(data, dst);
            return data;
        }

        void EmitApiTokens(string name, Index<SymInfo> src)
            => AppSvc.TableEmit(src, ApiTargets(tokens).Table<SymInfo>(name));

        Index<SymInfo> EmitApiTokens<E>(string scope)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, typeof(E).Name);
            AppSvc.TableEmit(src, dst);
            return src;
        }
    }
}