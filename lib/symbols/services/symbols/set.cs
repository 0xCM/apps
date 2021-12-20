//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct Symbols
    {
        public static SymSet set(Type src)
        {
            var specs = Symbols.syminfo(src);
            var count = specs.Length;
            var type = Enums.@base(src);
            var dst = new SymSet((uint)count);
            var attrib = src.Tag<SymSourceAttribute>();
            dst.Name = src.Name;
            dst.DataType = type;
            dst.Flags = src.Tag<FlagsAttribute>().IsSome();
            dst.SymbolKind = src.Tag<SymSourceAttribute>().MapValueOrElse(x => x.SymKind, () => EmptyString);
            for(var i=0; i<count; i++)
            {
                ref readonly var sec = ref specs[i];
                dst.Symbols[i] = sec.Expr;
                dst.Names[i] = sec.Name;
                dst.Values[i] = sec.Value;
                dst.Descriptions[i] = sec.Description;
            }

            return dst;
        }

        public static SymSet set(Identifier name, ClrEnumKind @base, ReadOnlySpan<string> members)
        {
            var count = members.Length;
            var dst = new SymSet((uint)count);
            dst.Name = name;
            dst.DataType = @base;
            dst.SymbolKind = EmptyString;
            for(var i=0; i<count; i++)
            {
                ref readonly var member = ref skip(members,i);
                dst.Symbols[i] = member;
                dst.Names[i] = member;
                dst.Values[i] = i;
                dst.Descriptions[i] = EmptyString;
            }
            return dst;
        }
    }
}