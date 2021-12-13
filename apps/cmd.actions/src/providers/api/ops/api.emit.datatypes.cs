//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ApiCmdProvider
    {
        const string DatatypesEmitCmd = "api/emit/datatypes";

        [CmdOp(DatatypesEmitCmd)]
        protected Outcome EmitApiDataTypes(CmdArgs args)
        {
            var catalog = ApiRuntimeCatalog;
            var types = catalog.ApiDataTypes;
            var count = types.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(types,i);
                Write(string.Format("{0}:{1}", type.Name, type.Syntax));
            }
            return true;
        }
    }
}