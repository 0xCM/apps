//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
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
    }
}