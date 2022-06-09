//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public sealed class CharMapper : Service<CharMapper>
    {
        public SortedReadOnlySpan<Paired<Hex16,char>> Unmapped(FS.FilePath src, in CharMap<char> map)
            => Unmapped(src, TextEncodings.Asci);

        public SortedReadOnlySpan<Paired<Hex16,char>> Unmapped(FS.FilePath src, AsciPoints target)
        {
            var map = CharMaps.create(TextEncodings.Unicode, target);
            var flow = Running(string.Format("Searching {0} for unmapped characters", src.ToUri()));
            var unmapped = hashset<char>();
            using var reader = src.LineReader(TextEncodingKind.Utf8);
            while(reader.Next(out var line))
                CharMaps.unmapped(map, line.Data, unmapped);
            var pairs = unmapped.Map(x => paired((Hex16)x,x)).OrderBy(x => x.Left).ToReadOnlySpan();
            var data = Spans.sorted(pairs);
            Ran(flow, string.Format("Found {0} unmapped characters", data.Length));
            return data;
        }

        public SortedReadOnlySpan<Paired<Hex16,char>> LogUnmapped(in CharMap<char> map, FS.FilePath src, FS.FilePath dst)
        {
            var unmapped = Unmapped(src, map);
            var pairs = unmapped.View.Map(CharMaps.format);
            var count = pairs.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(pairs,i));
            return unmapped;
        }

        public void Emit(in CharMap<char> src, FS.FilePath dst)
        {
            var emitting = Emitting(dst);
            using var writer = dst.Writer();
            var mapcount = CharMaps.emit(src, writer);
            Emitted(emitting, mapcount);
        }
    }
}