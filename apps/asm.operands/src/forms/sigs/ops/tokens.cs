//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmSigs
    {
        [MethodImpl(Inline), Op]
        public static AsmSigToken token(AsmSigTokenKind kind, byte value)
            => new AsmSigToken(kind,value);

        [MethodImpl(Inline), Op]
        public static AsmSigToken specialize(in AsmToken src)
            => new AsmSigToken((AsmSigTokenKind)src.KindValue, src.Value);

        public static AsmToken generalize(in Token<AsmSigTokenKind> src)
        {
            var dst = new AsmToken();
            var token = new AsmSigToken(src.Kind, (byte)src.Value);
            dst.ClassName = nameof(AsmSigToken);
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
            var src = typeof(AsmSigTokens).GetNestedTypes().Enums().Tagged<SymSourceAttribute>().SelectMany(x => Symbols.tokenize<AsmSigTokenKind>(x));
            var sigcount = src.Length;
            var buffer = alloc<AsmToken>(sigcount);
            for(var i=0u; i<sigcount; i++)
            {
                seek(buffer,i) = generalize(skip(src,i));
                seek(buffer,i).Id = i;
            }

            return buffer;
        }
    }
}