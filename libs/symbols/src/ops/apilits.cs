//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class Symbolic
    {
        public static ReadOnlySeq<ApiLiteral> apilits(Assembly[] src)
        {
            var providers = src.Types().Tagged<LiteralProviderAttribute>()
                  .Select(x => (Type:x, Attrib:x.Tag<LiteralProviderAttribute>().Require()))
                  .Select(x => new LiteralProvider(x.Type.Assembly.Id(), x.Type, x.Attrib.Group, x.Type.Name)).Index();
            var literals = Symbolic.runtimelits(providers);
            var count = literals.Count;
            var dst = alloc<ApiLiteral>(count);
            for(var i=0u; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var literal = ref literals[i];
                target.Part = literal.Part;
                target.Type = literal.Type;
                target.Group = literal.Group;
                target.Name = literal.Name;
                target.Kind = literal.Kind.ToString();
                target.Value = literal.Value();
                target.Length = (uint)target.Value.Data.Length;
            }
            return dst.Sort();
        }
    }
}