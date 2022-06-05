//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class ApiActionCmd : AppCmdProvider<ApiActionCmd>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        AsmTables AsmTables => Wf.AsmTables();

        ApiPacks ApiPacks => Wf.ApiPacks();

        AsmCallPipe AsmCalls => Wf.AsmCallPipe();

        AsmDecoder AsmDecoder => Wf.AsmDecoder();

        ApiCatalogs ApiCatalogs => Wf.ApiCatalogs();

        CliEmitter CliEmitter => Wf.CliEmitter();

        ApiCode ApiCode => Wf.ApiCode();

        Index<ProcessAsmRecord> ProcessAsm()
            => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer()
            => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        Index<ProcessAsmRecord> _LoadProcessAsm()
        {
            var archive = ApiPacks.Current().Archive();
            var path = archive.ProcessAsmPath();
            var count = FS.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var flow = Running(string.Format("Loading process asm from {0}", path.ToUri()));
            var result = AsmTables.load(path, buffer);
            if(result.Fail)
            {
                Error(result.Message);
                return Index<ProcessAsmRecord>.Empty;
            }
            Ran(flow);

            return buffer;
        }
    }
}