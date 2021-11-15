//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using llvm.records;

    using static core;
    using static LlvmNames.Tools;

    partial class LlvmCmd
    {
        [CmdOp(".syms")]
        Outcome Syms(CmdArgs args)
        {
            var result = Outcome.Success;
            var match = arg(args,0).Value;
            var files = State.Project().OutFiles(FS.Sym).View;
            var formatter = Tables.formatter<ObjSymRow>(ObjSymRow.RenderWidths);
            var counter = 0u;
            var tool = Wf.LlvmNm();
            foreach(var f in files)
            {
                if(f.Format().Contains(match))
                {
                    var records = tool.Read(f);
                    var count= records.Length;
                    for(var i=0; i<count; i++)
                    {
                        Write(formatter.Format(skip(records,i)));
                        counter++;
                    }
                }
            }
            Write(string.Format("Found {0} symbols", counter));
            return result;
        }
    }
}