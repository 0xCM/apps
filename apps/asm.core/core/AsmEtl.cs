//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    [ApiHost]
    public class AsmEtl : AppService<AsmEtl>
    {
        [Op]
        public static AsmEncodingInfo encoding(in ProcessAsmRecord src)
            => new AsmEncodingInfo((src.OpCode, src.Sig), src.Statement, src.Encoded, AsmBits.bitstring(src.Encoded));

        /// <summary>
        /// Computes the distinct encodings from the source
        /// </summary>
        /// <param name="src"></param>
        [Op]
        public static SortedSpan<AsmEncodingInfo> encodings(ReadOnlySpan<ProcessAsmRecord> src)
        {
            var collected = hashset<AsmEncodingInfo>();
            var count = src.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                if(collected.Add(encoding(skip(src,i))))
                    counter++;
            }
            return collected.Array().ToSortedSpan();
        }


        public static ReadOnlySpan<TextLine> emit(SortedSpan<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            var lines = span<TextLine>(count);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                var content = AsmThumbprint.bitstring(src[i]);
                writer.WriteLine(content);
                seek(lines,i) = (i,content);
            }
            return lines;
        }

        [Op]
        static string thumbprint(in AsmEncodingInfo src)
        {
            var statement = string.Format("{0} # ({1})<{2}>[{3}] => {4}", src.Statement.FormatPadded(), src.Sig, src.OpCode, src.Encoded.Size, src.Encoded.Format());
            return string.Format("{0} => {1}", statement, src.Encoded.BitString);
        }

        public ReadOnlySpan<TextLine> EmitThumbprints(SortedSpan<AsmEncodingInfo> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            var lines = span<TextLine>(count);
            using var writer = dst.Writer();
            for(var i=0u; i<count; i++)
            {
                var content = thumbprint(src[i]);
                writer.WriteLine(content);
                seek(lines,i) = (i,content);
            }
            EmittedFile(emitting, count);
            return lines;
        }

        public void EmitThumbprints(SortedSpan<ProcessAsmRecord> src, FS.FilePath dst)
            => EmitThumbprints(encodings(src), dst);

        public SortedSpan<AsmThumbprint> EmitThumbprints(ReadOnlySpan<HostAsmRecord> src, FS.FilePath dst)
        {
            var distinct = AsmThumbprint.distinct(src);
            emit(distinct, dst);
            return distinct;
        }

        [Op]
        public Outcome EmitThumbprints(Index<AsmThumbprint> src, FS.FilePath dst)
        {
            var count = src.Length;
            src.Sort();
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(src[i].Format());
            return true;
        }
    }
}