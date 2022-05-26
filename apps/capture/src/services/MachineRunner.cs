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
        public void Run(WorkflowOptions options)
        {
            var parts = Wf.ApiCatalog.PartIdentities;
            var partCount = parts.Length;
            var flow = Wf.Running(RunningMachine.Format(partCount, parts.Delimit()));
            try
            {
                var blocks = Wf.ApiHex().ReadBlocks().Storage;
                var partitioned = ApiCodeBlocks.hosted(@readonly(blocks));
                var sorted = blocks.ToSortedIndex();

                if(options.EmitAsmStatements)
                    Wf.HostAsmEmitter().EmitHostAsm(partitioned, Db.AsmStatementRoot());

                if(options.EmitAsmRows)
                    Wf.AsmRowBuilder().Emit(blocks);

                if(options.EmitHexIndex)
                    Wf.ApiHex().EmitIndex(sorted, Db.IndexFile("api.hex.index"));

                if(options.EmitHexPack)
                    Wf.ApiHexPacks().Emit(sorted);

                if(options.EmitResBytes)
                    Wf.ResPackEmitter().Emit(blocks);

                var catalogs = Wf.ApiCatalogs();

                if(options.CorrelateMembers)
                    catalogs.Correlate();

                if(options.EmitApiClasses)
                    catalogs.EmitApiClasses();

                if(options.EmitSymbolicLiterals)
                    Wf.Heaps().EmitSymLits();

                if(options.EmitApiBitMasks)
                    Wf.ApiBitMasks().Emit();

                if(options.CollectApiDocs)
                    Wf.ApiComments().Collect();

                if(options.ProcessCultFiles)
                    Wf.CultProcessor().Process();

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