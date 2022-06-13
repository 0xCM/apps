//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiComments;
    using static ApiGranules;

    using K = ApiMdKind;

    public sealed class ApiMd : WfSvc<ApiMd>
    {
        ApiJit Jit => Wf.Jit();

        MsilPipe MsilSvc => Wf.MsilSvc();

        AppSvcOps AppSvc => Wf.AppSvc();

        ApiComments Comments => Wf.ApiComments();

        ModuleArchives Modules => Wf.ModuleArchives();

        ApiJit ApiJit => Service(Wf.ApiJit);

        IDbTargets ApiTargets()
            => AppDb.ApiTargets();

        IDbTargets ApiTargets(string scope)
            => AppDb.ApiTargets(scope);

        IDbTargets AssetTargets
            => AppDb.ApiTargets("assets");

        IDbTargets MsilTargets()
            => ApiTargets(msil);

        FS.FilePath MsilPath(ApiHostUri uri)
            => MsilTargets().Path(FS.hostfile(uri, FS.Il));

        public IApiCatalog Catalog
            => ApiRuntimeCatalog;

        public Assembly[] Components
            => data(K.Components,() => Modules.PartArchive().ManagedDll().Where(x => x.FileName.StartsWith("z0")).Select(x => x.Load()));

        public Index<IPart> Parts
            => data(K.ApiParts, () => Catalog.Parts);

        public Type[] EnumTypes
            => data(K.EnumTypes, () => Components
                .Enums()
                .Where(x => x.ContainsGenericParameters == false));

        public Index<Type> ApiTableTypes
            => data(K.ApiTables, () => Components.Types().Tagged<RecordAttribute>().Index());

        public Index<TableField> ApiTableFields
            => data(K.ApiTableFields, CalcTableFields);

        public Index<SymLiteralRow> SymLits
            => data(nameof(SymLiteralRow), () => Symbolic.symlits(Components));

        public Index<IApiHost> ApiHosts
            => data(K.ApiHosts, () => Catalog.ApiHosts.Index());

        public Index<ComponentAssets> ApiAssets
            => data(K.ApiAssets, () => CalcApiAssets());

        public Index<ApiDataType> DataTypes
            => data(K.DataTypes, () => Z0.DataTypes.discover(Components));

        public Index<DataTypeInfo> DataTypeInfo
            => data(K.DataTypeRecords, () => Z0.DataTypes.describe(DataTypes));

        public Index<ApiCmdRow> ApiCommands
            => data(K.ApiCommands, CalcApiCommands);

        public Index<ApiLiteral> ApiLiterals
            => data(nameof(K.ApiLiterals), () => Symbolic.apilits(Components));

        public Index<ApiFlowSpec> DataFlows
            => data(K.DataFlows, CalcDataFlows);

        public Index<BitMaskInfo> ApiBitMasks
            => Data(K.BitMasks, () => BitMask.masks(typeof(BitMaskLiterals)));

        public ConstLookup<string,Index<SymInfo>> ApiTokens
            => data(K.ApiTokens, CalcApiTokens);

        public CommentDataset ApiComments
            => data(K.ApiComments, () => Comments.Calc());

        public ApiParserLookup Parsers
            => data(K.Parsers, () => Z0.Parsers.contracted(Components));

        public Index<ClrEnumRecord> EnumRecords(Assembly src)
            => Data(src.GetSimpleName() + nameof(ClrEnumRecord), () => Enums.records(src));

        public void EmitDatasets()
        {
            exec(true,
                EmitDataFlows,
                EmitTypeLists,
                EmitApiLiterals,
                EmitDataTypes,
                () => EmitComments(),
                () => EmitAssets(),
                () => Emit(SymLits),
                EmitParsers,
                EmitApiTables,
                EmitApiCommands,
                () => EmitApiTokens(),
                EmitApiBitMasks
            );
        }

        public ConstLookup<string,Index<SymInfo>> EmitApiTokens()
        {
            ApiTargets(tokens).Clear();
            var lookup = ApiTokens;
            var names = lookup.Keys;
            for(var i=0; i<names.Length; i++)
                EmitApiTokens(skip(names,i), lookup[skip(names,i)]);
            return lookup;

            void EmitApiTokens(string name, Index<SymInfo> src)
                => TableEmit(src, ApiTargets(tokens).Table<SymInfo>(name), TextEncodingKind.Unicode);
        }

        public ApiHostCatalog HostCatalog(Type src)
            => HostCatalog(ApiRuntimeLoader.apihost(src));

        Index<ComponentAssets> CalcApiAssets()
            => Assets.extract(Components);

        AssetCatalog EmitAssets()
        {
            AssetTargets.Delete();
            var catalog = Emit(ApiAssets);
            Emit(catalog);
            // var entries = list<AssetCatalogEntry>();
            // iter(Components, x => Emit(Assets.extract(x), entries), true);
            // var catalog = new AssetCatalog(entries.ToArray().Sort().Resequence());
            // Emit(catalog);
            return catalog;
        }

        public AssetCatalog Emit(Index<ComponentAssets> src)
        {
            var counter = 0u;
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var assets = ref src[i];
                var count = assets.Count;
                var targets = AssetTargets.Targets(assets.Source.GetSimpleName());
                for(var j=0; j<count; j++)
                {
                    ref readonly var asset = ref assets[j];
                    FileEmit(Assets.utf8(asset), targets.Path(asset.Name.ShortFileName), TextEncodingKind.Utf8);
                    counter++;
                }
            }

            return new AssetCatalog(src.SelectMany(x => x).Select(e => Assets.entry(e)));
        }

        public void Emit(ComponentAssets src, List<AssetCatalogEntry> entries)
        {
            var count = src.Count;
            var targets = AssetTargets.Targets(src.Source.GetSimpleName());
            for(var i=0; i<count; i++)
            {
                ref readonly var asset = ref src[i];
                FileEmit(Assets.utf8(asset), targets.Path(asset.Name.ShortFileName), TextEncodingKind.Utf8);
                entries.Add(Assets.entry(asset));
            }
        }

        public void Emit(AssetCatalog src)
            => TableEmit(src.Entries, AppDb.ApiTargets().Table<AssetCatalogEntry>());

        public void EmitAssetCatalog<T>(T src)
            where T : IAssets
                => TableEmit(src.Data, AppDb.ApiTargets("assets").Table<AssetCatalogEntry>(src.DataSource.GetSimpleName()), TextEncodingKind.Unicode);


        public ApiHostCatalog HostCatalog(IApiHost src)
        {
            var members = ApiJit.JitHost(src);
            return members.Length == 0 ? ApiHostCatalog.Empty : new ApiHostCatalog(src, members);
        }

        Index<ApiHostCatalog> HostCatalogs(IApiPartCatalog src)
        {
            var running = Running($"Computing {src.PartId.Format()} members");
            var catalogs = src.ApiHosts.Map(HostCatalog);
            Ran(running, $"Computed mebers for {catalogs.Length} {src.PartId.Format()} hosts");
            return catalogs;
        }

        ConcurrentDictionary<PartId,Index<ApiHostCatalog>> HostCatalogs()
        {
            var dst = cdict<PartId, Index<ApiHostCatalog>>();
            iter(Catalog.PartCatalogs(), part => dst.TryAdd(part.PartId, HostCatalogs(part)), true);
            return dst;
        }

        public Index<ApiRuntimeMember> CalcRuntimeMembers()
        {
            var src = HostCatalogs();
            var dst = bag<ApiRuntimeMember>();
            iter(src.Values.Array().SelectMany(x => x), catalog => {
                var members = catalog.Members;
                for(var i=0; i<members.Count; i++)
                {
                    var row = default(ApiRuntimeMember);
                    ref readonly var member = ref members[i];
                    row.Part = member.Host.Part;
                    row.Token = member.Msil.Token;
                    row.Address = member.BaseAddress;
                    row.DisplaySig = Clr.display(member.Method.Artifact());
                    row.Uri = member.OpUri;
                    dst.Add(row);
                }
            },true);
            return dst.Array().Sort().Resequence();
        }

        public void EmitIndex(Index<ApiRuntimeMember> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiRuntimeMember>(), TextEncodingKind.Utf8);

        void EmitApiCommands()
            => Emit(ApiCommands);

        void EmitApiLiterals()
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
            => Emit(DataTypeInfo);

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
            FileEmit(emitter.Emit(), parsers.Count, AppDb.ApiTargets().Path("api.parsers", FileKind.Csv));
        }


        public void EmitComments()
        {
            Comments.Collect();
        }

        public FS.FilePath EmitTypeList(string name, ReadOnlySpan<Type> src)
        {
            var path = AppDb.ApiTargets().Path(name, FileKind.List);
            var dst = text.emitter();
            for(var i=0; i<src.Length; i++)
                dst.AppendLine(skip(src,i).AssemblyQualifiedName);
            FileEmit(dst.Emit(), src.Length, path);
            return path;
        }

        public void Emit(ReadOnlySpan<SymKindRow> src)
            => TableEmit(src, AppDb.ApiTargets().Table<SymKindRow>());

        public void Emit(ReadOnlySpan<ApiCmdRow> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiCmdRow>());

        public void Emit(ReadOnlySpan<TableField> src)
            => TableEmit(src, AppDb.ApiTargets().Table<TableField>());

        public void Emit(ReadOnlySpan<SymLiteralRow> src)
            => TableEmit(src, AppDb.ApiTargets().Path("api.symbols", FileKind.Csv), TextEncodingKind.Unicode);

        public void Emit(ReadOnlySpan<ApiLiteral> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiLiteral>(), TextEncodingKind.Unicode);

        public void Emit(ReadOnlySpan<DataTypeInfo> src)
            => TableEmit(src, AppDb.ApiTargets().Table<DataTypeInfo>());

        public void Emit(ReadOnlySpan<ApiFlowSpec> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ApiFlowSpec>());

        public void Emit(ReadOnlySpan<ClrEnumRecord> src)
            => TableEmit(src, AppDb.ApiTargets().Table<ClrEnumRecord>(), TextEncodingKind.Unicode);

        public void Emit(Index<BitMaskInfo> src)
            => TableEmit(src, ProjectDb.ApiTablePath<BitMaskInfo>());

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

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil(ReadOnlySpan<IApiHost> hosts, IDbTargets dst)
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
                FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
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
                FileEmit(buffer.Emit(), members.Count, path, TextEncodingKind.Unicode);
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

        public Index<SymLiteralRow> EmitSymLits()
            => EmitSymLits(ApiTargets().Table<SymLiteralRow>());

        public Index<SymLiteralRow> EmitSymLits<E>()
            where E : unmanaged, Enum
                => EmitSymLits<E>(ApiTargets().Table<SymLiteralRow>(typeof(E).FullName));

        Index<SymLiteralRow> EmitSymLits(FS.FilePath dst)
            => EmitSymLits(Components, dst);

        Index<SymLiteralRow> EmitSymLits<E>(FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var flow = EmittingTable<SymLiteralRow>(dst);
            var rows = Symbolic.symlits<E>();
            var count = rows.Length;
            var formatter = Tables.formatter<SymLiteralRow>();
            using var writer = dst.Writer(TextEncodingKind.Unicode);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(rows[i]));
            EmittedTable<SymLiteralRow>(flow, count);
            return rows;
        }

        Index<SymLiteralRow> EmitSymLits(Assembly[] src, FS.FilePath dst)
        {
            var data = Symbolic.symlits(src);
            TableEmit(data, dst, TextEncodingKind.Unicode);
            return data;
        }

        public Index<SymDetailRow> EmitDetails<E>(Symbols<E> src, FS.FilePath dst)
            where E : unmanaged, Enum
        {
            var count = src.Count;
            var buffer = alloc<SymDetailRow>(count);
            for(var i=0; i<count; i++)
                Symbols.detail(src[i], (ushort)count, out seek(buffer,i));
            TableEmit(buffer,dst);
            return buffer;
        }

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

        public Index<SymInfo> EmitApiTokens(Type src)
        {
            var syms = Symbols.syminfo(src);
            var name = src.Name.ToLower();
            var dst = ApiTargets().Table<SymInfo>(tokens + "." +  name);
            TableEmit(syms, dst, TextEncodingKind.Unicode);
            return syms;
        }


        public Index<SymInfo> EmitApiTokens(ITokenGroup src, FS.FilePath dst)
        {
            var data = Symbols.syminfo(src.TokenTypes);
            TableEmit(data, dst, TextEncodingKind.Unicode);
            return data;
        }


    }
}