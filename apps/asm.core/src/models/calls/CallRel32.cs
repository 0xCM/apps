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
        public MemoryAddress ClientAddress {get;}

        public Address32 TargetDx {get;}

        [MethodImpl(Inline)]
        public CallRel32(MemoryAddress client, Address32 dx)
        {
            ClientAddress = client;
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
            get => ClientAddress + InstructionSize + TargetDx;
        }
    }
}