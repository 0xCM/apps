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
            => data("EnumTypes", () => Components.Enums());

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