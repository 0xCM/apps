//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Collections.Generic;

    using static core;
    using static SdmModels;

    partial class IntelSdm
    {
        public Outcome EmitTocRecords()
        {
            var result = Outcome.Success;
            var flow = Wf.Running();
            var vols = VolumeMarkers(1,4);
            var src = SdmPaths.TocImportPath();
            if(!src.Exists)
            {
                result = (false,FS.missing(src));
                Wf.Error(result.Message);
                return result;
            }

            var encoding = TextEncodingKind.Unicode;
            using var reader = src.LineReader(encoding);
            var buffer = text.buffer();
            var dst = SdmPaths.ProcessLog("toc.combined");
            using var writer = dst.Writer(encoding);
            var cn = ChapterNumber.Empty;
            var tn = TableNumber.Empty;
            var title = TocTitle.Empty;
            var entry = TocEntry.Empty;
            var entries = list<TocEntry>();
            var _snbuffer = span<SectionNumber>(1);
            ref var _sn = ref first(_snbuffer);
            _sn = SectionNumber.Empty;
            while(reader.Next(out var line))
            {
                var content = line.Content;
                var number = line.LineNumber;
                if(vols.Contains(content))
                {
                    writer.WriteLine(string.Format("{0}:{1}", number, content));
                    continue;
                }

                if(parse(content, out cn))
                {
                    render(number, cn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(parse(content, out SectionNumber sn))
                {
                    _sn = sn;
                    render(number, _sn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(parse(content, out title))
                {
                    entry = toc(_sn, title);
                    entries.Add(entry);
                    render(number, entry, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }

                if(parse(content, out tn))
                {
                    render(number, tn, buffer);
                    writer.WriteLine(buffer.Emit());
                    continue;
                }
            }

            var rowcount = TableEmit(entries.ViewDeposited(), SdmPaths.TocEntryTable());
            Wf.Ran(flow, string.Format("Collected {0} toc entries", rowcount));
            return result;
        }


        string VolumeMarker(byte vol)
            => string.Format("Vol. {0}", vol);

        HashSet<string> VolumeMarkers(byte min, byte max)
        {
            var dst = hashset<string>();
            for(var i=min; i<=max; i++)
                dst.Add(VolumeMarker(i));
            return dst;
        }
    }
}