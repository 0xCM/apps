// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineVarInstruction : ILInlineInstruction
    {
        internal InlineVarInstruction(int offset, OpCode opCode, ushort ordinal)
            : base(offset, opCode)
        {
            Ordinal = ordinal;
        }

        public ushort Ordinal {get;}

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineVarInstruction(this);
    }
}