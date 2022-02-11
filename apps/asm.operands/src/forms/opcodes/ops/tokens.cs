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
            dst.ClassName = nameof(AsmOcToken);
            dst.Value = (byte)src.Value;
            dst.KindName = src.Kind.ToString();
            dst.KindValue = (byte)src.Kind;
            dst.Index = (ushort)src.Key;
            dst.Name = src.Name;
            dst.Expression = token.Format();
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
                token.Id = j;
            }
            for(var i=0; i<srcB.Length; i++, j++)
            {
                ref readonly var item = ref srcB[i];
                ref var target = ref seek(dst,j);
                target.Id = j;
                target.ClassName = nameof(AsmOcToken);
                target.Value = (byte)item.Value;
                target.KindName = "Hex8";
                target.Index = (ushort)item.Key;
                target.Name = item.Name;
                target.Expression = target.Value.FormatHex(specifier:false,uppercase:true);
            }

            return dst;
        }

        public static bool token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);
    }
}