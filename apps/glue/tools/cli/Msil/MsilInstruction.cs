//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using ILOpCode = System.Reflection.Metadata.ILOpCode;

    /// <summary>
    /// Defines a cil instruction
    /// </summary>
    public readonly struct MsilInstruction
    {
        public ILOpCode OpCode {get;}

        public Index<byte> Args {get;}

        [MethodImpl(Inline)]
        public MsilInstruction(ILOpCode opcode, params byte[] args)
        {
            OpCode = opcode;
            Args = args;
        }
    }
}