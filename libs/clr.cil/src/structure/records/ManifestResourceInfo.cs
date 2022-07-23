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
    public struct ManifestResourceInfo
    {
        const string TableId = "resources";

        [Render(32)]
        public string Name;

        [Render(12)]
        public MemoryAddress Offset;

        [Render(1)]
        public ManifestResourceAttributes Attributes;
    }
}