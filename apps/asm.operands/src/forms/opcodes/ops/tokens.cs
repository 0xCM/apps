//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmOpCodes
    {
        [MethodImpl(Inline), Op]
        public static AsmOcToken token(AsmOcTokenKind kind, byte value)
            => new AsmOcToken(kind,value);

        [MethodImpl(Inline), Op]
        public static AsmOcToken specialize(in AsmToken src)
            => new AsmOcToken((AsmOcTokenKind)src.KindValue, src.Value);

        public static AsmToken generalize(in Token<AsmOcTokenKind> src)
        {
            var dst = new AsmToken();
            var token = new AsmOcToken(src.Kind, (byte)src.Value);
            dst.Id = token.Id;
            dst.ClassName = nameof(AsmOcToken);
            dst.Value = (byte)src.Value;
            dst.KindName = src.Kind.ToString();
            dst.KindValue = (byte)src.Kind;
            dst.Index = (ushort)src.Key;
            dst.Name = src.Name;
            dst.Expression = src.Expr.Text;
            return dst;
        }

        public static Index<AsmToken> tokens()
        {
            var srcA = typeof(AsmOcTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>().SelectMany(x => Symbols.tokenize<AsmOcTokenKind>(x));
            var srcB = Symbols.tokenize(typeof(Hex8Kind));
            var count = srcA.Length + srcB.Length;
            var dst = alloc<AsmToken>(count);
            var j=0u;
            for(var i=0; i<srcA.Length; i++, j++)
            {
                ref readonly var t = ref skip(srcA,i);
                ref var token = ref seek(dst,j);
                token = generalize(t);
                token.Seq = j;
            }

            for(var i=0; i<srcB.Length; i++, j++)
            {
                ref readonly var item = ref srcB[i];
                ref var target = ref seek(dst,j);
                var token = new AsmOcToken(AsmOcTokenKind.Hex8, (byte)item.Value);
                target.Seq = j;
                target.Id = token.Id;
                target.ClassName = nameof(AsmOcToken);
                target.KindName = nameof(AsmOcTokenKind.Hex8);
                target.KindValue = (byte)token.Kind;
                target.Index = (ushort)item.Key;
                target.Name = item.Name;
                target.Value = token.Value;
                target.Expression = token.Value.FormatHex(specifier:false,uppercase:true);
            }

            var distinct = AsmTokens.unique(dst, out var dupe);
            if(!distinct)
                Errors.Throw(string.Format("{0} is not unique", dupe));

            return dst;
        }
    }
}