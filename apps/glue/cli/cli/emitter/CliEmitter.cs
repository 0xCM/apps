//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class CliEmitter : AppService<CliEmitter>
    {
        const string CliScope = "api/cli";

        const string BlobScope = CliScope + "/blobs";

        const string MetadumpScope = CliScope + "/metadump";

        const string MsilScope = CliScope + "/msil";

        const string FieldScope = CliScope + "/fields";

        const string MethodScope = CliScope + "/methods";

        const string StringScope = CliScope + "/strings";

        const string ImageHexScope = CliScope + "/image.hex";

        public void EmitMetadaSets(WorkflowOptions options)
        {
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs();

            if(options.EmitFieldMetadata)
            {
                EmitFieldMetadata();
                EmitFieldDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<FieldDefInfo>(FieldScope));
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

            if(options.EmitMetaBlocks)
                EmitMetaBlocks();

            if(options.EmitCliConstants)
                EmitConstants();

            if(options.EmitCliBlobs)
                EmitBlobs();

            if(options.EmitImageContent)
                EmitImageContent();

            if(options.EmitMethodDefs)
                EmitMethodDefs(ApiRuntimeCatalog.Components, ProjectDb.TablePath<MethodDefInfo>(MethodScope));

            if(options.EmitCliRowStats)
                EmitRowStats(ApiRuntimeCatalog.Components, ProjectDb.TablePath<CliRowStats>(CliScope));

        }
    }
}