// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Msil
{
    using System.Reflection.Emit;
    using System.Reflection;

    public sealed class InlineTokInstruction : ILInlineInstruction
    {
        readonly ICilTokenResolver _resolver;

        MemberInfo _member;

        internal InlineTokInstruction(int offset, OpCode opCode, int token, ICilTokenResolver resolver)
            : base(offset, opCode)
        {
            _resolver = resolver;
            Token = token;
        }

        public MemberInfo Member => _member ?? (_member = _resolver.AsMember(Token));

        public int Token { get; }

        public override void Accept(ILInstructionVisitor visitor)
            => visitor.VisitInlineTokInstruction(this);
    }
}