//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProcessImageMap
    {
        public readonly ProcessMemoryState Process;

        public readonly Index<LocatedImageInfo> Images;

        public readonly Index<MemoryAddress> Locations;

        public readonly ReadOnlySeq<ProcessModuleRow> Modules;

        [MethodImpl(Inline)]
        public ProcessImageMap(ProcessMemoryState state, LocatedImageInfo[] images, Index<MemoryAddress> locations, ReadOnlySeq<ProcessModuleRow> modules)
        {
            Process = state;
            Images = images;
            Locations = locations;
            Modules = modules;
        }

        public string Format()
            => Process.ImageName;

        public override string ToString()
            => Format();
    }
}