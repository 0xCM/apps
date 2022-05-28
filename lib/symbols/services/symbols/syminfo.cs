//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        [Op]
        public static Index<SymInfo> syminfo(ReadOnlySpan<Type> src)
        {
            var dst = list<SymInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(src,i);
                var symbols = untyped(type).View;
                for(var j=0u; j<symbols.Length; j++)
                {
                    ref readonly var symbol = ref skip(symbols,j);
                    var record = new SymInfo();
                    var tag = type.Tag<SymSourceAttribute>();
                    var nbk = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
                    record.TokenType = type.Name;
                    record.TokenKind = type.Name;
                    record.TokenClass = symbol.Class;
                    record.TokenSize = Sizes.measure(type);
                    record.Index = j;
                    record.Value = (symbol.Value,nbk);
                    record.Name = symbol.Name;
                    record.Expr = symbol.Expr;
                    record.Description = symbol.Description;
                    dst.Add(record);
                }
            }
            return dst.ToArray();
        }

        [Op]
        public static Index<SymInfo> syminfo<K>(ReadOnlySpan<Type> src)
            where K : unmanaged
        {
            var dst = list<SymInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(src,i);
                var symbols = untyped(type).View;
                for(var j=0u; j<symbols.Length; j++)
                {
                    ref readonly var symbol = ref skip(symbols,j);
                    var record = new SymInfo();
                    var tag = type.Tag<SymSourceAttribute>();
                    var nbk = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
                    var kind = tag.MapRequired(t => t.SymKind);
                    record.TokenType = type.Name;
                    record.TokenKind = kind.ToString();
                    record.TokenClass = symbol.Class;
                    record.TokenSize = Sizes.measure(type);
                    record.Index = j;
                    record.Value = (symbol.Value,nbk);
                    record.Name = symbol.Name;
                    record.Expr = symbol.Expr;
                    record.Description = symbol.Description;
                    dst.Add(record);
                }
            }
            return dst.ToArray();
        }

        [Op]
        public static Index<SymInfo> syminfo(Type src)
        {
            var symbols = Symbols.untyped(src).View;
            var count = symbols.Length;
            var tag = src.Tag<SymSourceAttribute>();
            var nbk = tag.MapValueOrDefault(t => t.NumericBase, NumericBaseKind.Base10);
            var buffer = alloc<SymInfo>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                ref var dst = ref seek(buffer,i);
                dst.TokenType = src.Name;
                dst.TokenClass = symbol.Class;
                dst.TokenKind = src.Name;
                dst.TokenSize = Sizes.measure(src);
                dst.Index = i;
                dst.Value = (symbol.Value, nbk);
                dst.Name =  symbol.Name;
                dst.Expr = symbol.Expr;
                dst.Description = symbol.Description;
            }
            return buffer;
        }

        public static Index<SymInfo> syminfo<E>()
            where E : unmanaged, Enum
                => syminfo(typeof(E));
    }
}