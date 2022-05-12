//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.IO;
    using static core;
    using static CsPatterns;
    using static CsLang;

    partial class XSvc
    {
        public static StringLiteralGen GenLiterals(this IWfRuntime wf)
            => StringLiteralGen.create(wf);

        public static GAsciLookup GenAsciLookups(this IWfRuntime wf)
            => GAsciLookup.create(wf);

        public static GRecord GenRecords(this IWfRuntime wf)
            => GRecord.create(wf);

        public static GLiteralProvider GenLiteralProviders(this IWfRuntime wf)
            => GLiteralProvider.create(wf);
    }

    public partial class CsLang : AppService<CsLang>
    {
        ConstLookup<CgTarget,string> TargetExpressions;

        public CsLang()
        {
            var symbols = Symbols.index<CgTarget>();
            var count = symbols.Count;
            var targets = dict<CgTarget,string>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref symbols[i];
                targets[sym.Kind] = sym.Expr.Format();
            }
            TargetExpressions = targets;
        }

        public static CsEmitter emitter()
            => new();

        AppServices AppSvc => Service(Wf.AppServices);

        public void EmitReplicants(Index<ClrEnumAdapter> enums, FS.FilePath dst)
        {
            var types = enums.GroupBy(x => x.Definition.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var keys = types.Keys;
            var counter = 0u;
            var buffer = text.emitter();
            var name = "EnumDefs";
            foreach(var ns in keys)
                counter += CsRender.replicants(ns, name, types[ns], buffer);
            AppSvc.FileEmit(buffer.Emit(), counter, dst);
        }

        public void EmitSymSpan<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var result = Outcome.Success;
            var emitting = EmittingFile(dst);
            var container = string.Format("{0}Data", typeof(E).Name);
            using var writer = dst.AsciWriter();
            EmitSymSpan<E>(container, writer);
        }

        void EmitSymSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            SpanResGen.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public StringLiteralGen StringLiterals()
            => Service(Wf.GenLiterals);

        public GAsciLookup AsciLookups()
            => Service(Wf.GenAsciLookups);

        public GRecord Records()
            => Service(Wf.GenRecords);

        public GInterface Interfaces()
            => Service(() => GInterface.create(Wf));

        public GBinaryKind BinaryKinds(uint max = 0xFF)
            => new GBinaryKind(max);

        public GLiteralProvider LiteralProviders()
            => Service(Wf.GenLiteralProviders);

        public GHexStrings HexStrings()
            => Service(() => GHexStrings.create(Wf));

        public SwitchMapGen SwitchMap()
            => Service(()=> SwitchMapGen.create(Wf));

        public SpanResGen SpanRes()
            => Service(() => SpanResGen.create(Wf));

        public void EmitArrayInitializer<T>(ItemList<Constant<T>> src, ITextBuffer dst)
        {
            var count = src.Count;
            var keyword = CsKeywords.keyword(typeof(T));
            dst.AppendFormat("{0} = new {1}[{2}]{{", src.Name, keyword, count);
            for(var i=0; i<count; i++)
            {
                ref readonly var item = ref src[i];
                dst.AppendFormat("{0},", item.Value.Format());
            }
            dst.Append("};");
        }

        public void GenSymFactories(Identifier ns, Identifier name, ReadOnlySpan<Type> enums, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            var count = GenSymFactories(margin + 4, name, enums, buffer);
            buffer.IndentLine(margin, Close());
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());
            EmittedFile(flow,count);
        }

        public uint GenSymFactories(uint margin, Identifier name, ReadOnlySpan<Type> enums, ITextBuffer dst)
        {
            dst.IndentLine(margin, PublicReadonlyStruct(name));
            dst.IndentLine(margin, Open());
            margin +=4;
            var counter = 0u;
            for(var i=0; i<enums.Length; i++)
            {
                ref readonly var type = ref skip(enums,i);
                var adapted = ClrEnumAdapter.adapt(type);
                counter += GenSymFactories(margin, adapted, dst);
            }
            margin -=4;
            dst.IndentLine(margin, Close());
            return counter;
        }

        public uint GenSymFactories(uint margin, ClrEnumAdapter src, ITextBuffer dst)
        {
            var counter = 0u;
            var members = src.Members;
            for(var j=0; j<members.Length; j++)
            {
                ref readonly var member = ref skip(members,j);
                var name = member.Name;
                var tag = member.Definition.Tag<SymbolAttribute>();
                var symbol = text.ifempty(tag.MapValueOrDefault(t => t.Symbol, name),name);
                var func = PublicOneLineFunc("string", name, Empty(), text.enquote(symbol));
                dst.IndentLine(margin, func);
                dst.AppendLine();
                counter++;
            }
            return counter;
        }


        public void GenEnumReplicants(Type[] enums, FS.FilePath dst)
        {
            var types = enums.GroupBy(x => x.Namespace).Map(x => (x.Key, x.ToArray())).ToDictionary();
            var keys = types.Keys;
            var counter = 0u;
            var buffer = text.buffer();
            var name = "EnumDefs";
            foreach(var ns in keys)
                counter += CsRender.enums(ns, name, types[ns], buffer);
            FileEmit(buffer.Emit(), counter, dst);
        }

        public Index<Type> LoadReplicantTypes(FS.FilePath src)
        {
            var running = Running(string.Format("Loading enum types from {0}", src.ToUri()));
            var buffer = list<Type>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsEmpty)
                    continue;

                var name = line.Content.Trim();
                var type = Type.GetType(name);
                if(type != null)
                    buffer.Add(type);
                else
                    Warn(string.Format("Unable to load {0}", name));
            }

            var dst = buffer.ToArray();
            Ran(running, string.Format("Loaded {0} enum types from {1}", dst.Length, src.ToUri()));
            return dst;
        }

        string TargetExpr(CgTarget target)
            => TargetExpressions[target];

        public FS.FolderPath SlnRoot
            => Env.ZDev + FS.folder("codegen");

        public FS.FolderPath ProjectRoot(CgTarget target)
            => SlnRoot + FS.folder(TargetExpr(target));

        public FS.FolderPath SourceRoot(CgTarget target)
            => ProjectRoot(target) + FS.folder("src");

        public FS.FilePath SourceFile(string name, CgTarget target)
            => SourceRoot(target) + FS.file(name, FS.Cs);

        public FS.FilePath SourceFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Cs);


        public FS.FilePath DataFile(string name, CgTarget target)
            => SourceRoot(target) + FS.file(name, FS.Csv);

        public FS.FilePath DataFile(string name, string scope, CgTarget target)
            => SourceRoot(target) + FS.folder(scope) + FS.file(name, FS.Csv);

        public void Emit<T>(CgSpec<T> spec, ITextBuffer dst)
        {
            var offset = 0u;
            dst.IndentLineFormat(offset, "namespace {0}", spec.TargetNs);
            dst.IndentLine(offset, Chars.LBrace);

            offset+=4;
            foreach(var u in spec.Usings)
                dst.IndentLine(offset, u);

            if(spec.Usings.Count != 0)
                dst.AppendLine();

            iter(spec.Content.ToString().Lines(), line => dst.IndentLine(offset,line.Content));

            offset-=4;
            dst.IndentLine(offset, Chars.RBrace);
        }

        public FS.FilePath EmitFile<T>(CgSpec<T> src, string name, CgTarget target)
        {
            var path = SourceFile(name, target);
            var emitting = EmittingFile(path);
            var buffer = text.buffer();
            Emit(src,buffer);
            using var writer = path.Utf8Writer();
            writer.WriteLine(buffer.Emit());
            EmittedFile(emitting,1);
            return path;
        }

        public FS.FilePath EmitFile(string src, string name, CgTarget target)
        {
            var path = SourceFile(name, target);
            var emitting = EmittingFile(path);
            using var writer = path.Utf8Writer();
            writer.WriteLine(src);
            EmittedFile(emitting,1);
            return path;
        }

        public void GenStringTable(Identifier targetNs, ClrEnumKind kind, ItemList<string> src, CgTarget dst)
        {
            var name = src.Name;
            var syntax = StringTables.syntax(targetNs + ".stringtables", name +"ST", name + "Kind", kind, targetNs);
            var table = StringTables.define(syntax, src);
            EmitTableCode(syntax, src, dst);
            EmitTableData(table, dst);
        }

        public void GenStringTable(Identifier targetNs, Identifier table, ReadOnlySpan<string> values, CgTarget dst)
        {
            var syntax = StringTables.syntax(targetNs, table);
            EmitTableCode(syntax, values, dst);
            EmitTableData(StringTables.define(syntax, values), dst);
        }

        public void GenStringTable(Identifier targetNs, Identifier table, Identifier @enum, ReadOnlySpan<string> values, CgTarget dst)
        {
            var syntax = StringTables.syntax(targetNs, table, @enum);
            EmitTableCode(syntax, values, dst);
            EmitTableData(StringTables.define(syntax, values), dst);
        }

        FS.FileUri EmitTableCode(StringTableSyntax src, ItemList<string> items, CgTarget target)
        {
            var dst = SourceFile(src.TableName, "stringtables", target);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            StringTables.csharp(src, items, writer);
            EmittedFile(emitting,1);
            return dst;
        }

        FS.FileUri EmitTableCode(StringTableSyntax src, ReadOnlySpan<string> values, CgTarget target)
        {
            var dst = SourceFile(src.TableName, "stringtables", target);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            StringTables.csharp(src, values, writer);
            EmittedFile(emitting,1);
            return dst;
        }

        FS.FileUri EmitTableData(StringTable src, CgTarget target)
        {
            var dst = DataFile(src.Syntax.TableName, "stringtables", target);
            var formatter = Tables.formatter<StringTableRow>(StringTableRow.RenderWidths);
            var emitting = EmittingFile(dst);

            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());

            for(var j=0u; j<src.EntryCount; j++)
                writer.WriteLine(formatter.Format(StringTables.row(src, j)));

            EmittedFile(emitting, src.EntryCount);
            return dst;
        }
    }
}