//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class ApiCmdProvider
    {
        [CmdOp("api/capture")]
        Outcome Capture(CmdArgs args)
        {
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());
            var result = CodeCollector.Collect(spec);
            if(result)
                result = EmitAsm(spec);
            return result;
        }

        Outcome EmitAsm(string spec)
        {
            var result = Outcome.Success;
            var path = DataPaths.Path(spec, FS.Asm);
            var emitting = EmittingFile(path);
            using var writer = path.Writer();
            using var bank = CodeCollector.CodeBank(spec);
            var count = bank.MemberCount;
            for(var i=0; i<count; i++)
            {
                result = AsmDecoder.DecodeAsm(bank.Encoding(i), out var asm);
                writer.WriteLine(asm);
                if(result.Fail)
                    break;

                if(i != 0 && i % 1000 == 0)
                    Babble(string.Format("Emitted {0}/{1} routines", i, count));
            }
            EmittedFile(emitting,count);

            return result;
        }

        [CmdOp("api/asm")]
        Outcome EmitAsm(CmdArgs args)
        {
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());
            result = EmitAsm(spec);
            return result;
        }

    }
}