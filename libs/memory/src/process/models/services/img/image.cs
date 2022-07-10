//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ImageMemory
    {
        public static ImageLocation location()
            => location(Process.GetCurrentProcess().MainModule);

        [Op]
        public static ReadOnlySeq<ImageLocation> locations(ProcessAdapter src)
        {
            var dst = core.list<ImageLocation>();
            iter(src.Modules, m => dst.Add(location(m)));
            return dst.ToArray();
        }

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