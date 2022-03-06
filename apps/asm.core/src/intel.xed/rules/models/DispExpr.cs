//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct DispExpr
        {
            public readonly DispExprKind Kind;

            [MethodImpl(Inline)]
            public DispExpr(DispExprKind kind)
            {
                Kind = kind;
            }

            public byte DispWidth
            {
                [MethodImpl(Inline)]
                get => (byte)Sizes.width((NativeSizeCode)Kind);
            }

            public string Format()
                => XedFormatters.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator DispExpr(DispExprKind src)
                => new DispExpr(src);

            [MethodImpl(Inline)]
            public static implicit operator DispExprKind(DispExpr src)
                => src.Kind;
        }
    }
}
/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */
