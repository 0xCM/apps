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
        public Outcome EmitHostMsil(string hostid)
        {
            var result = Outcome.Success;
            var svc = Service(ApiRuntimeLoader.catalog);
            result = ApiParsers.host(hostid, out var uri);
            if(result.Ok)
            {
                result = svc.FindHost(uri, out var host);
                if(result.Ok)
                    result = EmitMsil(array(host));
            }

            return result;
        }

        public Outcome EmitMsil()
        {
            var result = Outcome.Success;
            var svc = Service(ApiRuntimeLoader.catalog);
            result = EmitMsil(svc.ApiHosts);
            return result;
        }

        public Outcome EmitMsil(ReadOnlySpan<IApiHost> hosts)
        {
            var result = Outcome.Success;
            var buffer = text.buffer();
            var jit = Wf.ApiJit();
            var pipe = Wf.MsilPipe();
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
            => Ws.Project("db").Subdir("api/msil") + FS.hostfile(uri, FS.Il);


        public void EmitApiTokens()
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components.Storage;
            var types = components.Enums().Tagged<SymSourceAttribute>();
            var groups = dict<string,List<Type>>();
            var individuals = list<Type>();
            foreach(var type in types)
            {
                var tag = type.Tag<SymSourceAttribute>().Require();
                var kind = tag.SymKind;
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

            var scope = "api/tokens";
            var project = Ws.Project("db");
            project.Subdir(scope).Clear();

            foreach(var g in groups.Keys)
                EmitTokenSet(Tokens.set(g, groups[g].Array()), project, scope);

            foreach(var i in individuals)
                EmitTokens(i,scope, project);
        }

        public uint EmitTokens(Type src, string scope, IProjectWs project)
        {
            var name = src.Name;
            if(src.Namespace != "Z0")
            {
                if(src.IsNested)
                    name = src.Namespace.Remove("Z0.") + "." + src.DeclaringType.Name + "." + src.Name;
                else
                    name = src.Namespace.Remove("Z0.") + "." +  src.Name;
            }
            var dst = project.TablePath<SymInfo>(scope, name);
            return TableEmit(Symbols.syminfo(src), SymInfo.RenderWidths, dst);
        }

        public uint EmitTokenSet(ITokenSet src, IProjectWs project, string scope)
            => TableEmit(Symbols.syminfo(src.Types()), SymInfo.RenderWidths, project.TablePath<SymInfo>(scope, src.Name));
    }
}