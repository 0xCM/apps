//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class CliEmitter : WfSvc<CliEmitter>
    {
        const string CliScope = "api/cli";

        const string BlobScope = CliScope + "/blobs";

        const string MetadumpScope = CliScope + "/metadump";

        const string MsilScope = CliScope + "/msil";

        const string FieldScope = CliScope + "/fields";

        const string MethodScope = CliScope + "/methods";

        const string StringScope = CliScope + "/strings";

        const string ImageHexScope = CliScope + "/image.hex";

        ApiMd ApiMd => Wf.ApiMetadata();

        Cli Cli => Wf.Cli();

        public void Emit(CliEmitOptions options, Timestamp ts)
        {
            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs();

            if(options.EmitFieldMetadata)
            {
                EmitFieldMetadata();
                EmitFieldDefs(ApiMd.Components, ProjectDb.TablePath<FieldDefInfo>(FieldScope));
            }

            if(options.EmitApiMetadump)
                EmitApiMetadump();

            if(options.EmitSectionHeaders)
                EmitSectionHeaders();

            if(options.EmitMsilMetadata)
                EmitMsilMetadata();

            if(options.EmitMsilCode)
                Cli.EmitMsil();

            if(options.EmitCliStrings)
            {
                EmitUserStrings();
                EmitSystemStringInfo();
            }

            if(options.EmitMetadataHex)
                EmitApiHex();

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