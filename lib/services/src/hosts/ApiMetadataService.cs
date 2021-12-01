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