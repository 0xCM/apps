//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        [MethodImpl(Inline), Op]
        public static CompilationLiteral compilation(in RuntimeLiteral src)
        {
            var dst = CompilationLiteral.Empty;
            dst.Part = src.Part;
            dst.Type = src.Type.Format();
            dst.Name = src.Name.Format();
            dst.Kind = src.Kind.ToString();
            dst.Value = src.Value();
            dst.Length = (uint)dst.Value.Data.Length;
            return dst;
        }

        public static Index<CompilationLiteral> compilation(Assembly[] src)
        {
            var providers = Literals.providers(src);
            var count = providers.Count;
            var dst = list<CompilationLiteral>();
            for(var i=0; i<count; i++)
            {
                var lits = runtime(providers[i]);
                for(var j=0; j<lits.Length; j++)
                    dst.Add(compilation(lits[j]));
            }

            return dst.Index().Sort();
        }
    }
}