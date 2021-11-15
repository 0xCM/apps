//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using static core;

    using static WsAtoms;

    partial class AsmCmdService
    {
        [CmdOp(".api-msil-emit")]
        Outcome EmitMsil(CmdArgs args)
        {
            var result = Outcome.Success;
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            var hosts = default(ReadOnlySpan<IApiHost>);
            if(args.Length != 0)
            {
                result = ApiParsers.host(arg(args,0), out var uri);
                if(result.Ok)
                {
                    result = catalog.FindHost(uri, out var host);
                    if(result.Ok)
                        hosts = array(host);
                }
            }
            else
            {
                hosts = catalog.ApiHosts;
            }
            Write(string.Format("Emitting msil for {0} hosts", hosts.Length));

            result = EmitMsil(hosts);
            return result;
        }

        Outcome EmitMsil(ReadOnlySpan<IApiHost> hosts)
        {
            var result = Outcome.Success;
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            var buffer = text.buffer();
            var jit = Wf.ApiJit();
            var pipe = Wf.MsilPipe();
            var counter = 0u;
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var members = jit.JitHost(host).View;
                var count = members.Length;
                if(count == 0)
                    continue;

                var dst = MsilOutPath(host.HostUri);
                var flow = EmittingFile(dst);

                for(var j=0; j<count; j++)
                {
                    ref readonly var member = ref members[j];
                    ref readonly var msil = ref member.Msil;
                    pipe.RenderCode(msil, buffer);
                    counter++;
                }

                using var writer = dst.UnicodeWriter();
                writer.Write(buffer.Emit());
                EmittedFile(flow, count);
            }

            return result;
        }

        Outcome EmitMsil(ReadOnlySpan<ApiHostUri> hosts)
        {
            var result = Outcome.Success;
            var catalog = State.ApiCatalog(ApiRuntimeLoader.catalog);
            var buffer = text.buffer();
            var pipe = Wf.MsilPipe();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var uri = ref skip(hosts,i);
                result = catalog.FindHost(uri, out var host);
                if(result.Fail)
                {
                    result = (false, AppMsg.HostNotFound.Format(uri));
                    break;
                }

                var members = Wf.ApiJit().JitHost(host);
                var count = members.Count;
                for(var j=0; j<count; j++)
                    pipe.RenderCode(members[j].Msil, buffer);

                var dst = MsilOutPath(uri);
                var flow = EmittingFile(dst);
                using var writer = dst.UnicodeWriter();
                writer.Write(buffer.Emit());
                EmittedFile(flow, count);
            }

            return result;
        }

        FS.FilePath MsilOutPath(ApiHostUri uri)
            => Ws.Gen().Subdir(msil) + FS.hostfile(uri, FS.Il);
    }
}