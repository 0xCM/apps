//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiMd
    {
        public static Index<CompilationLiteral> literals(Assembly[] src)
        {
            var providers = src.Types().Tagged<LiteralProviderAttribute>()
                  .Select(x => (Type:x, Attrib:x.Tag<LiteralProviderAttribute>().Require()))
                  .Select(x => new LiteralProvider(x.Type.Assembly.Id(), x.Type, x.Attrib.Group, x.Type.Name)).Index();
            var literals = ApiMd.literals(providers);
            var count = literals.Count;
            var dst = alloc<CompilationLiteral>(count);
            for(var i=0u; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                ref readonly var literal = ref literals[i];
                target.Part = literal.Part;
                target.Type = literal.Type.Format();
                target.Group = literal.Group.Format();
                target.Name = literal.Name.Format();
                target.Kind = literal.Kind.ToString();
                target.Value = literal.Value();
                target.Length = (uint)target.Value.Data.Length;
            }
            return dst.Sort();
        }

        static Index<RuntimeLiteral> literals(Index<LiteralProvider> src)
        {
            var providers = src.Select(provider => (Provider: provider, Fields: provider.Type.LiteralFields().Index()));
            var count = providers.Storage.Select(x => x.Fields.Count).Sum();
            var dst = alloc<RuntimeLiteral>(count);
            var k=0u;
            for(var i=0; i<providers.Count; i++)
            {
                ref readonly var provided = ref providers[i];
                var provider = provided.Provider;
                var fields = provided.Fields;
                for(var j=0; j<fields.Count; j++, k++)
                {
                    ref readonly var field = ref fields[j];
                    var datatype = field.FieldType;
                    var host = field.DeclaringType;
                    var value = field.GetRawConstantValue();
                    var lk = ClrLiteralKind.None;
                    var data = 0ul;
                    if(datatype.IsEnum)
                    {
                        lk = (ClrLiteralKind)Enums.@base(datatype);
                        data = ClrLiterals.serialize(value,lk);
                    }
                    else
                    {
                        lk = (ClrLiteralKind)PrimalBits.kind(datatype);
                        data = ClrLiterals.serialize(value,lk);
                    }
                    seek(dst,k) = new (host.Assembly.Id(), provider.Group, ClrLiterals.name(host), ClrLiterals.name(field), data, lk);
                }
            }
            return dst;
        }
    }
}