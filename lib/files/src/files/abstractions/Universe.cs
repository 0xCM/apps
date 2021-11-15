//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class Universe<U> : IUniversal<U>
        where U : Universe<U>, new()
    {
        public static U create(IUniversal context = null)
        {
            var u  = new U();
            u.Context = context ?? new Universal();
            u.Init();
            return u;
        }

        protected IUniversal Context {get; private set;}

        protected virtual void Init() { }
    }

    public abstract class Universe<U,S> : IUniversal<U,S>
        where U : Universe<U,S>, new()
        where S : struct
    {
        [FixedAddressValueType]
        protected static S Storage = new S();

        protected Universe()
        {
            StoreLocation = LocateStore();
        }

        public MemoryAddress StoreLocation {get;}

        public unsafe ref S Buffer
        {
            [MethodImpl(Inline)]
            get => ref LocateStore().Ref<S>();
        }

        protected IUniversal Context {get; private set;}

        protected virtual void Init() { }

        static unsafe MemoryAddress LocateStore()
            => new MemoryAddress(Unsafe.AsPointer(ref Storage));
    }
}