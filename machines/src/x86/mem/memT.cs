//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;

    /// <summary>
    /// Defines a <typeparamref name='T'/> parametric memory cell
    /// </summary>
    public readonly struct mem<T> : IMem<T>
        where T : unmanaged
    {
        public T Content {get;}

        public AsmOpClass OpClass
            => AsmOpClass.M;

        [MethodImpl(Inline)]
        public mem(T src)
        {
            Content = src;
        }

        [MethodImpl(Inline)]
        public static implicit operator mem<T>(T src)
            => new mem<T>(src);
    }
}