//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Emit;

    using static Root;

    public readonly struct DynamicAction
    {
        /// <summary>
        /// The operation identity
        /// </summary>
        public Name Id {get;}

        public MemoryAddress SourceAddress {get;}

        public DynamicMethod Enclosure {get;}

        public Action Operation {get;}

        [MethodImpl(Inline)]
        public DynamicAction(Name id, MemoryAddress src, DynamicMethod enclosure, Action op)
        {
            Id = id;
            SourceAddress = src;
            Enclosure = enclosure;
            Operation = op;
        }

        [MethodImpl(Inline)]
        public void Invoke()
            => Operation.Invoke();

        [MethodImpl(Inline)]
        public static implicit operator Delegate(DynamicAction src)
            => src.Operation;
    }
}