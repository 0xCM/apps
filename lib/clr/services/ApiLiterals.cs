//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;
    using L = ApiLiterals;

    [ApiHost]
    public readonly struct ApiLiterals
    {
        public static Index<CompilationLiteral> CompilationLiterals(Assembly[] src)
        {
            var result = Outcome.Success;
            var providers = L.providers(src).View;
            var count = providers.Length;
            var buffer = list<CompilationLiteral>();
            for(var i=0; i<count; i++)
            {
                ref readonly var provider = ref skip(providers,i);
                var literals = L.provided(provider).View;
                for(var j=0; j<literals.Length; j++)
                    buffer.Add(skip(literals,j).Specify());
            }

            return buffer.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static LiteralProvider provider(string name, Type def)
            => new LiteralProvider(name, def);

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

        public static string format(in RuntimeLiteral src)
            => string.Format("{0,-16} | {1,-16} | {2,-12} | {3}", src.Source, src.Name, src.Kind, value(src));

        [Op]
        public static RuntimeLiteralValue<string> value(in RuntimeLiteral src)
        {
            var value = EmptyString;
            if(src.Kind == ClrLiteralKind.String)
                value = ((StringAddress)src.Data).Format();
            else
                value = src.Data.ToString();
            return new RuntimeLiteralValue<string>(value);
        }

        [Op]
        public static CompilationLiteral specify(in RuntimeLiteral src)
        {
            var dst = default(CompilationLiteral);
            dst.Source = src.Source.Format();
            dst.Name = src.Name.Format();
            dst.Kind = src.Kind.ToString();
            dst.Value = src.Value();
            dst.Length = (uint)dst.Value.Data.Length;
            return dst;
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

        public static Index<RuntimeLiteral> provided(Type def)
        {
            var tag = def.Tag<LiteralProviderAttribute>();
            if(tag)
            {
                var name = def.Name;
                return provided(provider(name, def));
            }
            else
                return Index<RuntimeLiteral>.Empty;
        }

        [Op]
        public static Index<RuntimeLiteral> provided(LiteralProvider src)
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
    }
}