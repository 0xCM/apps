//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedFields
    {
        public struct XedRegs
        {
            ByteBlock32 Storage;

            [MethodImpl(Inline)]
            public XedRegs(params XedRegId[] src)
            {
                Storage = ByteBlock32.Empty;
                var count = (byte)src.Length;
                for(byte i=0; i<count; i++)
                    Reg(i, skip(src,i));
                RegCount() = count;
            }

            [MethodImpl(Inline)]
            internal ref XedRegId Reg(byte index, XedRegId src)
                => ref seek(recover<XedRegId>(Storage.Bytes),index);

            [MethodImpl(Inline)]
            internal ref byte RegCount()
                => ref Storage[31];

            public byte Count
            {
                [MethodImpl(Inline)]
                get => RegCount();
            }

            public ref readonly XedRegId this[byte index]
            {
                [MethodImpl(Inline)]
                get => ref seek(recover<XedRegId>(Storage.Bytes),index);
            }

            public static XedRegs Empty => default;
        }
    }
}