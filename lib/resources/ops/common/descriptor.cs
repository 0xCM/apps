//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Resources
    {
        /// <summary>
        /// Defines a <see cref='Asset'/>
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <param name="address">The memory location at which the resource content begins</param>
        /// <param name="size">The size of the resource, in bytes</param>
        [MethodImpl(Inline), Op]
        public static Asset descriptor(Name name, MemoryAddress address, ByteSize size)
            => new Asset(name, address, size);
    }
}