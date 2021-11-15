//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct WorkflowOptions : ISettings<WorkflowOptions>
    {
        public bool EmitAssetIndex;

        public bool CollectApiDocs;

        public bool EmitImageContent;

        public bool EmitSectionHeaders;

        public bool EmitMsilMetadata;

        public bool EmitCliStrings;

        public bool EmitCliBlobs;

        public bool EmitAssemblyRefs;

        public bool EmitCliConstants;

        public bool EmitApiMetadump;

        public bool EmitApiClasses;

        public bool EmitFieldMetadata;

        public bool EmitSymbolicLiterals;

        public bool EmitXedCatalogs;

        public bool EmitAsmRows;

        public bool EmitResBytes;

        public bool EmitAsmAnalysis;

        public bool EmitIntrinsicsInfo;

        public bool EmitAsmStatements;

        public bool CorrelateMembers;

        public bool EmitAssetContent;

        public bool EmitApiBitMasks;

        public bool EmitHexIndex;

        public bool EmitCallData;

        public bool EmitJmpData;

        public bool EmitHexPack;

        public bool ProcessCultFiles;

        public bool EmitMethodDefs;

        public bool EmitCliRowStats;

        public static WorkflowOptions @default()
        {
            var dst = new WorkflowOptions();
            dst.CollectApiDocs = true;
            dst.EmitImageContent = true;
            dst.EmitSectionHeaders = true;
            dst.EmitMsilMetadata = true;
            dst.EmitCliStrings = true;
            dst.EmitCliBlobs = true;
            dst.EmitCliConstants = true;
            dst.EmitFieldMetadata = true;
            dst.EmitXedCatalogs = true;
            dst.EmitAsmRows = true;
            dst.EmitResBytes = true;
            dst.EmitAsmAnalysis = true;
            dst.EmitIntrinsicsInfo = true;
            dst.EmitAsmStatements = true;
            dst.EmitApiMetadump = true;
            dst.CorrelateMembers = true;
            dst.EmitAssetIndex = true;
            dst.EmitAssetContent = false;
            dst.EmitSymbolicLiterals = true;
            dst.EmitApiBitMasks = true;
            dst.EmitHexIndex = true;
            dst.EmitCallData = false;
            dst.EmitJmpData = false;
            dst.EmitHexPack = true;
            dst.ProcessCultFiles = false;
            dst.EmitAssemblyRefs = true;
            dst.EmitApiClasses = true;
            dst.EmitMethodDefs = true;
            dst.EmitCliRowStats = true;
            return dst;
        }

        public override string ToString()
            => (this as ISettings).Format();
    }
}