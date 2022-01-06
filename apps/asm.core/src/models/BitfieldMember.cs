//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct BitfieldMember
    {
        public string Name {get;}

        public byte MinIndex {get;}

        public byte MaxIndex {get;}

        public BitMask Mask {get;}

        [MethodImpl(Inline)]
        public BitfieldMember(string name, byte min, byte max, BitMask mask)
        {
            Name = name;
            MinIndex = min;
            MaxIndex = max;
            Mask = mask;
        }

        public byte SegWidth
        {
            [MethodImpl(Inline)]
            get => BitPatterns.segwidth(MinIndex,MaxIndex);
        }

        public string Format()
            => string.Format("{0}[{1}:{2}]", Name, MaxIndex, MinIndex);

        public override string ToString()
            => Format();
    }
}