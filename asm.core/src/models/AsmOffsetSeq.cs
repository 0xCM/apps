//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Pairs a sequence number with a memory offset
    /// </summary>
    public readonly struct AsmOffsetSeq
    {
        public uint Seq {get;}

        public uint Offset {get;}

        [MethodImpl(Inline)]
        public AsmOffsetSeq(uint seq, uint offset)
        {
            Seq = seq;
            Offset = offset;
        }

        [MethodImpl(Inline)]
        public AsmOffsetSeq Next()
            => new AsmOffsetSeq(Seq + 1, Offset);

        [MethodImpl(Inline)]
        public AsmOffsetSeq AccrueOffset(uint dx)
            => new AsmOffsetSeq(Seq + 1, Offset + dx);

        public static AsmOffsetSeq Zero
            => default(AsmOffsetSeq);

        [MethodImpl(Inline)]
        public static AsmOffsetSeq operator ++(AsmOffsetSeq src)
            => src.Next();

        [MethodImpl(Inline)]
        public static implicit operator AsmOffsetSeq((uint seq, uint offset) src)
            => new AsmOffsetSeq(src.seq, src.offset);
    }
}