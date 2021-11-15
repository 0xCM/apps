// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;
    public sealed class InlineNoneInstruction : ILInlineInstruction
    {
        internal InlineNoneInstruction(int offset, OpCode opCode)
            : base(offset, opCode) { }

        public override void Accept(ILInstructionVisitor visitor) 
            => visitor.VisitInlineNoneInstruction(this);
    }
}