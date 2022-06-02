//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    partial class Assets
    {
        /// <summary>
        /// Defines a <see cref='Asset'/>
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <param name="address">The memory location at which the resource content begins</param>
        /// <param name="size">The size of the resource, in bytes</param>
        [MethodImpl(Inline), Op]
        public static Asset asset(string name, MemoryAddress address, ByteSize size)
            => new Asset(name, address, size);
    }
}