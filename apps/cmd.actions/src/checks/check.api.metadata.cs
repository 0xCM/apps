//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/api/metadata")]
        Outcome CheckMetadata(CmdArgs args)
        {
            CheckMetadata(PartId.Lib);
            return true;
        }

        void CheckMetadata(PartId part)
        {
            var tool = Wf.Roslyn();

            if(ApiRuntimeCatalog.FindComponent(part, out var assembly))
            {
                var name = string.Format("z0.{0}.compilation", part.Format());
                var metadata = SourceSymbolic.metaref(assembly);
                var comp = tool.Compilation(name, metadata);
                var symbol = comp.GetAssemblySymbol(metadata);
                var gns = symbol.GlobalNamespace;
                var types = gns.GetTypes();
                iter(types, show);
            }

            void show(CaSymbolModels.TypeSymbol src)
            {
                Write(src);
                var members = src.GetMembers();
                var count = members.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var member = ref skip(members,i);
                    var desc = string.Format("{0}", member.Format());
                    var locations = member.Locations;
                    if(locations.Length != 0)
                    {
                        ref readonly var loc = ref first(locations);
                        if(loc != null)
                        {
                            desc += string.Format("{0} {1}", desc, loc.ToString());
                        }
                    }

                    Write(desc);
                }
            }
        }
    }
}