//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct AsmRegValue<T>
        where T : unmanaged
    {
        public AsmRegName Name {get;}

        public T Value {get;}

        [MethodImpl(Inline)]
        public AsmRegValue(AsmRegName name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Format()
            => AsmRegs.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmRegValue<T>(Paired<AsmRegName,T> src)
            => @as<Paired<AsmRegName,T>,AsmRegValue<T>>(src);
    }
}