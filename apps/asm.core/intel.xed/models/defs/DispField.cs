//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct DispField
        {
            public readonly DispKind Kind;

            [MethodImpl(Inline)]
            public DispField(DispKind kind)
            {
                Kind = kind;
            }

            public byte Width
            {
                [MethodImpl(Inline)]
                get => (byte)((byte)Kind * 8);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Kind == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Kind != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator DispField(DispKind src)
                => new DispField(src);

            [MethodImpl(Inline)]
            public static implicit operator DispKind(DispField src)
                => src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator byte(DispField src)
                => (byte)src.Kind;

            [MethodImpl(Inline)]
            public static explicit operator DispField(byte src)
                => new DispField((DispKind)src);

            public static DispField Empty => default;
        }
    }
}
/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */
