// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public abstract class ILInlineInstruction
    {
        public int Offset {get;}
        
        public OpCode OpCode {get;}

        protected ILInlineInstruction(int offset, OpCode opCode)
        {
            Offset = offset;
            OpCode = opCode;
        }

        public abstract void Accept(ILInstructionVisitor visitor);
    }
}