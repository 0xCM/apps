//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Msg;
    using static core;

    public class WfMachine : AppService<WfMachine>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        ApiCode ApiCode => Wf.ApiCode();

        void EmitCode(WorkflowOptions options)
        {
            SortedIndex<ApiCodeBlock> sorted = ApiCode.LoadBlocks();
            var partitioned = ApiCodeBlocks.hosted(sorted.View);

            if(options.EmitAsmStatements)
                Wf.HostAsmEmitter().EmitHostAsm(partitioned, Db.AsmStatementRoot());

            if(options.EmitAsmRows)
                Wf.AsmRowBuilder().Emit(sorted.View);

            if(options.EmitHexIndex)
                ApiCode.EmitIndex(sorted, Db.IndexFile("api.hex.index"));

            // if(options.EmitHexPack)
            //     ApiCode.EmitHexPack(sorted);

            if(options.EmitResBytes)
                Wf.ResPackEmitter().Emit(sorted.View);

        }
        public void Run(WorkflowOptions options)
        {
            var parts = Wf.ApiCatalog.PartIdentities;
            var partCount = parts.Length;
            var flow = Wf.Running(RunningMachine.Format(partCount, parts.Delimit()));
            try
            {
                EmitCode(options);
                var catalogs = Wf.ApiCatalogs();

                if(options.CorrelateMembers)
                    catalogs.Correlate();

                if(options.EmitApiClasses)
                    catalogs.EmitApiClasses();

                if(options.EmitSymbolicLiterals)
                    ApiMd.Emit(ApiMd.SymLits);

                // if(options.EmitApiBitMasks)
                //     ApiMd.Emit(ApiMd.ApiBitMasks);

                if(options.CollectApiDocs)
                    Wf.ApiComments().Collect();

                if(options.ProcessCultFiles)
                    Wf.CultProcessor().RunEtl();

                var cli = Wf.CliEmitter();
                if(options.EmitAssemblyRefs)
                    cli.EmitAssemblyRefs();

                if(options.EmitFieldMetadata)
                    cli.EmitFieldMetadata();

                if(options.EmitApiMetadump)
                    cli.EmitApiMetadump();

                if(options.EmitSectionHeaders)
                    cli.EmitSectionHeaders();

                if(options.EmitMsilMetadata)
                    cli.EmitMsilMetadata();

                if(options.EmitCliStrings)
                {
                    cli.EmitUserStrings();
                    cli.EmitSystemStringInfo();
                }

                if(options.EmitCliConstants)
                    cli.EmitConstants();

                if(options.EmitCliBlobs)
                    cli.EmitBlobs();

                if(options.EmitImageContent)
                    cli.EmitImageContent();

            }
            catch(Exception e)
            {
                Wf.Error(e);
            }

            Wf.Ran(flow, partCount);
        }
    }
}