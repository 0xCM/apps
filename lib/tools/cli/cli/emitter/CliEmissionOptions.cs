//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct CliEmissionOptions
    {
        public bool EmitAssemblyRefs;

        public bool EmitSectionHeaders;

        public bool EmitMsilMetadata;

        public bool EmitCliConstants;

        public bool EmitCliStrings;

        public bool EmitCliBlobs;

        public bool EmitApiMetadump;

        public bool EmitImageContent;

        public bool EmitFieldMetadata;

        public bool EmitCliRowStats;

        public bool EmitMethodDefs;

        public static CliEmissionOptions @default()
        {
            var dst = new CliEmissionOptions();
            dst.EmitImageContent = true;
            dst.EmitSectionHeaders = true;
            dst.EmitMsilMetadata = true;
            dst.EmitCliStrings = true;
            dst.EmitCliBlobs = true;
            dst.EmitCliConstants = true;
            dst.EmitFieldMetadata = true;
            dst.EmitApiMetadump = true;
            dst.EmitAssemblyRefs = true;
            dst.EmitCliRowStats = true;
            dst.EmitMethodDefs = true;
            return dst;
        }
    }
}