//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    public class ApiHostAsmEmitter : AppService<ApiHostAsmEmitter>
    {
        AsmDecoder Decoder;

        public ApiHostAsmEmitter()
        {

        }

        protected override void OnInit()
        {
            Decoder = Wf.AsmDecoder();
        }

        public AsmHostRoutines Emit(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src)
            => Emit(host,src, Db.AsmCapturePath(host));

        public AsmHostRoutines Emit(ApiHostUri host, ReadOnlySpan<ApiMemberCode> src, FS.FilePath dst)
        {
            var flow = Wf.Running(Msg.EmittingHostRoutines.Format(host));
            var decoded = Decoder.Decode(host, src);
            var emitted = Emit(host, decoded.Storage, dst);
            Wf.Ran(flow, Msg.EmittedHostRoutines.Format(emitted, host, dst.ToUri()));
            return decoded;
        }

        Count Emit(ApiHostUri uri, ReadOnlySpan<AsmMemberRoutine> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count != 0)
            {
                using var writer = dst.Writer();
                var buffer = text.buffer();

                for(var i=0; i<count; i++)
                {
                    ref readonly var item = ref skip(src,i);
                    AsmFormatter.render(item.Routine, AsmFormatConfig.DefaultStreamFormat, buffer);
                    writer.Write(buffer.Emit());
                }
            }

            return count;
        }
    }
}