//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using static core;

    partial class AsmCmdService
    {
        Outcome EmitMsil(ReadOnlySpan<IApiHost> hosts)
        {
            var result = Outcome.Success;
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


        FS.FilePath MsilOutPath(ApiHostUri uri)
            => Ws.Project("db").Subdir("api/msil") + FS.hostfile(uri, FS.Il);
    }
}