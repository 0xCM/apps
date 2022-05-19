//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Xml;
    using System.IO;

    using static core;
    using static XedModels;
    using static IntelIntrinsics;

    public class IntelIntrinsicSvc  : AppService<IntelIntrinsicSvc>
    {
        AppServices AppSvc => Service(Wf.AppServices);

        FS.FolderPath Sources()
            => Ws.Project("db").Subdir("sources/intel");

        FS.FolderPath Targets()
            => Ws.Project("db").Subdir("intrinsics");

        FS.FilePath XmlSourcePath()
            => Sources() + FS.file("intel.intrinsics", FS.Xml);

        FS.FilePath DeclTargetPath()
            => Targets() + FS.file("intrinsics.declarations", FS.H);

        FS.FilePath AlgTargetPath()
            => Targets() + FS.file("intrinsics.algorithms", FS.Txt);

        FS.FilePath TableTargetPath()
            => Targets() + FS.file("intel.intrinsics", FS.Csv);

        FS.FilePath TableTargetPath(string subject)
            => Targets() + FS.file(string.Format("intel.intrinsics.{0}", subject), FS.Csv);

        public Index<Intrinsic> Emit()
        {
            var parsed = ParseXmlDoc().Sort();
            EmitAlgorithms(parsed);
            EmitRecords(parsed);
            EmitRecords(parsed,"Integer");
            EmitDeclarations(parsed);
            return parsed;
        }

        XmlDoc ReadXmlDoc()
            => XmlSourcePath().ReadUtf8();

        Index<Intrinsic> ParseXmlDoc()
            => Parse(ReadXmlDoc());

        void EmitAlgorithms(ReadOnlySpan<Intrinsic> src)
        {
            var count = src.Length;
            var dst = AlgTargetPath();
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(format(skip(src,i)));
            EmittedFile(flow, count);
        }

        void EmitDeclarations(ReadOnlySpan<Intrinsic> src)
        {
            var dst = DeclTargetPath();
            var flow = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(string.Format("{0};", sig(skip(src,i))));
            EmittedFile(flow, count);
        }

        void Summarize(ReadOnlySpan<Intrinsic> src, List<IntelIntrinsic> dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                Fill(skip(src,i), out var record);
                dst.Add(record);
            }
        }

        void Fill(in Intrinsic src, out IntelIntrinsic dst)
        {
            dst.Name = src.name;
            dst.CpuId = src.CPUID.Map(x => x.Content);
            dst.Types = src.types.Map(x => x.Content);
            dst.Category = src.category;
            dst.Signature = sig(src);

            if(instruction(src, out var ix))
            {
                dst.Instruction = string.Format("{0} {1}", ix.name, ix.form);
                dst.Form = ix.xed;
            }
            else
            {
                dst.Instruction = EmptyString;
                dst.Form = default;
            }
        }

        void EmitRecords(Index<Intrinsic> src)
        {
            var buffer = list<IntelIntrinsic>();
            Summarize(src, buffer);
            AppSvc.TableEmit(buffer.Index().Sort(), TableTargetPath());
        }

        void EmitRecords(Index<Intrinsic> src, string type)
        {
            var rows = list<IntelIntrinsic>();
            Summarize(src, rows);
            var buffer = list<IntelIntrinsic>();
            foreach(var row in rows)
            {
                foreach(var t in row.Types)
                {
                    if(t == type)
                        buffer.Add(row);
                }
            }

            AppSvc.TableEmit(buffer.Index().Sort(), TableTargetPath(type.ToLower()));
        }

        Index<Intrinsic> Parse(XmlDoc src)
        {
            const ushort max = 7500;
            var entries = new Intrinsic[max];
            var i = -1;
            using var reader = XmlReader.Create(new StringReader(src.Content));
            while (reader.Read() && i<max - 1)
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    switch(reader.Name)
                    {
                        case Intrinsic.ElementName:
                            i++;
                            entries[i] = create();
                            entries[i].content = reader.Value;
                            entries[i].tech = reader[nameof(Intrinsic.tech)];
                            entries[i].name = reader[nameof(Intrinsic.name)];
                        break;

                        case Operation.ElementName:
                            read(reader, ref entries[i].operation);
                        break;

                        case Description.ElementName:
                            read(reader, ref entries[i].description);
                        break;

                        case Return.ElementName:
                            read(reader, ref entries[i].@return);
                        break;

                        case CpuId.ElementName:
                            read(reader, entries[i].CPUID);
                        break;

                        case IntelIntrinsics.Category.ElementName:
                            read(reader, ref entries[i].category);
                        break;

                        case Instruction.ElementName:
                            read(reader, entries[i].instructions);
                        break;

                        case InstructionType.ElementType:
                            read(reader, entries[i].types);
                        break;

                        case Parameter.ElementName:
                            read(reader, entries[i].parameters);
                        break;
                        case Header.ElementName:
                            read(reader, ref entries[i].header);
                        break;
                    }
                }
            }

            return slice(span(entries),0,i).ToArray();
        }

        static bool instruction(Intrinsic src, out Instruction dst)
        {
            var instructions = src.instructions;
            if(instructions.Count!=0)
            {
                dst = instructions[0];
                return true;
            }
            else
            {
                dst = default;
                return false;
            }
        }

        static void read(XmlReader reader, ref Operation dst)
        {
            const string amp = "&amp;";
            var content = reader.ReadInnerXml().Replace(XmlEntities.gt, ">").Replace(XmlEntities.lt, "<").Replace(amp, "&");
            foreach(var line in Lines.read(content,trim:false))
                dst.Content.Add(line);
        }

        static void read(XmlReader reader, CpuIdMembership dst)
            => dst.Add(reader.ReadInnerXml());

        static void read(XmlReader reader, ref IntelIntrinsics.Category dst)
            => dst.Content = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Header dst)
            => dst.Content = reader.ReadInnerXml();

        static void read(XmlReader reader, ref Description dst)
            => dst.Content = reader.ReadInnerXml().Replace("\n", " ");

        static void read(XmlReader reader, ref Return dst)
        {
            dst.varname = reader[nameof(Return.varname)];
            dst.etype = reader[nameof(Return.etype)];
            dst.type = reader[nameof(Return.type)];
            dst.memwidth =  reader[nameof(Return.memwidth)];
        }

        static void read(XmlReader reader, Parameters dst)
        {
            var element = new Parameter();
            element.varname = reader[nameof(Parameter.varname)];
            element.etype = reader[nameof(Parameter.etype)];
            element.type = reader[nameof(Parameter.type)];
            element.memwidth =  reader[nameof(Parameter.memwidth)];
            dst.Add(element);
        }

        static void read(XmlReader reader, InstructionTypes dst)
        {
            var element = new InstructionType();
            element.Content = reader.ReadInnerXml();
            dst.Add(element);
        }

        static void read(XmlReader reader, Instructions dst)
        {
            var element = new Instruction();
            element.name = reader[nameof(Instruction.name)];
            element.form = reader[nameof(Instruction.form)];
            element.xed = Enums.parse(reader[nameof(Instruction.xed)], default(IFormType));
            dst.Add(element);
        }

        static Intrinsic create()
        {
            var dst = new Intrinsic();
            dst.tech = EmptyString;
            dst.name = EmptyString;
            dst.content = EmptyString;
            dst.types = new InstructionTypes();
            dst.CPUID = new CpuIdMembership();
            dst.category = EmptyString;
            dst.@return = Return.Empty;
            dst.parameters = new Parameters();
            dst.description = EmptyString;
            dst.operation = new Operation(list<TextLine>());
            dst.instructions = new Instructions();
            dst.header = EmptyString;
            return dst;
        }

        static void render(Operation src, ITextBuffer dst)
        {
            if(src.Content != null)
                iter(src.Content, x => dst.AppendLine("  " + x.Content));
        }

        static string format(Instruction src)
             => string.Format("# Instruction: {0} {1}\r\n", src.name, src.form) + string.Format("# Iform: {0}", src.xed);

        static void render(Instructions src, ITextBuffer dst)
            => iter(src, x => dst.AppendLine(format(x)));

        static string sig(Intrinsic src)
            => string.Format("{0} {1}({2})", src.@return,  src.name,  string.Join(", ", src.parameters.ToArray()));

        static void body(Intrinsic src, ITextBuffer dst)
        {
            dst.AppendLine("{");
            render(src.operation, dst);
            dst.AppendLine("}");
        }

        static string format(Intrinsic src)
        {
            var dst = text.buffer();
            overview(src, dst);
            dst.AppendLine(sig(src));
            body(src, dst);
            return dst.Emit();
        }

        static void overview(Intrinsic src, ITextBuffer dst)
        {
            dst.AppendLine(string.Format("# Intrinsic: {0}", sig(src)));

            var classes = list<string>(3);
            if(nonempty(src.tech))
                classes.Add(src.tech);
            if(src.CPUID.Count != 0)
                classes.Add(string.Join(Chars.Comma, src.CPUID));
            if(src.category.IsNonEmpty)
                classes.Add(src.category.Content);
            if(classes.Count != 0)
                dst.AppendLineFormat("# Classification: {0}", string.Join(", ", classes));

            render(src.instructions, dst);
            dst.AppendLineFormat("# Description: {0}", src.description);
        }
    }
}