//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    partial struct Resources
    {
        [Op]
        public static unsafe Index<Asset> collect(Assembly src, string match = null)
        {
            require(src != null, () => "Argument NULL");
            var resnames = @readonly(names(src, match));
            var count = resnames.Length;
            if(count == 0)
                return sys.empty<Asset>();

            var buffer = alloc<Asset>(count);
            var target = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref skip(resnames, i);
                var stream = (UnmanagedMemoryStream)src.GetManifestResourceStream(name);
                seek(target,i) = descriptor(name, stream.PositionPointer, (uint)stream.Length);
            }
            return buffer;
        }
    }
}