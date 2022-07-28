//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiMdEmitter : WfSvc<ApiMdEmitter>
    {
        IApiPack Target;

        ApiMd Md;

        ApiMemory ApiMemory => Wf.ApiMemory();

        ApiComments Comments => Wf.ApiComments();

        ApiCatalogs ApiCatalogs => Wf.ApiCatalogs();

        internal static ApiMdEmitter create(IWfRuntime wf, ApiMd md, IApiPack dst)
        {
            var svc = create(wf);
            svc.Target = dst;
            svc.Md = md;
            return svc;
        }

        public void Emit()
        {
            var components = Md.Components;
            var symlits = Symbolic.symlits(components);
            exec(true,
                Md.EmitDataFlows,
                () => EmitComments(Target),
                () => Md.EmitAssets(),
                () => EmitSymLits(symlits),
                () => Md.EmitApiLiterals(Symbolic.apilits(components)),
                () => EmitApiDeps(Target),
                Md.EmitParsers,
                Md.EmitApiTables,
                Md.EmitApiCommands,
                EmitTypeLists,
                () => ApiMemory.EmitSymHeap(Heaps.load(symlits), Target)
            );
        }

        public void EmitPartList()
        {
            var dst = text.emitter();
            var src = Md.Components.Index();
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i].GetName().FullName);
            FileEmit(dst.Emit(), AppDb.ApiTargets().Path("api.parts", FileKind.List));
        }

        public void EmitApiIndex()
            => Emit(ApiCatalogs.CalcRuntimeMembers());

        public void EmitApiTables()
            => Emit(Md.ApiTableFields);

        public void EmitTokens()
            => EmitApiTokens(CalcApiTokens());

        public void EmitTokens(ITokenGroup src)
            => TableEmit(Symbols.syminfo(src.TokenTypes), Target.Table<SymInfo>($"{src.GroupName}"), TextEncodingKind.Unicode);

        public void EmitTypeLists()
        {
            EmitTypeList("api.types.enums", Md.EnumTypes);
            EmitTypeList("api.types.records", Md.ApiTableTypes);
        }

        public void EmitApiComments()
            => Comments.Collect(AppDb.ApiTargets(comments));

        public void EmitApiDeps()
            => iter(sys.array(ExecutingPart.Component), a => EmitApiDeps(a, AppDb.ApiTargets().Path($"{a.GetSimpleName()}", FileKind.DepsList)), true);

        public void EmitApiSymbols()
            => TableEmit(Symbolic.symlits(Md.Components), AppDb.ApiTargets().Table<SymLiteralRow>(), UTF16);

        void EmitComments(IApiPack dst)
            => Comments.Collect(dst);

        void EmitApiDeps(IApiPack dst)
            => iter(sys.array(ExecutingPart.Component), a => EmitApiDeps(a,Target.Runtime().Path($"{a.GetSimpleName()}", FileKind.DepsList)), true);

        void EmitTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = Target.PrefixedTable<SymInfo>("tokens" + "." +  name);
            TableEmit(syms, dst, TextEncodingKind.Unicode);
        }

        void EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            FileEmit(dst.Emit(), src.Length, path);
        }

        void EmitApiDeps(Assembly src, FS.FilePath dst)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            FileEmit(emitter.Emit(), buffer.Count, dst);
        }

        void EmitSymLits(ReadOnlySpan<SymLiteralRow> src)
            => TableEmit(src, Target.Metadata().Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);

        ConstLookup<Name,ReadOnlySeq<SymInfo>> CalcApiTokens()
            => Symbols.lookup(Md.EnumTypes.Tagged<SymSourceAttribute>());

        void EmitApiTokens(ConstLookup<Name,ReadOnlySeq<SymInfo>> src)
        {
            var names = src.Keys;
            for(var i=0; i<names.Length; i++)
                Emit(skip(names,i), src[skip(names,i)]);
        }

        void Emit(ReadOnlySpan<ApiTableField> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiTableField>());


        void Emit(ReadOnlySpan<ApiRuntimeMember> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiRuntimeMember>(), TextEncodingKind.Utf8);

        void Emit(Name name, ReadOnlySeq<SymInfo> src)
            => TableEmit(src, Md.ApiTargets(tokens).PrefixedTable<SymInfo>(name), TextEncodingKind.Unicode);
    }
}