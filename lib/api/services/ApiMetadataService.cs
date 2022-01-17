//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static Root;
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
            foreach(var (t,tv) in types.Enumerate())
            {
                if(tv.SymKind == tag)
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
                    var kind = tag.SymKind;
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

        public FS.FilePath EmitApiTokens(string name, ReadOnlySpan<SymInfo> src)
        {
            var dst = ProjectDb.TablePath<SymInfo>("api/tokens", name);
            TableEmit(src, SymInfo.RenderWidths, dst);
            return dst;
        }

        public ConstLookup<string,Index<SymInfo>> EmitApiTokens()
        {
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

        // public void EmitApiTokens()
        // {
        //     var components = ApiCatalog.Components.Storage;
        //     var types = components.Enums().Tagged<SymSourceAttribute>();
        //     var groups = dict<string,List<Type>>();
        //     var individuals = list<Type>();
        //     foreach(var type in types)
        //     {
        //         var tag = type.Tag<SymSourceAttribute>().Require();
        //         var kind = tag.SymKind;
        //         var @base = tag.NumericBase;
        //         if(nonempty(kind))
        //         {
        //             if(groups.TryGetValue(kind, out var list))
        //             {
        //                 list.Add(type);
        //             }
        //             else
        //             {
        //                 list = new();
        //                 list.Add(type);
        //                 groups[kind] = list;
        //             }
        //         }
        //         else
        //         {
        //             individuals.Add(type);
        //         }
        //     }

        //     var scope = "api/tokens";
        //     ProjectDb.Subdir(scope).Clear();

        //     foreach(var g in groups.Keys)
        //         EmitTokenSet(Tokens.set(g, groups[g].Array()), scope);

        //     foreach(var i in individuals)
        //         EmitTokens(i,scope);
        // }

        public Index<SymInfo> EmitTokens<E>(string scope)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, typeof(E).Name);
            TableEmit(src.View, SymInfo.RenderWidths, dst);
            return src;
        }

        public Index<SymInfo> EmitTokens<E>(string scope, string prefix)
            where E : unmanaged, Enum
        {
            var src = Symbols.syminfo<E>();
            var dst = ProjectDb.TablePath<SymInfo>(scope, prefix, typeof(E).Name);
            TableEmit(src.View, SymInfo.RenderWidths, dst);
            return src;
        }

        public uint EmitTokens(Type src, string scope)
        {
            var name = src.Name;
            if(src.Namespace != "Z0")
            {
                if(src.IsNested)
                    name = src.Namespace.Remove("Z0.") + "." + src.DeclaringType.Name + "." + src.Name;
                else
                    name = src.Namespace.Remove("Z0.") + "." +  src.Name;
            }
            var dst = ProjectDb.TablePath<SymInfo>(scope, name);
            return TableEmit(Symbols.syminfo(src).View, SymInfo.RenderWidths, dst);
        }


        public uint EmitTokenSet(ITokenSet src, string scope)
            => TableEmit(Symbols.syminfo(src.Types()).View, SymInfo.RenderWidths, ProjectDb.TablePath<SymInfo>(scope, src.Name));
    }
}