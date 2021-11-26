//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata;

    using static core;

    public sealed class MsilPipe : AppService<MsilPipe>
    {
        const string CommentToken = "// ";

        const string CilCodeHeader = CommentToken + "Id:{0,-16} BaseAddress:{1,-16} Uri:{2}";

        const string CilSigHeader = CommentToken + "CliSig:[{0}] = [{1}]";

        const string CilEncodedHeader = CommentToken + "Encoded[{0}] = [{1}]";

        const string CilPageBreak = CommentToken + RP.PageBreak120;

        ILVisualizer IlViz;

        public MsilPipe()
        {
            IlViz = Cil.visualizer();
        }

        public Index<MsilCapture> LoadCaptured()
        {
            var flow = Wf.Running($"Loading cil data rows");
            var input = CapturesFiles().View;
            var count = input.Length;
            var dst = DataList.create<MsilCapture>();
            var row = default(MsilCapture);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(input,i);
                using var reader = path.Utf8Reader();
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(parse(line, out row))
                    {
                        dst.Add(row);
                    }
                    else
                    {
                        Wf.Warn($"The content {line} could not be parsed");
                    }
                }
            }
            Wf.Ran(flow,$"Loaded {dst.Count} cil rows");
            return dst.Emit();
        }

        public FS.Files MetadataFiles()
            => Db.TableDir<MsilMetadata>().AllFiles;

        public FS.Files CapturesFiles()
            => Db.CilPaths.CilDataPaths();

        public Index<MsilMetadata> LoadMetadata(FS.FilePath src)
        {
            var flow = Wf.Running(src.ToUri());
            var dst = DataList.create<MsilMetadata>();
            using var reader = src.Utf8Reader();
            var fields = reader.ReadLine().SplitClean(Chars.Pipe);
            if(fields.Length != MsilMetadata.FieldCount)
            {
                Wf.Error(Tables.FieldCountMismatch.Format(MsilMetadata.FieldCount, fields.Length));
                return Index<MsilMetadata>.Empty;
            }

            var row = default(MsilMetadata);
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var outcome = parse(line, out row);
                if(outcome)
                    dst.Add(row);
                else
                    Wf.Warn(line);
            }

            Wf.Ran(flow, dst.Count);
            return dst.Emit();
        }

        public void EmitCode(ReadOnlySpan<MsilMetadata> src, FS.FilePath dst)
        {
            var count = src.Length;
            if(count == 0)
                return;

            var builder = text.build();
            var flow = Wf.EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                builder.Clear();
                ref readonly var row = ref skip(src,i);
                if(i != 0)
                    writer.WriteLine(CilPageBreak);

                writer.WriteLine("// Token:{0,-16} Rva:{1,-12} | Size:{2,-8} | Method:{3}:{4}", row.Token, row.MethodRva, row.BodySize, row.ImageName, row.MethodName);
                writer.WriteLine(CilPageBreak);
                IlViz.DumpMethod(row.MaxStack, row.Code.View, builder);
                writer.WriteLine(builder.ToString());
                writer.WriteLine();

            }

            Wf.EmittedFile(flow, count);
        }

        public void EmitCode(Index<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Count;
            var builder = text.build();
            if(count != 0)
            {
                var flow = Wf.EmittingFile(dst);
                var view = src.View;
                using var writer = dst.Writer();
                for(var i=0u; i<count; i++)
                {
                    ref readonly var code = ref skip(view,i);
                    var member = code.Member;
                    var cil = member.Msil;
                    var sig = code.CliSig.Data;
                    var bytes = cil.CliCode;
                    writer.WriteLine(CilPageBreak);
                    writer.WriteLine(string.Format(CilCodeHeader, member.Token, member.BaseAddress, member.OpUri));
                    writer.WriteLine(string.Format(CilSigHeader, sig.Length, sig.Format()));
                    writer.WriteLine(string.Format(CilEncodedHeader, bytes.Length, bytes.Format()));
                    writer.WriteLine(CommentToken + member.Metadata.DisplaySig);
                    builder.Clear();
                    IlViz.DumpILBlock(bytes, bytes.Length, builder);
                    writer.WriteLine("{");
                    writer.Write(builder.ToString());
                    writer.WriteLine("}");
                    writer.WriteLine();
                }

                Wf.EmittedFile(flow, count);
            }
        }

        public void RenderCode(ApiMsil src, ITextBuffer dst)
        {
            var bytes = src.CliCode;
            var sig = src.CliSig.Data;
            dst.AppendLine(CilPageBreak);
            dst.AppendLine(string.Format(CilCodeHeader, src.Token, src.BaseAddress, src.Uri));
            dst.AppendLine(string.Format(CilSigHeader, sig.Length, sig.Format()));
            dst.AppendLine(string.Format(CilEncodedHeader, bytes.Length, bytes.Format()));
            dst.AppendLine("{");
            IlViz.DumpILBlock(bytes, bytes.Length, dst.ToStringBuilder());
            dst.AppendLine("}");
            dst.AppendLine();
        }

        public Index<MsilCapture> EmitData(Index<ApiMemberCode> src, FS.FilePath dst)
        {
            var count = src.Count;
            var buffer = alloc<MsilCapture>(count);
            if(count != 0)
            {
                ref var target = ref first(buffer);
                var flow = Wf.EmittingTable<MsilCapture>(dst);
                var view = src.View;
                var formatter = Tables.formatter<MsilCapture>(MsilCapture.RenderWidths);
                using var writer = dst.Writer();
                writer.WriteLine(formatter.FormatHeader());
                for(var i=0u; i<count; i++)
                {
                    ref var row = ref seek(target,i);
                    fill(skip(view,i).Member, ref row);
                    writer.WriteLine(formatter.Format(row));
                }

                Wf.EmittedTable(flow, count);
            }
            return buffer;
        }

        static ref MsilCapture fill(in ApiMember src, ref MsilCapture dst)
        {
            var cil = src.Msil;
            dst.BaseAddress = cil.BaseAddress;
            dst.Token = src.Token;
            dst.Uri = src.OpUri;
            dst.Encoded = cil.CliCode;
            return ref dst;
        }

        static bool parse(string src, out MsilCapture dst)
        {
            var parts = @readonly(src.SplitClean(Chars.Pipe));
            var count = parts.Length;
            if(count != MsilCapture.FieldCount)
            {
                dst = default;
                return false;
            }
            else
            {
                var i=0;
                DataParser.parse(skip(parts,i++), out dst.Token);
                DataParser.parse(skip(parts,i++), out dst.BaseAddress);
                DataParser.parse(skip(parts,i++), out dst.Uri);
                DataParser.parse(skip(parts,i++), out dst.Encoded);
                return true;
            }
        }

        static Outcome parse(string src, out MsilMetadata dst)
        {
            dst = default;
            var parts = @readonly(src.Split(Chars.Pipe));
            var count = parts.Length;
            if(count != MsilMetadata.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(MsilMetadata.FieldCount, count));
            else
            {
                var outcome = Outcome.Empty;
                var i=0;
                dst.ImageName = FS.file(skip(parts,i++));

                outcome = DataParser.parse(skip(parts,i++), out dst.Token);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.MethodRva);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.BodySize);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.MaxStack);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.LocalInit);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.MethodName);
                if(!outcome)
                    return outcome;

                outcome = DataParser.parse(skip(parts,i++), out dst.Code);
                return outcome;
            }
        }
    }
}