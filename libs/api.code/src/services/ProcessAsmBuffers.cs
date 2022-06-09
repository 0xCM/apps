//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public class ProcessAsmBuffers
    {
        Index<ProcessAsmRecord> _ProcessAsm;

        Index<ProcessAsmRecord> _ProcessAsmSelection;

        public ProcessAsmBuffers()
        {
            _ProcessAsm = sys.empty<ProcessAsmRecord>();
            _ProcessAsmSelection = sys.empty<ProcessAsmRecord>();
        }

        [MethodImpl(Inline)]
        public Span<ProcessAsmRecord> Selected()
            => _ProcessAsmSelection.Edit;

        [MethodImpl(Inline)]
        public ReadOnlySpan<ProcessAsmRecord> Records()
            => _ProcessAsm;

        static Outcome row(uint line, string src, out ProcessAsmRecord dst)
            => ProcessAsmRecord.parse(new TextLine(line, src), out dst);

        public static Outcome<uint> load(FS.FilePath src, Span<ProcessAsmRecord> dst)
        {
            var counter = 1u;
            var i = 0u;
            var max = dst.Length;
            using var reader = src.AsciReader();
            var header = reader.ReadLine();
            var line = reader.ReadLine();
            var result = Outcome.Success;
            while(line != null && result.Ok)
            {
                result = row(counter++, line, out seek(dst,i));
                if(result.Fail)
                    return result;
                else
                    i++;

                line = reader.ReadLine();
            }
            return i;
        }

        public static Index<ProcessAsmRecord> records(FS.FilePath src)
        {
            var count = Lines.linecount(src,TextEncodingKind.Asci) - 1;
            var dst = alloc<ProcessAsmRecord>(count);
            load(src,dst).Require();
            return dst;
        }

        public static Index<ProcessAsmRecord> records(IApiPack src)
            => records(src.Archive().ProcessAsmPath());

        public static ProcessAsmBuffers load(FS.FilePath path)
        {
            var count = Lines.linecount(path,TextEncodingKind.Asci) - 1;
            var buffer = alloc<ProcessAsmRecord>(count);
            var result = load(path, buffer);
            var dst = new ProcessAsmBuffers();
            dst._ProcessAsm = buffer;
            dst._ProcessAsmSelection = alloc<ProcessAsmRecord>(dst._ProcessAsm.Count);
            return dst;
        }

        public static ProcessAsmBuffers load(IApiPack src)
            => load(src.Archive().ProcessAsmPath());
    }
}