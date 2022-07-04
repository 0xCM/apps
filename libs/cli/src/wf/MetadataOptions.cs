//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct MetadataOptions : ISettings<MetadataOptions>
    {
        public bool EmitImageContent;

        public bool EmitSectionHeaders;

        public bool EmitMsilMetadata;

        public bool EmitCliStrings;

        public bool EmitCliBlobs;

        public bool EmitAssemblyRefs;

        public bool EmitCliConstants;

        public bool EmitApiMetadump;

        public bool EmitFieldMetadata;
    }
}