//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ProcessImageMap
    {
        public ProcessMemoryState Process {get;}

        public Index<LocatedImageInfo> Images {get;}

        public Index<MemoryAddress> Locations {get;}

        public Index<ProcessModuleRow> Modules {get;}

        [MethodImpl(Inline)]
        public ProcessImageMap(ProcessMemoryState state, LocatedImageInfo[] images, Index<MemoryAddress> locations, ProcessModuleRow[] modules)
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