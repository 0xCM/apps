// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineBrTargetInstruction : ILInlineInstruction
    {
        internal InlineBrTargetInstruction(int offset, OpCode opCode, int delta)
            : base(offset, opCode)
        {
            Delta = delta;
        }

        public int Delta {get;}
        
        public int TargetOffset 
            => Offset + Delta + 1 + 4;

        public override void Accept(ILInstructionVisitor visitor) 
            => visitor.VisitInlineBrTargetInstruction(this);
    }
}