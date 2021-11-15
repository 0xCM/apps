//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents an identified string resource
    /// </summary>
    public readonly struct StringRes<E> : ITextual
        where E : unmanaged
    {
        /// <summary>
        /// The resource identifier
        /// </summary>
        public E Identifier {get;}

        /// <summary>
        /// The resource address
        /// </summary>
        public StringAddress Address {get;}

        /// <summary>
        /// The Size of the resource, in bytes
        /// </summary>
        public ByteSize Size {get;}

        [MethodImpl(Inline)]
        public StringRes(E id, StringAddress address, ByteSize size)
        {
            Identifier = id;
            Address = address;
            Size = size;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();
    }
}