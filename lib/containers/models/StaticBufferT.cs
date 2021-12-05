//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = StaticBuffers;

    /// <summary>
    /// Supertype for covers with locations that will be pinned for the domain lifetime
    /// </summary>
    /// <typeparam name="T">The covered content type</typeparam>
    public abstract class StaticBuffer<T> : IStaticBuffer<T>
    {
        /// <summary>
        /// The number of covered cells
        /// </summary>
        public abstract uint CellCount {get;}

        /// <summary>
        /// Specifies the address of the buffer, not its content
        /// </summary>
        public MemoryAddress Address {get; protected set;}

        public Span<T> Content
        {
            [MethodImpl(Inline)]
            get => api.covered(this);
        }

        [MethodImpl(Inline)]
        public ref T Cell(uint index, out T value)
        {
            api.cell(this, index, out value);
            return ref value;
        }

        [MethodImpl(Inline)]
        public void Enumerate(uint i0, uint i1, Action<T> receiver)
            => api.enumerate(this, i0, i1, receiver);

        [MethodImpl(Inline)]
        public void Enumerate(Action<T> receiver)
            => api.enumerate(this, receiver);

        protected abstract void Fill(Span<T> dst);

        /// <summary>
        /// Supplies content for the buffer to cover
        /// </summary>
        /// <param name="src"></param>
        public abstract void Deposit(T[] src);
    }
}