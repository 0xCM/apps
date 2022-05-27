//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiServices : AppService<ApiServices>
    {
        AppDb AppDb => Service(Wf.AppDb);

        AppSvcOps AppSvc => Service(Wf.AppSvc);

        public ApiEmitters Emitters => Service(Wf.ApiEmitters);

        public ApiComments Comments => Service(Wf.ApiComments);

        Index<Assembly> _ApiParts;

        protected override void Initialized()
        {
            _ApiParts = ApiRuntimeCatalog.Components;
        }

        public ref readonly Index<Assembly> ApiParts
        {
            [MethodImpl(Inline)]
            get => ref _ApiParts;
        }

        public Index<ClrEnumRecord> EmitEnums(Assembly src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
                AppSvc.TableEmit(records, dst);
            return records;
        }

        public Index<CompilationLiteral> CalcCompilationLits()
            => Data(nameof(CalcCompilationLits), () => LiteralProvider.CompilationLiterals(ApiParts));

        public Index<DataTypeInfo> CalcDataTypes()
            => DataTypes.describe(ApiParts);

        public Index<ApiFlowSpec> CalcDataFlows()
        {
            return(Data(nameof(ApiFlowSpec),Calc));

            Index<ApiFlowSpec> Calc()
            {
                var src = ApiDataFlow.discover(ApiParts);
                var count = src.Length;
                var buffer = alloc<ApiFlowSpec>(count);
                for(var i=0; i<count; i++)
                {
                    ref var dst = ref seek(buffer,i);
                    ref readonly var flow = ref src[i];
                    dst.Actor = flow.Actor.Name;
                    dst.Source = flow.Source?.ToString() ?? EmptyString;
                    dst.Target = flow.Target?.ToString() ?? EmptyString;
                    dst.Description = flow.Format();
                }
                return buffer.Sort();
            }
        }

        public Index<ApiCmdRow> CalcApiCommands()
        {
            var types = Cmd.types(ApiRuntimeCatalog.Components);
            var buffer = list<ApiCmdRow>();
            foreach(var type in types)
            {
                var name = type.Tag<CmdAttribute>().Require().Name;
                var cmdargs = type.DeclaredInstanceFields();
                var instance = Activator.CreateInstance(type);
                var values = ClrFields.values(instance);
                foreach(var arg in cmdargs)
                {
                    var cmdarg = new ApiCmdRow();
                    cmdarg.CmdName = name;
                    cmdarg.CmdType = type.Name;
                    cmdarg.ArgName = arg.Name;
                    cmdarg.DataType = TypeSyntax.infer(arg.FieldType);
                    cmdarg.Expression = arg.Tag<CmdArgAttribute>().MapValueOrDefault(x => x.Expression, EmptyString);
                    cmdarg.DefaultValue = values[arg.Name].Value?.ToString() ?? EmptyString;
                    buffer.Add(cmdarg);
                }
            }

            return buffer.ToIndex();
        }

        public Index<ClrEnumRecord> CalcEnumRecords(Assembly src)
            => Data(src.GetSimpleName() + nameof(ClrEnumRecord), () => Enums.records(src));

        public Index<Type> CalcEnumTypes()
            => ApiParts.Storage
                .Enums()
                .Where(x => x.ContainsGenericParameters == false && nonempty(x.Namespace));

        public Dictionary<FS.FilePath, Dictionary<string,string>> EmitComments()
            => Data(nameof(EmitComments), () => Comments.Collect());

        public void Emit(ReadOnlySpan<ApiCmdRow> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<ApiCmdRow>());

        public void Emit(ReadOnlySpan<TableField> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<TableField>());

        public void Emit(ReadOnlySpan<SymLiteralRow> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);

        public void Emit(ReadOnlySpan<CompilationLiteral> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<CompilationLiteral>(), TextEncodingKind.Unicode);

        public void Emit(ReadOnlySpan<DataTypeInfo> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<DataTypeInfo>());

        public void Emit(ReadOnlySpan<ApiFlowSpec> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<ApiFlowSpec>());

        public void Emit(ReadOnlySpan<ClrEnumRecord> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<ClrEnumRecord>(), TextEncodingKind.Unicode);

        public FS.FilePath EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            AppSvc.FileEmit(dst.Emit(), src.Length, path);
            return path;
        }
    }
}