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

    using T = XedModels.DataType;
    using W = DataWidth;

    [ApiHost]
    public readonly partial struct XedModels
    {
        const string xed = nameof(xed);

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
                _ => 0
            };
    }
}