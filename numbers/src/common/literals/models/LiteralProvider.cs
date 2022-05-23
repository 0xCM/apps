//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct LiteralProvider
    {
        [Op]
        public static string format<T>(in RuntimeLiteralValue<T> src)
            where T : IEquatable<T>
        {
            var data = src.Data.ToString();
            var content = data switch
            {
                RP.WinEol => "<weol>",
                RP.LinuxEol => "<leol>",
                RP.AsciNull => "<ascinull>",
                _ => data
            };
            return RP.ticks(content);
        }

        [Op]
        public static Index<LiteralProvider> providers(Assembly src)
            => providers(src.TaggedTypes<LiteralProviderAttribute>());

        [Op]
        public static Index<LiteralProvider> providers(Assembly[] src)
            => providers(src.TaggedTypes<LiteralProviderAttribute>());

        [MethodImpl(Inline), Op]
        static Index<LiteralProvider> providers(ReadOnlySpan<TaggedType<LiteralProviderAttribute>> types)
        {
            var count = types.Length;
            var buffer = alloc<LiteralProvider>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var tagged = ref skip(types,i);
                var type = tagged.Type;
                var name = tagged.Type.Name;
                seek(dst,i) = provider(name,type);
            }
            return buffer;
        }

        public static Index<CompilationLiteral> CompilationLiterals(Assembly[] src)
        {
            var result = Outcome.Success;
            var provide = providers(src);
            var count = provide.Length;
            var buffer = list<CompilationLiteral>();
            for(var i=0; i<count; i++)
            {
                var lits = literals(provide[i]);
                for(var j=0; j<lits.Length; j++)
                    buffer.Add(lits[j].Specify());
            }

            return buffer.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static LiteralProvider provider(string name, Type def)
            => new LiteralProvider(name, def);

        [MethodImpl(Inline), Op]
        public static LiteralProvider provider(Type def)
            => new LiteralProvider(def.Name, def);

        public static Index<RuntimeLiteral> literals(Type def)
        {
            var tag = def.Tag<LiteralProviderAttribute>();
            if(tag)
            {
                var name = def.Name;
                return literals(provider(name, def));
            }
            else
                return Index<RuntimeLiteral>.Empty;
        }

        [Op]
        public static Index<RuntimeLiteral> literals(LiteralProvider src)
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

                seek(dst,i) = new RuntimeLiteral(ClrLiterals.name(field.DeclaringType), ClrLiterals.name(field), data, lk);
            }
            return buffer;
        }

        public readonly string Name;

        public readonly Type Definition;

        [MethodImpl(Inline)]
        public LiteralProvider(string name, Type src)
        {
            Definition = src;
            Name = name;
        }
    }
}