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
                () => EmitComments(),
                () => Md.EmitAssets(),
                () => EmitSymLits(symlits),
                () => Md.EmitApiLiterals(Symbolic.apilits(components)),
                () => EmitApiDeps(sys.array(ExecutingPart.Component)),

                Md.EmitParsers,
                Md.EmitApiTables,
                Md.EmitApiCommands,
                EmitTypeLists,
                () => ApiMemory.EmitSymHeap(Heaps.load(symlits), Target)
            );
        }

        public void EmitApiTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = Target.PrefixedTable<SymInfo>("tokens" + "." +  name);
            TableEmit(syms, dst, TextEncodingKind.Unicode);
        }

        public void EmitApiTokens(ITokenGroup src)
            => TableEmit(Symbols.syminfo(src.TokenTypes), Target.Table<SymInfo>($"{src.GroupName}"), TextEncodingKind.Unicode);

        public void EmitComments()
            => Comments.Collect(Target);

        public void EmitApiDeps(ReadOnlySpan<Assembly> src)
            => iter(src, EmitApiDeps, true);

        public void EmitTypeLists()
        {
            EmitTypeList("api.types.enums", Md.EnumTypes);
            EmitTypeList("api.types.records", Md.ApiTableTypes);
        }

        public void EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            FileEmit(dst.Emit(), src.Length, path);
        }

        public void EmitApiDeps(Assembly src)
        {
            var deps = JsonDeps.load(src);
            var buffer = list<string>();
            iteri(deps.RuntimeLibs(), (i,lib) => buffer.Add(string.Format("{0:D4}:{1}",i,lib)));
            var emitter = text.emitter();
            iter(buffer, line => emitter.AppendLine(line));
            FileEmit(emitter.Emit(), buffer.Count, Target.Runtime().Path($"{src.GetSimpleName()}", FileKind.DepsList));
        }

        public void EmitSymLits(ReadOnlySpan<SymLiteralRow> src)
            => TableEmit(src, Target.Metadata().Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);
    }
}