//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".test-settings")]
        Outcome TestSettingParser(CmdArgs args)
        {
            var result = Outcome.Success;
            var a = "A:603";
            DataParser.setting(a, out Setting<ushort> _a);
            Write(_a);


            var b = "B:true";
            DataParser.setting(b, out Setting<bool> _b);

            Write(_b);

            var project = Ws.Project("etl");
            var options = WorkflowOptions.@default();
            var dst = project.Subdir("settings") + FS.file("workflow", FS.Settings);
            var emitting = EmittingFile(dst);
            result = Settings.Store(options, dst);
            if(result.Fail)
                return result;

            EmittedFile(emitting, 1);

            result = Settings.Load(dst, out WorkflowOptions read);
            if(result.Fail)
                return result;

            return result;
        }
    }
}