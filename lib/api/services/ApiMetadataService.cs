//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class ApiMetadataService : AppService<ApiMetadataService>
    {
        ApiJit ApiJit => Service(Wf.ApiJit);

        MsilPipe MsilPipe => Service(Wf.MsilPipe);

        public Outcome EmitHostMsil(string hostid)
        {
            var result = Outcome.Success;
            result = ApiParsers.host(hostid, out var uri);
            if(result.Ok)
            {
                result = ApiRuntimeCatalog.FindHost(uri, out var host);
                if(result.Ok)
                    result = EmitMsil(array(host));
            }

            return result;
        }

        public Outcome EmitMsil()
        {
            var result = Outcome.Success;
            result = EmitMsil(ApiRuntimeCatalog.ApiHosts);
            return result;
        }

        public Outcome EmitMsil(ReadOnlySpan<IApiHost> hosts)
        {
            var result = Outcome.Success;
            var buffer = text.buffer();
            var jit = ApiJit;
            var pipe = MsilPipe;
            var counter = 0u;
            for(var i=0; i<hosts.Length; i++)
            {
                ref readonly var host = ref skip(hosts, i);
                var members = jit.JitHost(host).View;
                var count = members.Length;
                if(count == 0)
                    continue;

                var dst = MsilOutPath(host.HostUri);
                var flow = EmittingFile(dst);

                for(var j=0; j<count; j++)
                {
                    ref readonly var member = ref members[j];
                    ref readonly var msil = ref member.Msil;
                    pipe.RenderCode(msil, buffer);
                    counter++;
                }

                using var writer = dst.UnicodeWriter();
                writer.Write(buffer.Emit());
                EmittedFile(flow, count);
            }

            return result;
        }

        FS.FilePath MsilOutPath(ApiHostUri uri)
            => ProjectDb.Subdir("api/msil") + FS.hostfile(uri, FS.Il);

        public void EmitApiTokens(string tag, string scope)
        {
            var types = ApiRuntimeCatalog.Components.Storage.Enums().TypeTags<SymSourceAttribute>();
            var selected = list<Type>();
            foreach(var (t,tv) in types.Storage)
            {
                if(tv.SymGroup == tag)
                    selected.Add(t);
            }

            EmitTokenSet(Tokens.set(tag, selected.Array()), scope);
        }

        public ConstLookup<string,Index<SymInfo>> CollectApiTokens()
        {
            return Data(nameof(CollectApiTokens), Load);

            ConstLookup<string,Index<SymInfo>> Load()
            {
                var dst = dict<string,Index<SymInfo>>();
                var components = ApiRuntimeCatalog.Components.Storage;
                var types = components.Enums().Tagged<SymSourceAttribute>();
                var groups = dict<string,List<Type>>();
                var individuals = list<Type>();
                foreach(var type in types)
                {
                    var tag = type.Tag<SymSourceAttribute>().Require();
                    var kind = tag.SymGroup;
                    var @base = tag.NumericBase;
                    if(nonempty(kind))
                    {
                        if(groups.TryGetValue(kind, out var list))
                        {
                            list.Add(type);
                        }
                        else
                        {
                            list = new();
                            list.Add(type);
                            groups[kind] = list;
                        }
                    }
                    else
                    {
                        individuals.Add(type);
                    }
                }

                foreach(var g in groups.Keys)
                    dst[g] = Symbols.syminfo(groups[g].ViewDeposited());

                foreach(var i in individuals)
                    dst[i.Name] = Symbols.syminfo(i);

                return dst;
            }
        }

        const string ApiTokenScope = "api/tokens";

        public FS.FilePath EmitApiTokens(string name, ReadOnlySpan<SymInfo> src)
        {
            var dst = ProjectDb.TablePath<SymInfo>(ApiTokenScope, name);
            WfEmit.TableEmit(src, dst);
            return dst;
        }

        public ConstLookup<string,Index<SymInfo>> EmitApiTokens(bool clear = true)
        {
            ProjectDb.Subdir(ApiTokenScope).Clear();

            var tokens = CollectApiTokens();
            var names = tokens.Keys;
            var count = names.Length;
            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                EmitApiTokens(name,tokens[name]);
            }

            return tokens;
        }

        public Index<SymInfo> EmitTokens<E>(string scope)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, typeof(E).Name);
            WfEmit.TableEmit(src.View, dst);
            return src;
        }

        public Index<SymInfo> EmitTokens<E>(string scope, string prefix)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, prefix, typeof(E).Name);
            WfEmit.TableEmit(src.View, dst);
            return src;
        }

        public ExecToken EmitTokens(Type src, string scope)
        {
            var name = src.Name;
            if(src.Namespace != "Z0")
            {
                if(src.IsNested)
                    name = src.Namespace.Remove("Z0.") + "." + src.DeclaringType.Name + "." + src.Name;
                else
                    name = src.Namespace.Remove("Z0.") + "." +  src.Name;
            }
            return WfEmit.TableEmit(Symbols.syminfo(src).View, ProjectDb.TablePath<SymInfo>(scope, name));
        }

        public ExecToken EmitTokenSet(ITokenSet src, string scope)
            => EmitTokenSet(src, ProjectDb.TablePath<SymInfo>(scope, src.Name));

        public ExecToken EmitTokenSet(ITokenSet src, FS.FilePath dst)
            => WfEmit.TableEmit(Symbols.syminfo(src.Types()).View, dst);

        public ExecToken EmitTokenSet<K>(ITokenSet<K> src, string scope)
            where K : unmanaged
                => EmitTokenSet(src, ProjectDb.TablePath<SymInfo>(scope, src.Name));

        public ExecToken EmitTokenSet<K>(ITokenSet<K> src, FS.FilePath dst)
            where K : unmanaged
                => WfEmit.TableEmit(Symbols.syminfo<K>(src.Types()).View, dst);
    }
}