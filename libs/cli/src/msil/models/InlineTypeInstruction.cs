// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System;
    using System.Reflection.Emit;


    public sealed class InlineTypeInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        Type _type;

        internal InlineTypeInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public Type Type => _type ?? (_type = _resolver.AsType(Token));

        public int Token { get; }

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineTypeInstruction(this);
    }
}