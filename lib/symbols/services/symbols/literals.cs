//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct Symbols
    {
        public static ReadOnlySpan<SymLiteralRow> literals<E>()
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
        public static ReadOnlySpan<SymLiteralRow> literals(Index<Assembly> src)
        {
            var kvTypes = Enums.types(src).View;
            var partCount = kvTypes.Length;
            var dst = list<SymLiteralRow>();
            for(var i=0; i<partCount; i++)
            {
                var types = skip(kvTypes,i).View;
                var kTypes = types.Length;
                for(var j=0u; j<kTypes; j++)
                {
                    (var asm, var type) = skip(types,j);
                    var syms = literals(type);
                    var kLits = syms.Length;
                    for(var k=0; k<kLits; k++)
                        dst.Add(syms[k]);
                }
            }
            return dst.ViewDeposited();
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static void fill<E>(ReadOnlySpan<Sym<E>> src, Span<SymLiteralRow> dst)
            where E : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                seek(dst, i) = untype(literal(skip(src,i), out _));
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        static SymLiteralRow untype<E>(in SymLiteral<E> src)
            where E : unmanaged
        {
            var dst = new SymLiteralRow();
            dst.Component = src.Component.SimpleName;
            dst.Type = src.Type;
            dst.Class = src.Class;
            dst.Position = src.Position;
            dst.Name = src.Name;
            dst.Symbol = src.Symbol;
            dst.DataType = src.DataType;
            dst.ScalarValue = src.ScalarValue;
            dst.Description = src.Description;
            dst.Hidden = src.Hidden;
            dst.Identity = src.Identity;
            return dst;
        }

        [Op]
        static void fill(Type type, PrimalKind kind, ReadOnlySpan<FieldInfo> fields, Span<SymLiteralRow> dst)
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
                row.ScalarValue = Enums.unbox(kind, f.GetRawConstantValue());
                row.Symbol = tag.MapValueOrDefault(a => a.Symbol, f.Name);
                row.Description = tag.MapValueOrDefault(a => a.Description, EmptyString);
                row.Hidden = f.Ignored();
            }
        }
    }
}