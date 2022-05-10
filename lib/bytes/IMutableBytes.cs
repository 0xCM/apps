//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// A <see cref='IByteSequence'/> with mutable cells
    /// </summary>
    [Free]
    public interface IMutableBytes : IByteSeq
    {
        Span<byte> Edit {get;}

        new ref byte this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,i);
        }

        new ref byte this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,i);
        }
    }
}