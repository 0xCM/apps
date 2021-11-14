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
    /// Represents a prefix encoding
    /// [Kind[24,27] | Encoding]
    /// </summary>
    public struct AsmPrefixCode
    {
        uint Data;

        [MethodImpl(Inline)]
        internal AsmPrefixCode(uint data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        public readonly AsmPrefixKind Kind()
            => (AsmPrefixKind)bits.segment(Data, 24, 27);

        [MethodImpl(Inline)]
        public void Kind(AsmPrefixKind kind)
            => bits.replace(Data, 24, 27, (uint)kind);

        [MethodImpl(Inline)]
        public uint Content()
            => bits.segment(Data,0,23);

        [MethodImpl(Inline)]
        public void Content(uint src)
            => bits.replace(Data,0,23,src);

        public uint Encoded
        {
            [MethodImpl(Inline)]
            get => Content();
        }
    }
}