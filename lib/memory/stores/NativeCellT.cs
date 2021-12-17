
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public struct NativeCell<T>
    {
        public T Content;

        [MethodImpl(Inline)]
        public NativeCell(T src)
        {
            Content = src;
        }

        public MemoryAddress Location
        {
            [MethodImpl(Inline)]
            get => address(this);
        }
    }
}