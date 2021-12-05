//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using System.Linq;

    using static Root;

    partial struct Resources
    {
        [MethodImpl(Inline), Op]
        public static BinaryRes binary(PartId owner, string id, ReadOnlySpan<byte> src)
            => new BinaryRes(owner, id, src.Length, core.address(src));

        [MethodImpl(Inline), Op]
        public static BinaryRes binary(PartId owner, string id, ByteSize size, MemoryAddress address)
            => new BinaryRes(owner, id, size, address);

        /// <summary>
        /// Returns the properties declared by a type that define binary resource content
        /// </summary>
        /// <typeparam name="T">The defining type</typeparam>
        public static PropertyInfo[] BinaryProviders<T>()
            => typeof(T)
                .StaticProperties()
                .Where(p => p.PropertyType == typeof(ReadOnlySpan<byte>))
                .ToArray();
    }
}