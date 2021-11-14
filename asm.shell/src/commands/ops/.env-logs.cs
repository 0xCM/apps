//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".env")]
        Outcome ShowEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            var db = Ws.EnvDb();
            var settings = args.Count == 0 ? db.Globals() : db.Settings(arg(args,0));
            iter(settings, s => Write(s.Format()));
            return result;
        }

        [CmdOp(".env-logs")]
        Outcome EnvLogs(CmdArgs args)
        {
            var result = Outcome.Success;
            var ext = FS.ext("env") + FS.Log;
            var paths = Ws.Tools().AdminFiles(ext);
            var formatter = Tables.formatter<EnvVarSet>();
            foreach(var path in paths)
            {
                result = EnvVarSet.parse(path, out var dst);
                if(result.Fail)
                    return result;
                Write(formatter.Format(dst, RecordFormatKind.KeyValuePairs));
            }

            return result;
        }
    }
}