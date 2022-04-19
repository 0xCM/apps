//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ResolvedPart
    {
        public PartId Part {get;}

        public FS.FilePath Location {get;}

        public Index<ResolvedHost> Hosts {get;}

        [MethodImpl(Inline)]
        public ResolvedPart(PartId part, FS.FilePath location, Index<ResolvedHost> hosts)
        {
            Part = part;
            Location = location;
            Hosts = hosts;
        }

        public uint MethodCount
            => (uint)Hosts.Select(x => (int)x.MethodCount).Storage.Sum();

        public static ResolvedPart Empty
        {
            [MethodImpl(Inline)]
            get => new ResolvedPart(0, FS.FilePath.Empty, core.array<ResolvedHost>());
        }
    }
}