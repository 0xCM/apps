// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;

    public sealed class InlineSigInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        byte[] _signature;

        internal InlineSigInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public byte[] Signature
            => _signature ?? (_signature = _resolver.AsSignature(Token));

        public int Token { get; }

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineSigInstruction(this);
    }
}