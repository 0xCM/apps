//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ProcessImageMap
    {
        public readonly ProcessMemoryState Process;

        public readonly ReadOnlySeq<ImageLocation> Locations;

        public readonly ReadOnlySeq<MemoryAddress> Addresses;

        public readonly ReadOnlySeq<ProcessModuleRow> Modules;

        [MethodImpl(Inline)]
        public ProcessImageMap(ProcessMemoryState state, ReadOnlySeq<ImageLocation> locations, ReadOnlySeq<MemoryAddress> addresses, ReadOnlySeq<ProcessModuleRow> modules)
        {
            Process = state;
            Locations = locations;
            Addresses = addresses;
            Modules = modules;
        }

        public string Format()
            => Process.ImageName;

        public override string ToString()
            => Format();
    }
}