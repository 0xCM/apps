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
    /// Supertype for <see cref='StaticBuffer{T}'/> reifications
    /// </summary>
    /// <typeparam name="H">The reifying type</typeparam>
    /// <typeparam name="T">The buffer cell type</typeparam>
    public abstract class StaticBuffer<H,T> : StaticBuffer<T>
        where H : StaticBuffer<H,T>, new()
    {
        static H Instance;

        [FixedAddressValueType]
        static MutableSeq<T> Buffer;

        static object locker = new object();

        [MethodImpl(Inline)]
        public static H fetch()
        {
            lock(locker)
            {
                if(Instance == null)
                {
                    Instance = new H();
                    var count = Instance.CellCount;
                    Buffer = alloc<T>(Instance.CellCount);
                    Instance.Fill(Buffer.Storage);
                    Instance.Address = address(Buffer);
                }
                return Instance;
            }
        }

        public override void Deposit(T[] src)
            => Buffer.Storage = src;

        public override uint CellCount
            => Buffer.Count;
    }
}