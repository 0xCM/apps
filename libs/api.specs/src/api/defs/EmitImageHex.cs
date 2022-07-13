//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdDefs
    {
        [Cmd(CmdId,"Accepts a binary image and produces FileKind.Hex file")]
        public struct EmitImageHex : IFlowCmd<EmitImageHex>
        {
            const string CmdId = "image/emit/hex";

            public FS.FilePath Source;

            public FS.FilePath Target;
        }
    }
}