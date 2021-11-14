//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Vol I, 4-6
    /// </summary>
    /// <remarks>
    /// Far pointers in 64-bit mode can be one of three forms:
    /// • 16-bit segment selector, 16-bit offset if the operand size is 32 bits
    /// • 16-bit segment selector, 32-bit offset if the operand size is 32 bits
    /// • 16-bit segment selector, 64-bit offset if the operand size is 64 bits
    /// </remarks>
    public readonly struct FarPtr
    {
        public Address16 Selector {get;}

        public ulong Offset {get;}

        [MethodImpl(Inline)]
        public FarPtr(Address16 selector, ulong offset)
        {
            Selector = selector;
            Offset = offset;
        }

        public BitWidth OffsetWidth
        {
            [MethodImpl(Inline)]
            get => bits.effsize(Offset)*8;
        }
    }
}