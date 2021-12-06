// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;
    using System.Reflection;

    public sealed class InlineFieldInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        FieldInfo _field;

        internal InlineFieldInstruction(ICilTokenResolver resolver, int offset, OpCode opCode, int token)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public FieldInfo Field
            => _field ?? (_field = _resolver.AsField(Token));

        public int Token {get;}

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineFieldInstruction(this);
    }
}