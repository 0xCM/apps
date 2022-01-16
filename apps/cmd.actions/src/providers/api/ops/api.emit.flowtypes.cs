//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    using System;

    partial class ApiCmdProvider
    {
        [CmdOp("api/emit/flowtypes")]
        Outcome EmitFlowTypes(CmdArgs args)
        {
            var types = ProjectFlows.FlowTypes();
            iter(types, t => Write(t.Format()));
            return true;
        }

        [CmdOp("api/emit/cmdtypes")]
        Outcome EmitCmdTypes(CmdArgs args)
        {
            var types = Cmd.types(ApiRuntimeCatalog.Components);
            foreach(var type in types)
            {
                var name = type.Tag<CmdAttribute>().Require().Name;
                var cmdargs = type.DeclaredInstanceFields();
                var instance = Activator.CreateInstance(type);
                var values = ClrFields.values(instance);
                Write(string.Format("{0}:{1}", name, type.Name));
                Write(RP.PageBreak80);
                foreach(var arg in cmdargs)
                {
                    var expr = arg.Tag<CmdArgAttribute>().MapValueOrDefault(x => x.Expression, EmptyString);
                    Write(string.Format("{0,-32} | {1,-24} | {2,-32} | {3}", arg.Name, arg.FieldType.Name, expr, values[arg.Name].Value ?? RP.Null));
                }
                Write(EmptyString);
            }

            return true;
        }
    }
}