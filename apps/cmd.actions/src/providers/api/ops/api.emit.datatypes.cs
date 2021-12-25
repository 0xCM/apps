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
            TableEmit(types, ApiDataType.RenderWidths, ProjectDb.ApiTablePath<ApiDataType>());
            return true;
        }
    }
}