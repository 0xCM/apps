//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct DispSeg
        {
            public readonly DispSpec Spec;

            [MethodImpl(Inline)]
            public DispSeg(DispSpec kind)
            {
                Spec = kind;
            }

            public FieldKind Field
            {
                [MethodImpl(Inline)]
                get => FieldKind.DISP;
            }

            public byte Width
            {
                [MethodImpl(Inline)]
                get => (byte)((byte)Spec * 8);
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Spec == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Spec != 0;
            }

            public string Format()
                => XedRender.format(this);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static explicit operator byte(DispSeg src)
                => (byte)src.Spec;

            [MethodImpl(Inline)]
            public static explicit operator DispSeg(byte src)
                => new DispSeg((DispSpec)src);

            public static DispSeg Empty => default;
        }
    }
}
/* DISP_NT()::
	DISP_WIDTH=8 DISP[dddddddd]=*  ->	emit dddddddd emit_type=letters nbits=8
	DISP_WIDTH=16 DISP[dddddddddddddddd]=*  ->	emit dddddddddddddddd emit_type=letters nbits=16
	DISP_WIDTH=32 DISP[dddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddd emit_type=letters nbits=32
	DISP_WIDTH=64 DISP[dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd]=*  ->	emit dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd emit_type=letters nbits=64
 */
