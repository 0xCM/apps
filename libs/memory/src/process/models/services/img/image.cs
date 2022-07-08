//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ImageMemory
    {
        public static ImageLocation location()
            => location(Process.GetCurrentProcess().MainModule);

        [Op]
        public static ReadOnlySeq<ImageLocation> locations(Process src)
            => src.Modules.ToSeq<ProcessModule>().Map(location).Sort();

        [Op]
        public static ImageLocation location(ProcessModule src)
        {
            return new ImageLocation(src.Path,
                src.Path.FileName.WithoutExtension.Format(),
                (MemoryAddress)src.EntryPointAddress,
                src.BaseAddress,
                (uint)src.ModuleMemorySize
                );
        }
    }
}