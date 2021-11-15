//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata;
    using System.Reflection;

    /// <summary>
    /// Captures <see cref='ManifestResource'/> data in usable form
    /// </summary>
    [Record(TableId)]
    public struct ManifestResourceInfo : IRecord<ManifestResourceInfo>
    {
        public const string TableId = "image.manifest.resource";

        public string Name;

        public MemoryAddress Offset;

        public ManifestResourceAttributes Attributes;
    }
}