//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a sequence of regsters of uniform width
    /// </summary>
    public readonly struct RegSeqSpec
    {
        /// <summary>
        /// A surrogate key
        /// </summary>
        public uint Id {get;}

        /// <summary>
        /// The number of registers in the sequence
        /// </summary>
        public uint RegCount {get;}

        /// <summary>
        /// The size of each register
        /// </summary>
        public ByteSize RegSize {get;}

        [MethodImpl(Inline)]
        public RegSeqSpec(uint id, uint count, ByteSize size)
        {
            Id = id;
            RegCount = count;
            RegSize = size;
        }

        public string Format()
            => string.Format("{0}x{1}", RegCount, RegSize.Bits);

        public override string ToString()
            => Format();
    }
}