//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a record backed byte a <typeparamref name='T'/> storage cell
    /// </summary>
    public struct BitRecord<T>
        where T : unmanaged
    {
        T Data;

        [MethodImpl(Inline)]
        public BitRecord(T data)
        {
            Data = data;
        }

        public Span<byte> Storage
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }
    }
}