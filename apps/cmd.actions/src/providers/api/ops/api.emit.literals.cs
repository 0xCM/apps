//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using L = ApiLiterals;

    partial class ApiCmdProvider
    {
        Index<CompilationLiteral> ApiLiterals()
            => Data(nameof(ApiLiterals), () => L.CompilationLiterals(ApiRuntimeCatalog.Components));

        [CmdOp("api/emit/literals")]
        Outcome EmitApiLiterals(CmdArgs args)
        {
            var result = Outcome.Success;
            var literals = ApiLiterals();
            var dst = ProjectDb.Api() + FS.folder("literals");
            TableEmitters.Emit(literals, dst);
            return result;
        }
    }
}