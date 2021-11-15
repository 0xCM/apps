//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmPrefixCodes;
    using static AsmOpCodeTokens;

    [ApiHost]
    public readonly partial struct AsmPrefix
    {
        public static uint RexTable(ITextBuffer dst)
        {
            var bits = RexPrefix.Range();
            var count = bits.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(describe(skip(bits,i)));
            return (uint)count;
        }

        public static string describe(RexPrefix src)
        {
            const string RexFieldPattern = "[W:{0} | R:{1} | X:{2} | B:{3}]";
            var bits = text.format(BitRender.render8x4(src.Encoded));
            var bitfield = string.Format(RexFieldPattern, src.W(), src.R(), src.X(), src.B());
            return $"{src.Encoded.FormatAsmHex()} | [{bits}] => {bitfield}";
        }

        [MethodImpl(Inline), Op]
        public static MandatoryPrefix mandatory(MandatoryPrefixCode code)
            => new MandatoryPrefix(code);

        [MethodImpl(Inline), Op]
        public static AsmPrefixCode encoded(uint src)
            => new AsmPrefixCode(src);

        // RexBBits:[Index[00000] | Token[000]]
        [MethodImpl(Inline), Op]
        public static RexB rexb(RexBToken token, RegIndexCode r)
            => new RexB(token,r);

        [MethodImpl(Inline), Op]
        public static RexPrefix rex(uint4 wrxb)
            => math.or((byte)RexPrefixCode.Base, (byte)wrxb);

        [MethodImpl(Inline), Op]
        public static RexPrefix rex(bit w, bit r, bit x, bit b)
        {
            var bx = math.slor((byte)b, 0, (byte)x, 1);
            var rw = math.slor((byte)r, 2, (byte)w, 3);
            return math.or(bx, rw, rex());
        }

        [MethodImpl(Inline), Op]
        public static RexPrefix rex()
            => (byte)RexPrefixCode.Base;

        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind)
            => new VexPrefix(kind);

        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind, byte b1)
            => new VexPrefix(kind, b1);

        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind, byte b1, byte b2)
            => new VexPrefix(kind, b1, b2);

        [MethodImpl(Inline), Op]
        public static BndPrefix bnd()
            => BndPrefixCode.BND;

        [MethodImpl(Inline), Op]
        public static BranchHintPrefix hint(bit bt)
            => bt ? BranchHintCode.BT : BranchHintCode.BNT;

        [MethodImpl(Inline), Op]
        public static SizeOverrides sizes(bit opsz, bit adsz)
            => new SizeOverrides(opsz,adsz);

    }
}