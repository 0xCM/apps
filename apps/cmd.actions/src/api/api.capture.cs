//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class ApiCmd
    {
        AppSvcOps AppSvc => Wf.AppSvc();

        [CmdOp("api/capture")]
        void Capture(CmdArgs args)
        {
            var capture = Wf.ApiCapture2();
            if(args.Count != 0)
            {
                var spec = text.trim(arg(args,0).Value.Format());
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                {
                    var host = ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i));
                }
                else
                {
                    var part = ApiParsers.part(spec);
                    if(part != 0)
                        capture.Run(part);
                    else
                        Warn($"Specification '{spec}' invalid");
                }

                // spec = text.trim(arg(args,0).Value.Format());
                // using var symbols = Alloc.dispenser(Alloc.symbols);
                // ApiCode.Collect(symbols, spec);
                // EmitAsm(symbols, spec);
            }
            else
            {
                capture.Run();
            }
        }

        Outcome EmitAsm(SymbolDispenser symbols, string spec)
        {
            var result = Outcome.Success;
            var path = ApiCodeFiles.Path(spec, FS.Asm);
            var emitting = EmittingFile(path);
            using var writer = path.Writer();
            var members = ApiCode.Load(symbols, spec);
            var count = members.MemberCount;
            for(var i=0; i<count; i++)
            {
                result = AsmDecoder.DecodeAsm(members.Encoding(i), out var asm);
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
            using var symbols = Alloc.dispenser(Alloc.symbols);
            var result = Outcome.Success;
            var spec = EmptyString;
            if(args.Count != 0)
                spec = text.trim(arg(args,0).Value.Format());
            result = EmitAsm(symbols,spec);
            return result;
        }
    }
}