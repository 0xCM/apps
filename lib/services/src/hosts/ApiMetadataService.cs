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
            groups[EmptyString] = new();
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
                    groups[EmptyString].Add(type);
                }
            }

            var scope = "api";
            var project = Ws.Project("db");
            foreach(var g in groups.Keys)
            {
                if(empty(g))
                    EmitTokens(Tokens.set("common", groups[g].Array()), project, scope);
                else
                    EmitTokens(Tokens.set(g, groups[g].Array()), project, scope);
            }
        }

        public uint EmitTokens(ITokenSet src, IProjectWs project, string scope)
            => TableEmit(Symbols.syminfo(src.Types()), SymInfo.RenderWidths, project.TablePath<SymInfo>(scope, src.Name));
    }
}