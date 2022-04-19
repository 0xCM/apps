//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

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
            dst.SymbolKind = src.Tag<SymSourceAttribute>().MapValueOrElse(x => x.SymGroup, () => EmptyString);
            for(var i=0; i<count; i++)
            {
                ref readonly var spec = ref specs[i];
                dst.Symbols[i] = spec.Expr;
                dst.Names[i] = spec.Name;
                dst.Values[i] = spec.Value;
                dst.Descriptions[i] = spec.Description;
                dst.Kinds[i] = spec.Description.Format();
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
                dst.Kinds[i] = EmptyString;

            }
            return dst;
        }
    }
}