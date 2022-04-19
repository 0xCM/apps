// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineIInstruction : ILInlineInstruction
    {
        internal InlineIInstruction(int offset, OpCode opCode, int value)
            : base(offset, opCode)
        {
            Value = value;
        }

        public int Value {get;}

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineIInstruction(this);
    }
}