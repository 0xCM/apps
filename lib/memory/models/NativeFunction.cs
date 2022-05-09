//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    public readonly struct NativeFunction : INativeFunction
    {
        public MemoryAddress Address {get;}

        public NativeModule Source {get;}

        public string Name {get;}

        [MethodImpl(Inline)]
        public NativeFunction(NativeModule src, MemoryAddress @base, string name)
        {
            Source = src;
            Address = @base;
            Name = name;
        }

        public string Format()
            => Address.Format();
    }
}