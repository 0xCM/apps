//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class CliEmitter : AppService<CliEmitter>
    {
        public void EmitMetadaSets(WorkflowOptions options)
        {
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs();

            if(options.EmitFieldMetadata)
            {
                EmitFieldMetadata();
                EmitFieldDefs(Wf.ApiCatalog.Components, Paths.IndexTable<FieldDefInfo>());
            }

            if(options.EmitApiMetadump)
                EmitApiMetadump();

            if(options.EmitSectionHeaders)
                EmitSectionHeaders();

            if(options.EmitMsilMetadata)
                EmitMsilMetadata();

            if(options.EmitCliStrings)
            {
                EmitUserStrings();
                EmitSystemStringInfo();
            }

            if(options.EmitCliConstants)
                EmitConstants();

            if(options.EmitCliBlobs)
                EmitBlobs();

            if(options.EmitImageContent)
                EmitImageContent();

            if(options.EmitMethodDefs)
                EmitMethodDefs(Wf.ApiCatalog.Components, Paths.IndexTable<MethodDefInfo>());

            if(options.EmitCliRowStats)
                EmitRowStats(Wf.ApiCatalog.Components, Paths.IndexTable<CliRowStats>());
        }
    }
}