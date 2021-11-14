//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    public class DocServices : AppService<DocServices>
    {
        public DocServices()
        {

        }

        public Outcome Split(FS.FilePath specpath)
        {
            var specs = LoadSplitSpecs(specpath);
            var buffer = new CBag<LineRange>();
            iter(specs, spec => Split(spec, buffer));
            return true;
        }

        public Outcome VerifyLinedDoc(FS.FilePath src, TextEncodingKind encoding)
        {
            var outcome = Outcome.Success;
            using var reader = src.LineReader(encoding);
            var counter = 1u;
            while(reader.Next(out var line))
            {
                if(counter != line.LineNumber)
                {
                    outcome = (false, string.Format("{0} != {1}:{2}", counter, line.LineNumber, line.Content));
                    break;
                }
                counter++;
            }
            return outcome;
        }

        public ReadOnlySpan<DocSplitSpec> LoadSplitSpecs(FS.FilePath src)
        {
            var pipe = DocSplitSpecs.Service;
            var outcome = pipe.Load(src, out var specs);
            if(outcome.Fail)
                Wf.Error(outcome.Message);
            return specs;
        }

        public Outcome CombineDocs(ReadOnlySpan<FS.FilePath> src, FS.FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var count = src.Length;
            var result = Outcome.Success;
            var flow = Wf.EmittingFile(dst);
            var counter = 0u;
            using var writer = dst.Writer(encoding.Right);
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                if(input.IsEmpty)
                {
                    result = (false,string.Format("A supplied source path at index {0} is empty", i));
                    Wf.Error(result.Message);
                    return result;
                }
                if(!input.Exists)
                {
                    result = (false,FS.Msg.DoesNotExist.Format(input));
                    Wf.Error(result.Message);
                    return result;
                }

                var processing = Wf.Running(string.Format("Appending {0} to {1}", input.ToUri(), dst.ToUri()));
                using var reader = input.Reader(encoding.Left);
                var line = reader.ReadLine();
                while(line != null)
                {
                    writer.WriteLine(line);
                    counter++;
                    line = reader.ReadLine();
                }
                Wf.Ran(processing);
            }
            Wf.EmittedFile(flow,counter);
            return result;
        }

        public Outcome<uint> CreateLinedDoc(FS.FilePath src, FS.FilePath dst, Pair<TextEncodingKind> encoding)
        {
            var flow = Wf.Running(string.Format("{0} => {1}", src.ToUri(), dst.ToUri()));
            var outcome = FS.lines(src,dst,encoding);
            if(outcome)
                Wf.Ran(flow, string.Format("Emitted {0} lines", outcome.Data));
            else
                Error(outcome.Message);
            return outcome;
        }

        void Split(in DocSplitSpec spec, IReceiver<LineRange> dst)
        {
            var project = Ws.Project("intel.docs");
            var src = project.Subdir("sources") + FS.file(spec.DocId, FS.Txt);
            if(!src.Exists)
            {
                Error(FS.missing(src));
                return;
            }

            using var reader = src.Reader(TextEncodingKind.Unicode);
            var counter = 1u;
            var count = spec.LastLine - spec.FirstLine + 1;
            var range = Lines.range(spec.FirstLine, spec.LastLine, alloc<TextLine>(count));
            var lines = range.Edit;
            var i=0;
            var line = reader.ReadLine();
            while(line != null && counter++ <= spec.LastLine && i<count)
            {
                line = reader.ReadLine();
                if(counter >= spec.FirstLine)
                    seek(lines, i++) = Lines.line(counter, line);
            }

            var path = project.Subdir("imports") +  FS.file(string.Format("{0}-{1}", spec.DocId, spec.Unit), FS.Txt);
            Emit(range, path);
            dst.Deposit(range);
        }

        void Emit(in LineRange src, FS.FilePath dst)
        {
            var emitting = Wf.EmittingFile(dst);
            using var writer = dst.Writer(TextEncodingKind.Unicode);
            var data = src.View;
            var count = data.Length;
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(data,i));
            Wf.EmittedFile(emitting, count);
        }
    }
}