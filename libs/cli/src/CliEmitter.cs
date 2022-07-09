//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class CliEmitter : WfSvc<CliEmitter>
    {
        const string CliScope = "api/cli";

        ApiMd ApiMd => Wf.ApiMetadata();

        Cli Cli => Wf.Cli();

        public void Emit(CliEmitOptions options, Timestamp ts)
        {
            var dst = ApiPacks.create(ts);

            if(options.EmitAssemblyRefs)
                EmitAssemblyRefs(dst);

            if(options.EmitFieldMetadata)
            {
                EmitFieldMetadata(dst);
                EmitFieldDefs(ApiMd.Components, dst);
            }

            if(options.EmitApiMetadump)
                EmitApiMetadump(dst);

            if(options.EmitSectionHeaders)
                EmitSectionHeaders();

            if(options.EmitMsilMetadata)
                EmitMsilMetadata(dst);

            if(options.EmitMsilCode)
                Cli.EmitMsil(dst);

            if(options.EmitCliStrings)
            {
                EmitUserStrings(dst);
                EmitSystemStringInfo(dst);
            }

            if(options.EmitMetadataHex)
                EmitApiHex(dst);

            if(options.EmitCliConstants)
                EmitConstants(dst);

            if(options.EmitCliBlobs)
                EmitBlobs(dst);

            if(options.EmitImageContent)
                EmitImageContent(dst);

            if(options.EmitMethodDefs)
                EmitMethodDefs(ApiMd.Components, dst.Metadata().Table<MethodDefInfo>());

            if(options.EmitCliRowStats)
                EmitRowStats(ApiMd.Components, dst.Metadata().Table<CliRowStats>());
        }
    }
}