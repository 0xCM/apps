//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        Outcome Matcher0(CmdArgs args)
        {
            var gen = AppDb.CgStage("gen");
            var input = gen.Targets("sources").Path(FS.file("matcher-a", FS.Txt));
            var lines = input.ReadNumberedLines();
            var count = lines.Length;
            var histo = dict<char,uint>();
            var lengths = alloc<uint>(count);
            var terms = dict<string,uint>();
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var content = line.Content.Trim();
                terms[content] = (uint)content.Length;
                var term = span(content);
                var length = (uint)term.Length;
                seek(lengths,i) = length;

                for(var j=0; j<length; j++)
                {
                    ref readonly var c = ref skip(term,j);
                    if(histo.TryGetValue(c, out var n))
                        histo[c] = n + 1;
                    else
                        histo[c] = 1;
                }
            }

            var targets = gen.Targets("targets");
            var charcounts = histo.Map(x => (x.Key,x.Value)).OrderBy(x => x.Key);

            void EmitBuckets()
            {
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("hist")));
                var emitting = EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                for(var i=0; i<charcounts.Length; i++)
                {
                    ref readonly var bucket = ref skip(charcounts,i);
                    writer.WriteLine(string.Format("{0} | {1}", bucket.Key, bucket.Value));
                }
                EmittedFile(emitting, charcounts.Length);
            }

            void EmitTerms()
            {
                var sorted = terms.Map(x => (x.Key, x.Value)).OrderBy(x => x.Value);
                var max = gcalc.max(sorted.Select(x => x.Value).ToReadOnlySpan());
                var dst = targets.Path(input.FileName.ChangeExtension(FS.ext("terms")));
                var emitting = EmittingFile(dst);
                using var writer = dst.Utf8Writer();
                var s0 = RpOps.slot(0,math.negate((short)(max)));
                var s1 = RpOps.slot(1);
                var pattern = string.Concat(s0," | ", s1);
                iter(sorted, s => writer.WriteLine(string.Format(pattern, s.Key, s.Value)));
                EmittedFile(emitting, sorted.Length);
            }

            var buckets = Buckets.bucketize(lines.Select(x => x.Content.Trim()));
            Write(buckets.Format());

            return true;
        }
    }
}