//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=1), Config(ConfigId)]
    public struct CliEmitOptions : ISettings<CliEmitOptions>
    {
        const string ConfigId = "cli.options";

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
            dst.EmitImageContent = false;
            dst.EmitSectionHeaders = true;
            dst.EmitMsilMetadata = false;
            dst.EmitCliStrings = true;
            dst.EmitCliBlobs = false;
            dst.EmitCliConstants = false;
            dst.EmitFieldMetadata = false;
            dst.EmitApiMetadump = false;
            dst.EmitAssemblyRefs = false;
            dst.EmitMethodDefs = false;
            dst.EmitCliRowStats = false;
            dst.EmitMetadataHex = false;
            dst.EmitMsilCode = false;
            return dst;
        }
    }
}