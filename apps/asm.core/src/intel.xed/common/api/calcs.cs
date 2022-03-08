//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRegId;
    using static XedModels.EASZ;
    using static XedModels.SMode;

    partial struct XedModels
    {
        public static uint modes(EOSZ src)
            => src switch
            {
                EOSZ.EOSZ8 => 0,
                EOSZ.EOSZ16 => 1,
                EOSZ.EOSZ32 => 2,
                EOSZ.EOSZ64 => 3,
                EOSZ.EOSZNot16 => 0 | (2 << 8) | (3 << 16),
                EOSZ.EOSZNot64 => 0 | (1 << 8) | (2 << 16),
                _ => 0,
            };

        /// <summary>
        /// Creates a <see cref='AttributeVector'/> from a <see cref='AttributeKind'> sequence
        /// </summary>
        /// <param name="src">The source attributes</param>
        [MethodImpl(Inline), Op]
        public static AttributeVector vector(ReadOnlySpan<AttributeKind> src)
        {
            var length = min(src.Length, 8);
            var data = 0ul;
            if(length != 0)
            {
                ref var dst = ref uint8(ref data);
                ref readonly var a = ref first(src);
                for(byte i=0; i<length; i++)
                    seek(dst,i) = (byte)skip(a,i);
            }
            return new AttributeVector(data);
        }

        [Op]
        public static XedRegId ArAX(EASZ easz)
            => easz switch
            {
                EASZ16 => AX,
                EASZ32 => EAX,
                EASZ64 => RAX,
                _ => 0
            };

        [Op]
        public static XedRegId ArBX(EASZ easz)
            => easz switch
            {
                EASZ16 => BX,
                EASZ32 => EBX,
                EASZ64 => RAX,
                _ => 0
            };

        [Op]
        public static XedRegId ArCX(EASZ easz)
            => easz switch
            {
                EASZ16 => CX,
                EASZ32 => ECX,
                EASZ64 => RCX,
                _ => 0
            };

        [Op]
        public static XedRegId ArDX(EASZ easz)
            => easz switch
            {
                EASZ16 => DX,
                EASZ32 => EDX,
                EASZ64 => RDX,
                _ => 0
            };

        [Op]
        public static XedRegId ArSI(EASZ easz)
            => easz switch
            {
                EASZ16 => SI,
                EASZ32 => ESI,
                EASZ64 => RSI,
                _ => 0
            };

        [Op]
        public static XedRegId ArDI(EASZ easz)
            => easz switch
            {
                EASZ16 => DI,
                EASZ32 => EDI,
                EASZ64 => RDI,
                _ => 0
            };

        [Op]
        public static XedRegId ArSP(EASZ easz)
            => easz switch
            {
                EASZ16 => SP,
                EASZ32 => ESP,
                EASZ64 => RSP,
                _ => 0
            };

        [Op]
        public static XedRegId ArBP(EASZ easz)
            => easz switch
            {
                EASZ16 => BP,
                EASZ32 => EBP,
                EASZ64 => RBP,
                _ => 0
            };

        [Op]
        public static XedRegId SrSP(SMode easz)
            => easz switch
            {
                SMode16 => SP,
                SMode32 => ESP,
                SMode64 => RSP,
                _ => 0
            };

        [Op]
        public static XedRegId SrBP(SMode easz)
            => easz switch
            {
                SMode16 => BP,
                SMode32 => EBP,
                SMode64 => RBP,
                _ => 0
            };
    }
}