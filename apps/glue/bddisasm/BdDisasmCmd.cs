//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    public struct BdDisasmCmd : IToolCmd<BdDisasmCmd>
    {
        public FS.FilePath ToolPath;

        public FS.FilePath BinPath;

        public Bitness AsmBitMode;

        public bool EmitBitfields;

        public bool EmitDetails;

        public FS.FilePath OutputPath;
    }
}