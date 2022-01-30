//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static CsPatterns;

    public class CgSvc : AppService<CgSvc>
    {
        ConstLookup<CgTarget,string> TargetExpressions;

        public CgSvc()
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

        public StringLiteralGen StringLiterals()
            => Service(() => StringLiteralGen.create(Wf));

        public EnumGen EnumGen()
            => Service(() => new EnumGen());

        public ShellGen Shells()
            => Service(() => ShellGen.create(Wf));

        public HexStringGen HexStrings()
            => Service(() => HexStringGen.create(Wf));

        public SwitchMapGen SwitchMap()
            => Service(()=> SwitchMapGen.create(Wf));

        public RecordGen Records()
            => Service(() => RecordGen.create(Wf));

        public AsmFileGen AsmFiles()
            => Service(() => AsmFileGen.create(Wf));

        public AsciLookupGen AsciLookups()
            => Service(() => AsciLookupGen.create(Wf));

        public InterfaceGen Interfaces()
            => Service(() => InterfaceGen.create(Wf));

        public LiteralProviderGen LiteralProvider()
            => Service(() => LiteralProviderGen.create(Wf));

        public FS.FolderPath CodeGenDir(string scope)
            => Env.ZDev + FS.folder("generated/src") + FS.folder(scope);

        public FS.FilePath CodeGenPath(string scope, string id, FS.FileExt ext)
            => CodeGenDir(scope) + FS.file(id,ext);

        string TargetExpr(CgTarget target)
            => TargetExpressions[target];

        public FS.FolderPath SlnRoot
            => Env.ZDev + FS.folder("codegen");

        public FS.FolderPath ProjectRoot(CgTarget target)
            => SlnRoot + FS.folder(TargetExpr(target));

        public FS.FilePath ProjectPath(CgTarget target)
            => ProjectRoot(target) + FS.file(string.Format("z0.{0}", TargetExpr(target)), FS.CsProj);

        public FS.FolderPath SourceRoot(CgTarget target)
            => ProjectRoot(target) + FS.folder("src");

        public FS.FilePath SourceFile(string name,  CgTarget target)
            => SourceRoot(target) + FS.file(name, FS.Cs);

        public FS.Files SourceFiles(CgTarget target)
            => SourceRoot(target).Files(FS.Cs, true);

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
            var flow = Wf.EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            var count = GenSymFactories(margin + 4, name, enums, buffer);
            buffer.IndentLine(margin, Close());
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());
            Wf.EmittedFile(flow,count);
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
                var func = PublicOneLineFunc("string", name, Empty(), RP.enquote(symbol));
                dst.IndentLine(margin, func);
                dst.AppendLine();
                counter++;
            }
            return counter;
        }
    }
}