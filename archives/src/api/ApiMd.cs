//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using K = ApiMdKind;

    public sealed partial class ApiMd : AppService<ApiMd>
    {
        const string msil = nameof(msil);

        const string tokens = nameof(tokens);

        static DataTypeInfo dtinfo(Type src)
        {
            var dst = DataTypeInfo.Empty;
            var size = Sizes.measure(src);
            var width = Sizes.bits(src);
            dst.Name = src.DisplayName();
            dst.Component = src.Assembly.Name();
            dst.Concrete = src.IsConcrete();
            dst.PackedWidth = size.Packed;
            dst.NativeWidth = size.Native;
            dst.NativeSize = size.Native/8;
            return dst;
        }

        public static Index<DataTypeInfo> DescribeDataTypes(Assembly[] src, bool pll = true)
        {
            var dst = bag<DataTypeInfo>();
            iter(ClrDataTypes(src), t => dst.Add(dtinfo(t)), pll);
            return dst.ToArray().Index().Sort();
        }

        public static Index<DataType> DiscoverDataTypes(Assembly src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(ClrDataTypes(src), t => dst.Add(new DataType(t.Name, Sizes.measure(t))),pll);
            return dst.ToArray().Sort();
        }

        public static Index<DataType> DiscoverDataTypes(Assembly[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, a => iter(ClrDataTypes(a), t => dst.Add(new DataType(t.Name, Sizes.measure(t))), pll), pll);
            return dst.Index().Sort();
        }

        public static Index<DataType> DiscoverDataTypes(Type[] src, bool pll = true)
        {
            var dst = bag<DataType>();
            iter(src, t => dst.Add(new DataType(t.Name, Sizes.measure(t))),pll);
            return dst.Index().Sort();
        }

        static Type[] ClrDataTypes(Assembly src)
            => src.Types().Public().Where(x => x.IsStruct() || x.IsEnum);

        static Type[] ClrDataTypes(Assembly[] src)
            => src.SelectMany(ClrDataTypes);

        ApiJit Jit => Wf.Jit();

        MsilPipe MsilSvc => Wf.MsilSvc();

        AppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        ApiComments Comments => Wf.ApiComments();

        DbTargets ApiTargets()
            => AppDb.ApiTargets();

        DbTargets ApiTargets(string scope)
            => AppDb.ApiTargets(scope);

        DbTargets MsilTargets()
            => ApiTargets(msil);

        FS.FilePath MsilPath(ApiHostUri uri)
            => MsilTargets().Path(FS.hostfile(uri, FS.Il));

        public IApiCatalog Catalog
            => ApiRuntimeCatalog;

        public Assembly[] Components
            => data(K.Components,() => Catalog.Components);

        public Index<IPart> Parts
            => data(K.ApiParts, () => Catalog.Parts);

        public Type[] EnumTypes
            => data(K.EnumTypes, () => Components
                .Enums()
                .Where(x => x.ContainsGenericParameters == false && nonempty(x.Namespace)));

        public Index<Type> ApiTableTypes
            => data(K.ApiTables, () => Components.Types().Tagged<RecordAttribute>().Index());

        public Index<TableField> ApiTableFields
            => data(K.ApiTableFields, CalcTableFields);

        public Index<SymLiteralRow> SymLits
            => data(nameof(SymLiteralRow), () => Symbols.literals(ApiRuntimeCatalog.Components));

        // public ConstLookup<string,Index<Type>> SymSouces
        //     => data(K.SymGroups, CalcSymSources);

        public Index<IApiHost> ApiHosts
            => data(K.ApiHosts, () => Catalog.ApiHosts.Index());

        public Index<DataTypeInfo> DataTypes
            => data(K.DataTypes, () => DescribeDataTypes(Components));

        public Index<ApiCmdRow> ApiCommands
            => data(K.ApiCommands, CalcApiCommands);

        public Index<CompilationLiteral> ApiLiterals
            => data(nameof(K.ApiLiterals), () => literals(Components));

        public Index<ApiFlowSpec> DataFlows
            => data(K.DataFlows, CalcDataFlows);

        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));

        public ConstLookup<string,Index<SymInfo>> ApiTokens
            => data(K.ApiTokens, CalcApiTokens);

        public ApiParserLookup Parsers
            => data(K.Parsers, () => parsers(Components));

        public Index<ClrEnumRecord> EnumRecords(Assembly src)
            => Data(src.GetSimpleName() + nameof(ClrEnumRecord), () => Enums.records(src));

        public void EmitDatasets()
        {
            exec(true,
                EmitDataFlows,
                EmitTypeLists,
                EmitCompilationLits,
                EmitDataTypes,
                () => EmitComments(),
                () => Emit(SymLits),
                EmitParsers,
                EmitApiTables,
                EmitApiCommands,
                () => EmitApiTokens(),
                EmitApiBitMasks
            );
        }

        void EmitApiCommands()
            => Emit(ApiCommands);

        void EmitCompilationLits()
            => Emit(ApiLiterals);

        void EmitApiBitMasks()
            => Emit(ApiBitMasks);

        void EmitTypeLists()
        {
            EmitTypeList("api.types.enums", EnumTypes);
            EmitTypeList("api.types.records", ApiTableTypes);
        }

        void EmitDataFlows()
            => Emit(DataFlows);

        void EmitDataTypes()
            => Emit(DataTypes);

        void EmitApiTables()
            => Emit(ApiTableFields);

        void EmitParsers()
        {
            const string RenderPattern = "{0,-8} | {1,-8} | {2}";
            var cols = new string[]{"Seq", "Returns", "Target"};
            var parsers = Parsers;
            var emitter = text.emitter();
            emitter.AppendLineFormat(RenderPattern, cols);
            var i=0u;
            iter(parsers.Values.Index().Sort(), parser
                => emitter.AppendLineFormat(RenderPattern,
                    i++,
                    parser.ResultType.DisplayName(),
                    parser.TargetType.DisplayName()
                    ));
            AppSvc.FileEmit(emitter.Emit(), parsers.Count, AppDb.ApiTargets().Path("api.parsers", FileKind.Csv));
        }

        public Index<SymLiteralRow> LoadSymLits(FS.FilePath src)
        {
            using var reader = src.TableReader<SymLiteralRow>(SymLiteralRow.parse);
            var header = reader.Header.Split(Chars.Tab);
            if(header.Length != SymLiteralRow.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymLiteralRow.FieldCount, header.Length));
                return Index<SymLiteralRow>.Empty;
            }

            var dst = list<SymLiteralRow>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        public Dictionary<FS.FilePath, Dictionary<string,string>> EmitComments()
            => Data(nameof(EmitComments), () => Comments.Collect());

        public FS.FilePath EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            AppSvc.FileEmit(dst.Emit(), src.Length, path);
            return path;
        }

        public void Emit(ReadOnlySpan<SymKindRow> src)
            => AppSvc.TableEmit(src, AppDb.ApiTargets().Table<SymKindRow>());

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

        public void Emit(Index<BitMaskInfo> src)
            => AppSvc.TableEmit(src, ProjectDb.ApiTablePath<BitMaskInfo>());

        public void EmitHostMsil(string hostid)
        {
            var result = Outcome.Success;
            result = ApiParsers.host(hostid, out var uri);
            if(result.Ok)
            {
                result = ApiRuntimeCatalog.FindHost(uri, out var host);
                if(result.Ok)
                    EmitMsil(array(host));
            }

            if(result.Fail)
                Errors.Throw(result.Message);
        }

        Index<ApiFlowSpec> CalcDataFlows()
        {
            var src = ApiDataFlow.discover(Components);
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

        Index<ApiCmdRow> CalcApiCommands()
        {
            var types = Cmd.types(Components);
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

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil()
            => EmitMsil(ApiHosts);

        ApiMembers JitHost(IApiHost host)
            => Jit.JitHost(host);

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil(ReadOnlySpan<IApiHost> hosts, DbTargets dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FS.FilePath>();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var members = JitHost(host);
                var count = members.Length;
                if(members.Count == 0)
                    continue;

                for(var j=0; j<members.Count; j++)
                {
                    MsilSvc.RenderCode(members[j].Msil, buffer);
                    k++;
                }

                var path = dst.Path(FS.hostfile(host.HostUri, FS.Il));
                AppSvc.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                emitted[host.HostUri] = path;
            }
            return emitted;
        }

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil(ReadOnlySpan<IApiHost> hosts)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FS.FilePath>();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var members = JitHost(host);
                if(members.Count == 0)
                    continue;

                for(var j=0; j<members.Count; j++, k++)
                    MsilSvc.RenderCode(members[j].Msil, buffer);

                var path = MsilPath(host.HostUri);
                AppSvc.FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
                emitted[host.HostUri] = path;
            }

            return emitted;
        }

        ConstLookup<string,Index<SymInfo>> CalcApiTokens()
        {
            var types = EnumTypes.Tagged<SymSourceAttribute>();
            var groups = dict<string,List<Type>>();
            var individuals = list<Type>();
            foreach(var type in types)
            {
                var tag = type.Tag<SymSourceAttribute>().Require();
                var name = tag.SymGroup;
                if(nonempty(name))
                {
                    if(groups.TryGetValue(name, out var list))
                        list.Add(type);
                    else
                    {
                        list = new();
                        list.Add(type);
                        groups[name] = list;
                    }
                }
                else
                    individuals.Add(type);
            }

            var dst = dict<string,Index<SymInfo>>();
            foreach(var g in groups.Keys)
                dst[g] = Symbols.syminfo(groups[g].ViewDeposited());

            foreach(var i in individuals)
                dst[i.Name] = Symbols.syminfo(i);

            return dst;
        }

        public Index<Type> LoadTypes(FS.FilePath src)
        {
            var lines = src.ReadLines(skipBlank:true);
            var count = lines.Count;
            var dst = alloc<Type>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref lines[i];
                var type = Type.GetType(line) ?? typeof(void);
                if(type.IsEmpty())
                    Warn($"Unable to load {line}");
                seek(dst,i) = type;
            }
            return dst;
        }

        public void Emit(ReadOnlySpan<ClrEnumRecord> src, FS.FilePath dst)
            => AppSvc.TableEmit(src,dst);

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().Table<SymInfo>(tokens + "." +  name.ToLower());
            using var reader = src.TableReader<SymInfo>(SymInfo.parse);
            var header = reader.Header.Split(Chars.Pipe);
            if(header.Length != SymInfo.FieldCount)
            {
                Error(AppMsg.FieldCountMismatch.Format(SymInfo.FieldCount, header.Length));
                return Index<SymInfo>.Empty;
            }
            var dst = list<SymInfo>();
            while(!reader.Complete)
            {
                var outcome = reader.ReadRow(out var row);
                if(!outcome)
                {
                    Error(outcome.Message);
                    break;
                }
                dst.Add(row);
            }

            return dst.ToArray();
        }

        public Index<SymDetailRow> EmitDetails<E>(Symbols<E> src, FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var count = src.Count;
            var buffer = alloc<SymDetailRow>(count);
            for(var i=0; i<count; i++)
                Symbols.detail(src[i], (ushort)count, out seek(buffer,i));
            AppSvc.TableEmit(buffer,dst);
            return buffer;
        }

        // ConstLookup<string,Index<Type>> CalcSymSources()
        // {
        //     var types = SymSourceTypes.Index();
        //     var buffer = dict<string,List<Type>>();
        //     for(var i=0; i<types.Count; i++)
        //     {
        //         ref readonly var type = ref types[i];
        //         var tag = type.Tag<SymSourceAttribute>().Require();
        //         var name = tag.SymGroup;
        //         if(nonempty(name))
        //         {
        //             if(buffer.TryGetValue(name, out var list))
        //                 list.Add(type);
        //             else
        //             {
        //                 list = new();
        //                 list.Add(type);
        //                 buffer[name] = list;
        //             }
        //         }
        //     }

        //     return buffer.Map(x => (x.Key, x.Value.Index())).ToDictionary();
        // }

        static uint FieldCount(Index<Type> tables)
        {
            var counter = 0u;
            for(var i=0; i<tables.Count; i++)
                counter += tables[i].DeclaredInstanceFields().Ignore().Index().Count;
            return counter;
        }

        Index<TableField> CalcTableFields()
        {
            var tables = ApiTableTypes;
            var count = FieldCount(tables);
            var buffer = alloc<TableField>(count);
            var k=0u;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var type = ref tables[i];
                var fields = Tables.fields(type);
                var total = 0u;
                var id = TableId.identify(type).Format();
                var typename = type.DisplayName();
                for(var j=z16; j<fields.Length; j++, k++)
                {
                    ref readonly var src = ref skip(fields,j);
                    ref readonly var field = ref src.Definition;
                    ref var dst = ref seek(buffer,k);
                    var size = (ushort)(Sizes.bits(field.FieldType)/8);
                    total += size;
                    dst.Seq = j;
                    dst.TableId = id;
                    dst.TableType = typename;
                    dst.Col = j;
                    dst.FieldSize = size;
                    dst.TableSize = total;
                    dst.RenderWidth = src.FieldWidth;
                    dst.FieldName = field.Name;
                    dst.FieldType = field.FieldType.DisplayName();
                }
            }
            return buffer;
        }
    }
}