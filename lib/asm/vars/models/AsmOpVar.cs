//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class AsmOpVar<T> : IAsmOpVar<T>
        where T : IAsmOp
    {
        readonly Func<byte,T> Resolver;

        /// <summary>
        /// The statement-relative operand index
        /// </summary>
        public byte Index {get;}

        public AsmOpVar(byte index, Func<byte,T> resolver)
        {
            Resolver = resolver;
            Index = index;

        }

        public T Resolve(uint seq)
            => Resolver(Index);

        AsmOperand IAsmOpVar.Resolve(uint seq)
            => Resolve(seq, out _);

        protected abstract ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst);
    }

    public class AsmOpVar : AsmOpVar<AsmOperand>
    {
        public AsmOpVar(byte index,Func<byte,AsmOperand> resolver)
            : base(index,resolver)
        {

        }

        protected override ref readonly AsmOperand Resolve(uint seq, out AsmOperand dst)
        {
            dst = Resolve(seq);
            return ref dst;
        }
    }
}