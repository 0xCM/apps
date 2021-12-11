//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        protected Outcome EmitCliMetadataTest(CmdArgs args)
        {
            const string Scope = "api/cli";
            var pipe = Wf.CliEmitter();
            pipe.EmitRowStats(ApiRuntimeCatalog.Components, ProjectDb.TablePath<CliRowStats>(Scope));
            pipe.EmitFieldDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<FieldDefInfo>(Scope));
            pipe.EmitMethodDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<MethodDefInfo>(Scope));
            return true;
        }
    }
}