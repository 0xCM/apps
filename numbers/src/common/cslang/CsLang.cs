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

        public static uint csharp(in StringTableSyntax syntax, ItemList<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(CsLang.format(4, StringTables.define(syntax, src)));
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        public static uint csharp(in StringTableSyntax syntax, ReadOnlySpan<string> src, ITextEmitter dst)
        {
            dst.WriteLine(string.Format("namespace {0}", syntax.TableNs));
            dst.WriteLine(Open());
            dst.WriteLine(string.Format("    using {0};", "System"));
            dst.WriteLine();
            dst.WriteLine(string.Format("    using static {0};", "core"));
            dst.WriteLine();
            dst.WriteLine(CsLang.format(4, StringTables.define(syntax, src)));
            dst.WriteLine(Close());
            return (uint)src.Length;
        }

        public static string format(uint margin, in StringTable src)
        {
            var dst = text.buffer();
            CsLang.render(margin, src, dst);
            return dst.Emit();
        }

        public static void render(uint margin, StringTable src, ITextBuffer dst)
        {
            var syntax = src.Syntax;
            if(src.EmitIdentifiers)
            {
                EmitIndex(margin, src, dst);
                dst.AppendLine();
            }

            dst.IndentLine(margin, PublicReadonlyStruct(syntax.TableName));
            dst.IndentLine(margin, Open());
            margin+=4;

            var OffsetsProp = nameof(MemoryStrings.Offsets);
            var DataProp = nameof(MemoryStrings.Data);
            var EntryCountProp = nameof(MemoryStrings.EntryCount);
            var CharCountProp = nameof(MemoryStrings.CharCount);
            var CharBaseProp = nameof(MemoryStrings.CharBase);
            var OffsetBaseProp = nameof(MemoryStrings.OffsetBase);
            var StringsProp = "Strings";

            dst.IndentLine(margin, Constant(EntryCountProp, src.EntryCount));
            dst.AppendLine();

            dst.IndentLine(margin, Constant(CharCountProp, (uint)src.Content.Length));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), CharBaseProp, Call("address", DataProp)));
            dst.AppendLine();

            dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryAddress), OffsetBaseProp, Call("address", OffsetsProp)));
            dst.AppendLine();

            var FactoryName = string.Format("{0}.{1}", nameof(memory), nameof(memory.strings));
            var FactoryCreate = Call(FactoryName, OffsetsProp, DataProp);

            if(src.Syntax.Parametric)
                dst.IndentLine(margin, StaticLambdaProp(string.Format("{0}<{1}>", nameof(MemoryStrings), syntax.EnumName), StringsProp, FactoryCreate));
            else
                dst.IndentLine(margin, StaticLambdaProp(nameof(MemoryStrings), StringsProp, FactoryCreate));
            dst.AppendLine();

            dst.IndentLine(margin, GSpanRes.format(Z0.SpanRes.bytespan(OffsetsProp, src.OffsetStorage)));
            dst.AppendLine();
            dst.IndentLine(margin, GSpanRes.format(Z0.SpanRes.charspan(DataProp, src.Content)));
            margin-=4;
            dst.IndentLine(margin, Close());
        }

        static void EmitIndex(uint margin, in StringTable src, ITextBuffer dst)
        {
            var count = src.EntryCount;
            var syntax = src.Syntax;
            dst.IndentLine(margin, string.Format("public enum {0} : {1}", syntax.EnumName, syntax.EnumKind.CsKeyword()));
            dst.IndentLine(margin, Chars.LBrace);
            margin+=4;
            for(var i=0u; i<count; i++)
            {
                ref readonly var id = ref src.Identifier(i);
                if(id.IsEmpty)
                    break;
                dst.IndentLineFormat(margin, "{0} = {1},", id, i);
            }
            margin-=4;
            dst.IndentLine(margin, Chars.RBrace);
        }


        public static CsEmitter emitter()
            => new();

        AppSvcOps AppSvc => Service(Wf.AppSvc);

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
            GSpanRes.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        public GStringLits StringLiterals()
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

        public GSwitchMap SwitchMap()
            => Service(()=> GSwitchMap.create(Wf));

        public GSpanRes SpanRes()
            => Service(() => GSpanRes.create(Wf));

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

        public StringTable GenStringTable(Identifier targetNs, ClrEnumKind kind, ItemList<string> src, CgTarget dst)
        {
            var name = src.Name;
            var syntax = StringTableSyntax.define(targetNs, name +"ST", name + "Kind", kind, targetNs);
            var table = StringTables.define(syntax, src);
            EmitTableCode(syntax, src, dst);
            EmitTableData(table, dst);
            return table;
        }

        public void GenStringTable(Identifier targetNs, Identifier table, ReadOnlySpan<string> values, CgTarget dst)
        {
            var syntax = StringTableSyntax.define(targetNs, table, true);
            EmitTableCode(syntax, values, dst);
            EmitTableData(StringTables.define(syntax, values), dst);
        }

        public void GenStringTable(Identifier ns, Identifier table, Identifier @enum, ReadOnlySpan<string> values, CgTarget cgdst)
        {
            var syntax = StringTableSyntax.define(ns, table, @enum, true);
            EmitTableCode(syntax, values, cgdst);
            EmitTableData(StringTables.define(syntax, values), cgdst);
        }

        FS.FileUri EmitTableCode(StringTableSyntax syntax, ItemList<string> src, CgTarget cgdst)
        {
            var dst = SourceFile(syntax.TableName, "stringtables", cgdst);
            var emitter = text.emitter();
            csharp(syntax, src, emitter);
            AppSvc.FileEmit(emitter.Emit(), src.Count, dst);
            return dst;
        }

        FS.FileUri EmitTableCode(StringTableSyntax syntax, ReadOnlySpan<string> src, CgTarget cgdst)
        {
            var dst = SourceFile(syntax.TableName, "stringtables", cgdst);
            var emitter = text.emitter();
            csharp(syntax, src, emitter);
            AppSvc.FileEmit(emitter.Emit(), src.Length, dst);
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