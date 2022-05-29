//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmd
    {
        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
            => Wf.ApiCapture2().Run(args);

        // Outcome EmitAsm(SymbolDispenser symbols, string spec)
        // {
        //     var result = Outcome.Success;
        //     var path = ApiCodeFiles.Path(spec, FS.Asm);
        //     var emitting = EmittingFile(path);
        //     using var writer = path.Writer();
        //     var members = ApiCode.Load(symbols, spec);
        //     var count = members.MemberCount;
        //     for(var i=0; i<count; i++)
        //     {
        //         result = AsmDecoder.DecodeAsm(members.Encoding(i), out var asm);
        //         writer.WriteLine(asm);
        //         if(result.Fail)
        //             break;

        //         if(i != 0 && i % 1000 == 0)
        //             Babble(string.Format("Emitted {0}/{1} routines", i, count));
        //     }
        //     EmittedFile(emitting,count);

        //     return result;
        // }

        // [CmdOp("api/asm")]
        // Outcome EmitAsm(CmdArgs args)
        // {
        //     using var symbols = Alloc.dispenser(Alloc.symbols);
        //     var result = Outcome.Success;
        //     var spec = EmptyString;
        //     if(args.Count != 0)
        //         spec = text.trim(arg(args,0).Value.Format());
        //     result = EmitAsm(symbols,spec);
        //     return result;
        // }
    }
}