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
        {
            var dst = core.list<ImageLocation>();
            foreach(var module in src.Modules)
                if(module is ProcessModule pm)
                    dst.Add(location(pm));
            return dst.ToArray();
        }
            //=> src.Modules.Cast<.Map(location).Sort();

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