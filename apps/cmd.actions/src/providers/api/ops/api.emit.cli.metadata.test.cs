//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCmdProvider
    {
        protected Outcome EmitCliMetadataTest(CmdArgs args)
        {
            const string Scope = "api/cli";
            CliEmitter.EmitRowStats(ApiRuntimeCatalog.Components, ProjectDb.TablePath<CliRowStats>(Scope));
            CliEmitter.EmitFieldDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<FieldDefInfo>(Scope));
            CliEmitter.EmitMethodDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<MethodDefInfo>(Scope));
            return true;
        }
    }
}