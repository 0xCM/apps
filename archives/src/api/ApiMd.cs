//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class ApiMd : AppService<ApiMd>
    {
        ApiJit Jit => Wf.Jit();

        MsilPipe MsilSvc => Wf.MsilSvc();

        AppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        ApiComments Comments => Wf.ApiComments();

        DbTargets ApiTargets()
            => AppDb.ApiTargets();

        DbTargets ApiTargets(string scope)
            => AppDb.ApiTargets(scope);

        ApiMembers HostMembers(IApiHost host)
            => Jit.JitHost(host);

        const string msil = nameof(msil);

        const string tokens = nameof(tokens);

        DbTargets MsilTargets() => ApiTargets(msil);

        FS.FilePath MsilPath(ApiHostUri uri)
            => MsilTargets().Path(FS.hostfile(uri, FS.Il));

        public Assembly[] Components
            => ApiRuntimeCatalog.Components;

        public Index<IPart> Parts
            => ApiRuntimeCatalog.Parts;

        public Type[] EnumTypes
            => data("EnumTypes", () => Components
                .Enums()
                .Where(x => x.ContainsGenericParameters == false && nonempty(x.Namespace)));

        public Index<ReflectedTable> ReflectedTables
            => data("ReflectedTable",() => Tables.reflected(Components));

        public Pairings<Type,SymSourceAttribute> TaggedSymTypes
            => data("TaggedSymTypes", () => EnumTypes.TypeTags<SymSourceAttribute>());

        public Type[] SymTypes
            => data("SymSources", () => EnumTypes.Tagged<SymSourceAttribute>());

        public ConstLookup<string,Index<Type>> SymGroups
            => data("SymGroups", CalcSymGroups);

        public Index<IApiHost> ApiHosts
            => data("ApiHosts", () => ApiRuntimeCatalog.ApiHosts.Index());

        public Index<DataTypeInfo> DataTypes
            => data("DataTypes", () => Z0.DataTypes.describe(Components));

        public Index<ApiCmdRow> ApiCommands
            => data("ApiCommands", CalcApiCommands);

        public Index<CompilationLiteral> ApiLiterals
            => data(nameof(CompilationLiteral), () => Literals.literals(Components));

        public Index<ApiFlowSpec> DataFlows
            => data("DataFlows", CalcDataFlows);

        public Index<BitMaskInfo> ApiBitMasks
            => Data(nameof(BitMaskInfo), () => BitMask.masks(typeof(BitMaskLiterals)));

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

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil()
            => EmitMsil(ApiHosts);

        public ConstLookup<ApiHostUri,FS.FilePath> EmitMsil(ReadOnlySpan<IApiHost> hosts, DbTargets dst)
        {
            var buffer = text.buffer();
            var k = 0u;
            var emitted = cdict<ApiHostUri,FS.FilePath>();
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var members = HostMembers(host);
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
                var members = HostMembers(host);
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

        public ConstLookup<string,Index<SymInfo>> EmitApiTokens(bool clear = true)
        {
            if(clear)
                ApiTargets(tokens).Clear();

            var lookup = CollectApiTokens();
            var names = lookup.Keys;
            for(var i=0; i<names.Length; i++)
                EmitApiTokens(skip(names,i), lookup[skip(names,i)]);
            return lookup;
        }

        public ConstLookup<string,Index<SymInfo>> CollectApiTokens()
        {
            return Data(nameof(CollectApiTokens), Load);

            ConstLookup<string,Index<SymInfo>> Load()
            {
                var types = SymTypes;
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

        public Index<ClrEnumRecord> EmitEnums(Assembly src, FS.FilePath dst)
        {
            var records = Enums.records(src);
            if(records.Length != 0)
                AppSvc.TableEmit(records, dst);
            return records;
        }


        public Index<ClrEnumRecord> CalcEnumRecords(Assembly src)
            => Data(src.GetSimpleName() + nameof(ClrEnumRecord), () => Enums.records(src));

        public Index<SymInfo> LoadTokens(string name)
        {
            var src = ApiTargets().Table<SymInfo>("tokens" + "." +  name.ToLower());
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

        public Index<SymInfo> EmitTokens(ITokenSet src, FS.FilePath dst)
        {
            var data = Symbols.syminfo(src.Types());
            AppSvc.TableEmit(data, dst);
            return data;
        }

        ConstLookup<string,Index<Type>> CalcSymGroups()
        {

            var types = SymTypes.Index();
            var buffer = dict<string,List<Type>>();
            for(var i=0; i<types.Count; i++)
            {
                ref readonly var type = ref types[i];
                var tag = type.Tag<SymSourceAttribute>().Require();
                var name = tag.SymGroup;
                if(nonempty(name))
                {
                    if(buffer.TryGetValue(name, out var list))
                        list.Add(type);
                    else
                    {
                        list = new();
                        list.Add(type);
                        buffer[name] = list;
                    }
                }
            }

            return buffer.Map(x => (x.Key, x.Value.Index())).ToDictionary();
        }

        Index<SymInfo> EmitTokens<E>(string scope)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, typeof(E).Name);
            AppSvc.TableEmit(src, dst);
            return src;
        }

        Index<SymInfo> EmitTokens<E>(string scope, string prefix)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            AppSvc.TableEmit(src, ApiTargets(tokens).Table<SymInfo>(prefix));
            return src;
        }

        void EmitTokens<K>(ITokenSet<K> src)
            where K : unmanaged
                => EmitTokenSet(src, ApiTargets(tokens).Table<SymInfo>(src.Name));

        void EmitTokenSet<K>(ITokenSet<K> src, FS.FilePath dst)
            where K : unmanaged
                => AppSvc.TableEmit(Symbols.syminfo<K>(src.Types()), dst);

        void EmitApiTokens(string name, Index<SymInfo> src)
            => AppSvc.TableEmit(src, ApiTargets(tokens).Table<SymInfo>(name));
    }
}