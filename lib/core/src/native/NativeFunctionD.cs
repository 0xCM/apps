//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NativeFunction<D> : INativeFunction
        where D : Delegate
    {
        public MemoryAddress Address {get;}

        public NativeModule Source {get;}

        public string Name {get;}

        public readonly D Invoke {get;}

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name, D f)
        {
            Source = src;
            Address = @base;
            Name = name;
            Invoke = f;
        }

        public string Format()
            => string.Format(RP.PSx3, Address, Source, Name);
    }
}