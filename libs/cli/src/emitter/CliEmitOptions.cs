//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CliEmitOptions
    {
        public bool EmitImageContent;

        public bool EmitSectionHeaders;

        public bool EmitMsilMetadata;

        public bool EmitMsilCode;

        public bool EmitCliStrings;

        public bool EmitCliBlobs;

        public bool EmitAssemblyRefs;

        public bool EmitCliConstants;

        public bool EmitApiMetadump;

        public bool EmitFieldMetadata;

        public bool EmitMethodDefs;

        public bool EmitCliRowStats;

        public bool EmitMetadataHex;

        public static CliEmitOptions @default()
        {
            var dst = new CliEmitOptions();
            dst.EmitImageContent = true;
            dst.EmitSectionHeaders = true;
            dst.EmitMsilMetadata = true;
            dst.EmitCliStrings = true;
            dst.EmitCliBlobs = true;
            dst.EmitCliConstants = true;
            dst.EmitFieldMetadata = true;
            dst.EmitApiMetadump = true;
            dst.EmitAssemblyRefs = true;
            dst.EmitMethodDefs = true;
            dst.EmitCliRowStats = true;
            dst.EmitMetadataHex = true;
            dst.EmitMsilCode = true;
            return dst;
        }
    }
}