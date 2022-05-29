//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures <see cref='ManifestResource'/> data in usable form
    /// </summary>
    [Record(TableId)]
    public struct ManifestResourceInfo : IRecord<ManifestResourceInfo>
    {
        public const string TableId = "cli.metadata.manifestresource";

        public string Name;

        public MemoryAddress Offset;

        public ManifestResourceAttributes Attributes;
    }
}