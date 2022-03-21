//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        public static Index<SymLiteralRow> literals<E>()
            where E : unmanaged, Enum
        {
            var symbols = index<E>().View;
            var dst = alloc<SymLiteralRow>(symbols.Length);
            fill<E>(symbols, dst);
            return dst;
        }

        [Op]
        public static Index<SymLiteralRow> literals(Type src)
        {
            var fields = @readonly(src.LiteralFields());
            var dst = alloc<SymLiteralRow>(fields.Length);
            fill(src, PrimalBits.kind(src), fields, dst);
            return dst;
        }

        [Op]
        public static Index<SymLiteralRow> literals(Index<Type> src)
        {
            var dst = list<SymLiteralRow>();
            var kTypes = src.Count;
            for(var i=0; i<kTypes; i++)
                dst.AddRange(literals(src[i]));
            return dst.Array();
        }

        [Op]
        public static Index<SymLiteralRow> literals(Index<Assembly> src)
            => literals(Enums.types(src).OrderBy(src => src.Name));

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void fill<E>(ReadOnlySpan<Sym<E>> src, Span<SymLiteralRow> dst)
            where E : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst, i) = untype(literal(skip(src,i), out _));
        }

        [Op]
        static void fill(Type type, ClrPrimitiveKind kind, ReadOnlySpan<FieldInfo> fields, Span<SymLiteralRow> dst)
        {
            var count = fields.Length;
            var component = type.Assembly.GetSimpleName();
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                ref var row = ref seek(dst,i);
                var tag = f.Tag<SymbolAttribute>();
                row.Component = component;
                row.Type = type.Name;
                row.DataType = kind;
                row.Class = @class(type);
                row.Position = (ushort)i;
                row.Name = f.Name;
                row.Value = Enums.unbox(kind, f.GetRawConstantValue());
                row.NumericBase = NumericBaseKind.Base10;
                row.Symbol = tag.MapValueOrDefault(a => a.Symbol, f.Name);
                row.Description = tag.MapValueOrDefault(a => a.Description, EmptyString);
                row.Hidden = f.Ignored();
            }
        }
    }
}