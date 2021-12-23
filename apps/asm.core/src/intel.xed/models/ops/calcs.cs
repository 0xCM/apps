//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static XedModels.RegId;
    using static XedModels.EASZ;
    using static XedModels.SMode;

    using T = XedModels.DataType;
    using W = DataWidth;

    partial struct XedModels
    {
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
        public static DataWidth width(DataType src)
            => src switch {
                T.I1 => W.W1,
                T.I8 => W.W8,
                T.I16 => W.W16,
                T.I32 => W.W32,
                T.I64 => W.W64,
                T.U8 => W.W8,
                T.U16 => W.W16,
                T.U32 => W.W32,
                T.U64 => W.W64,
                T.U128 => W.W128,
                T.U256 => W.W256,
                T.F32 => W.W32,
                T.F64 => W.W64,
                T.F80 => W.W80,
                T.B80 => W.W80,
                _ => W.None
            };

        [Op]
        public static RegId ArAX(EASZ easz)
            => easz switch
            {
                EaMode16 => AX,
                EaMode32 => EAX,
                EaMode64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArBX(EASZ easz)
            => easz switch
            {
                EaMode16 => BX,
                EaMode32 => EBX,
                EaMode64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArCX(EASZ easz)
            => easz switch
            {
                EaMode16 => CX,
                EaMode32 => ECX,
                EaMode64 => RCX,
                _ => 0
            };

        [Op]
        public static RegId ArDX(EASZ easz)
            => easz switch
            {
                EaMode16 => DX,
                EaMode32 => EDX,
                EaMode64 => RDX,
                _ => 0
            };

        [Op]
        public static RegId ArSI(EASZ easz)
            => easz switch
            {
                EaMode16 => SI,
                EaMode32 => ESI,
                EaMode64 => RSI,
                _ => 0
            };

        [Op]
        public static RegId ArDI(EASZ easz)
            => easz switch
            {
                EaMode16 => DI,
                EaMode32 => EDI,
                EaMode64 => RDI,
                _ => 0
            };

        [Op]
        public static RegId ArSP(EASZ easz)
            => easz switch
            {
                EaMode16 => SP,
                EaMode32 => ESP,
                EaMode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId ArBP(EASZ easz)
            => easz switch
            {
                EaMode16 => BP,
                EaMode32 => EBP,
                EaMode64 => RBP,
                _ => 0
            };

        [Op]
        public static RegId SrSP(SMode easz)
            => easz switch
            {
                SMode16 => SP,
                SMode32 => ESP,
                SMode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId SrBP(SMode easz)
            => easz switch
            {
                SMode16 => BP,
                SMode32 => EBP,
                SMode64 => RBP,
                _ => 0
            };
    }
}