//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct AsmOperands
    {
        /// <summary>
        /// Represents an operand expression of the form BaseReg + IndexReg*Scale + Displacement
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public readonly struct mem<T> : IMemOp<T>
            where T : unmanaged, IMemOp<T>
        {
            public RegOp Base {get;}

            public RegOp Index {get;}

            public MemoryScale Scale {get;}

            public Disp Disp {get;}

            [MethodImpl(Inline)]
            public mem(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            {
                Base = @base;
                Index = index;
                Scale = scale;
                Disp = disp;
            }

            [MethodImpl(Inline)]
            public mem(AsmAddress src)
            {
                Base = src.Base;
                Index = src.Index;
                Scale = src.Scale;
                Disp = src.Disp;
            }
            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => default(T).Size;
            }

            public AsmAddress Address
            {
                [MethodImpl(Inline)]
                get => this;
            }

            public string Format()
                => Address.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator AsmAddress(mem<T> src)
                => new AsmAddress(src.Base, src.Index, src.Scale, src.Disp);
        }
    }
}
