//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        public static Index<RuntimeLiteral> runtime(Type def)
        {
            var tag = def.Tag<LiteralProviderAttribute>();
            if(tag)
            {
                var name = def.Name;
                return runtime(provider(name, def));
            }
            else
                return Index<RuntimeLiteral>.Empty;
        }

        public static Index<RuntimeLiteral> runtime(LiteralProvider src)
        {
            var fields = src.Definition.LiteralFields().Public().ToReadOnlySpan();
            var count = fields.Length;
            var buffer = alloc<RuntimeLiteral>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                ref var provided = ref seek(dst,i);
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

                seek(dst,i) = new RuntimeLiteral(src.Part, ClrLiterals.name(field.DeclaringType), ClrLiterals.name(field), data, lk);
            }
            return buffer;
        }
    }
}