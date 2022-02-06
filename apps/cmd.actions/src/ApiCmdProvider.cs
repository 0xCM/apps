//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class ApiCmdProvider : AppCmdProvider<ApiCmdProvider>
    {
        ApiHex ApiHex => Service(Wf.ApiHex);

        ApiMetadataService ApiMetadata => Service(Wf.ApiMetadata);

        AsmTables AsmTables => Service(Wf.AsmTables);

        ApiPacks ApiPacks => Service(Wf.ApiPacks);

        Parsers Parsers => Z0.Parsers.Service;

        ApiHexPacks ApiHexPacks => Service(Wf.ApiHexPacks);

        ApiPackArchive ApiPackArchive => Service(ApiPacks.Archive);

        AsmCallPipe AsmCalls => Service(Wf.AsmCallPipe);

        AsmDecoder AsmDecoder => Service(Wf.AsmDecoder);

        ApiCatalogs ApiCatalogs => Service(Wf.ApiCatalogs);

        CliEmitter CliEmitter => Service(Wf.CliEmitter);

        ApiComments ApiComments => Service(Wf.ApiComments);

        Symbolism Symbolism => Service(Wf.Symbolism);

        EncodingCollector CodeCollector => Service(Wf.EncodingCollector);

        Index<ProcessAsmRecord> ProcessAsm() => Data(nameof(ProcessAsm), _LoadProcessAsm);

        Index<ProcessAsmRecord> ProcessAsmBuffer() => Data(nameof(ProcessAsmBuffer), () => alloc<ProcessAsmRecord>(ProcessAsm().Count));

        ApiResPackEmitter ResPackEmitter => Service(Wf.ResPackEmitter);

        ApiDataPaths DataPaths => Service(Wf.ApiDataPaths);

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