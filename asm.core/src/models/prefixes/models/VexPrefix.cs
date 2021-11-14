//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using K = AsmPrefixCodes.VexPrefixKind;

    /// <summary>
    /// [ Byte1[R | vvvv | L | pp] | Byte0[11000101b=0xC5]]
    /// [ Byte2[W | vvvv | L | pp] | Byte1[R | X | B | mmmmm] | Byte0[11000100b=0xC4]]
    /// R - REX.R in one's complement form
    /// X - REX.X in one's complement form
    /// B - REX.B in one's complement form
    /// mmmmm
    /// 00001 => specifies 0F leading opcode byte
    /// 00010 => specifies 0F38 leading opcode byte
    /// 00011 => specifies 0F3A Leading opcode byte
    /// vvvv - specifies a register in one's complement form
    /// L - specifies a length
    /// 0 => a scalar or 128-bit vector
    /// 1 => a 256-bit vector
    /// pp - opcode extension
    /// 00 => None
    /// 01 => 66
    /// 10 => F3
    /// 11 => F2
    /// </summary>
    public struct VexPrefix
    {
        uint Data;

        [MethodImpl(Inline)]
        internal VexPrefix(K k)
        {
            Data = (byte)k;
        }

        [MethodImpl(Inline)]
        internal VexPrefix(K k, byte b1)
        {
            Data = Bitfields.join((byte)k,b1,0,2);
        }

        [MethodImpl(Inline)]
        internal VexPrefix(K k, byte b1, byte b2)
        {
            Data = Bitfields.join((byte)k, b1, b2,3);
        }

        public byte Size
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 24);
        }

        [MethodImpl(Inline)]
        public K Kind()
            => (K)Data;

        [MethodImpl(Inline)]
        public void Kind(K k)
            => Data = Bytes.inject((byte)k,0, ref Data);


        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct VexPrefix16
        {
            public byte B0;

            public byte B1;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct VecPrefix24
        {
            public byte B0;

            public byte B1;

            public byte B2;
        }
    }
}