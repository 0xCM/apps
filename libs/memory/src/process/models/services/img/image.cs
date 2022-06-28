//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using System.Linq;

    partial class ImageMemory
    {
        public static LocatedImageInfo image()
            => image(Process.GetCurrentProcess().MainModule);

        [Op]
        public static Index<LocatedImageInfo> images(Process src)
            => src.Modules.Cast<System.Diagnostics.ProcessModule>().Map(image).OrderBy(x => x.BaseAddress);

        [Op]
        public static LocatedImageInfo image(System.Diagnostics.ProcessModule src)
        {
            var part = ApiParsers.partFromFile(src.FileName);
            var entry = (MemoryAddress)src.EntryPointAddress;
            var @base = src.BaseAddress;
            var size = (uint)src.ModuleMemorySize;
            return new LocatedImageInfo(FS.path(src.FileName), part, entry, @base, size);
        }
    }
}