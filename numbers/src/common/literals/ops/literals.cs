//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        public static Index<CompilationLiteral> literals(Assembly[] src)
        {
            var providers = Literals.providers(src);
            var count = providers.Count;
            var dst = list<CompilationLiteral>();
            for(var i=0; i<count; i++)
            {
                var lits = runtime(providers[i].Definition);
                for(var j=0; j<lits.Length; j++)
                    dst.Add(compilation(lits[j]));
            }

            return dst.Index().Sort();
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            var dst = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new (skip(src,i).ToString(), skip(src,i));
            return dst;
        }

        static Index<Literal<T>> literals<T>(ReadOnlySpan<string> names, ReadOnlySpan<T> values)
        {
            var count = names.Length;
            Require.equal(count, values.Length);
            var literals = alloc<Literal<T>>(count);
            for(var i=0; i<count; i++)
                seek(literals,i) = new (skip(names,i), skip(values,i));
            return literals;
        }

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

        static Index<LiteralProvider> providers(Assembly[] src)
        {
            var types = src.Types().Tagged<LiteralProviderAttribute>().Index();
            var count = types.Count;
            var dst = alloc<LiteralProvider>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref types[i];
                var tag = type.Tag<LiteralProviderAttribute>().Require();
                seek(dst,i) = new (text.ifempty(tag.Group, type.Name), type, type.Assembly.Id());
            }
            return dst;
        }

        static Index<RuntimeLiteral> runtime(Type src)
        {
            var fields = src.LiteralFields().ToReadOnlySpan();
            var count = fields.Length;
            var dst = alloc<RuntimeLiteral>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var type = field.FieldType;
                var raw = field.GetRawConstantValue();
                var lk = ClrLiteralKind.None;
                var data = 0ul;
                if(type.IsEnum)
                {
                    var ekind = Enums.@base(type);
                    lk = (ClrLiteralKind)ekind;
                    data = ClrLiterals.serialize(raw,ekind);
                }
                else
                {
                    lk = (ClrLiteralKind)PrimalBits.kind(type);
                    data = ClrLiterals.serialize(raw,lk);
                }

                seek(dst,i) = new (src.Assembly.Id(), ClrLiterals.name(field.DeclaringType), ClrLiterals.name(field), data, lk);
            }
            return dst;
        }
    }
}