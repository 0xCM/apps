//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".objinfo")]
        Outcome ObjInfo(CmdArgs args)
        {
            var result = Outcome.Success;
            var files = ReadObj.ObjInfoFiles(State.Project().OutDir());
            var parser = ReadObj.ObiParser();
            foreach(var file in files)
            {
                result = parser.Parse(file, out var obi);
                Write(string.Format("{0} Lines", obi.DataLines.Length));
            }

            return result;
        }
    }
}