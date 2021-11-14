//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.InteropServices;

    [Cmd(LlvmNames.Tools.llvm_readobj), StructLayout(LayoutKind.Sequential, Pack =1)]
    public struct ReadObjCmd : IToolCmd<ReadObjCmd>
    {
        [CmdArg(0)]
        public FS.FilePath SrcPath;

        [CmdArg(1)]
        public FS.FilePath DstPath;

        [CmdFlag("--coff-tls-directory")]
        public bit CoffTlsDirectory;

        [CmdFlag("--dynamic-table")]
        public bit DynamicTable;

        [CmdFlag("--file-header")]
        public bit FileHeader;

        [CmdFlag("--histogram")]
        public bit Histogram;

        [CmdFlag("--notes")]
        public bit Notes;

        [CmdFlag("--program-headers")]
        public bit ProgramHeaders;

        [CmdFlag("--relocations")]
        public bit Relocations;

        [CmdFlag("--section-groups")]
        public bit SectionGroups;

        [CmdFlag("--section-details")]
        public bit SectionDetails;

        [CmdFlag("--section-data")]
        public bit SectionData;

        [CmdFlag("--section-headers")]
        public bit SectionHeaders;

        [CmdFlag("--section-mapping")]
        public bit SectionMapping;

        [CmdFlag("--symbols")]
        public bit Symbols;

        [CmdFlag("--unwind")]
        public bit Unwind;

        [CmdFlag("--version-info")]
        public bit VersionInfo;
    }
}