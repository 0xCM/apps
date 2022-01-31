//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CallRel32
    {
        public MemoryAddress IP {get;}

        public Address32 TargetDx {get;}

        [MethodImpl(Inline)]
        public CallRel32(MemoryAddress rip, Address32 dx)
        {
            IP = rip;
            TargetDx = dx;
        }

        public byte InstructionSize
        {
            [MethodImpl(Inline)]
            get => 5;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => IP + InstructionSize + TargetDx;
        }

        public string Format()
            => string.Format("{0}:{1} -> {2}", IP, TargetDx, TargetAddress);

        public override string ToString()
            => Format();

    }
}