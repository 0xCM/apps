//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Msg;
    using static core;

    public class WfMachine : WfSvc<WfMachine>
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        ApiCode ApiCode => Wf.ApiCode();

        void EmitCode(WorkflowOptions options)
        {
            SortedIndex<ApiCodeBlock> sorted = ApiCode.LoadBlocks();
            var partitioned = ApiCode.hosted(sorted.View);

            if(options.EmitAsmStatements)
                Wf.HostAsmEmitter().EmitHostAsm(partitioned, Db.AsmStatementRoot());

            if(options.EmitAsmRows)
                Wf.AsmRowBuilder().Emit(sorted.View);

            if(options.EmitHexIndex)
                ApiCode.EmitIndex(sorted, Db.IndexFile("api.hex.index"));

            if(options.EmitResBytes)
                Wf.ResPackEmitter().Emit(sorted.View);
        }

        public void Run(WorkflowOptions options)
        {
            var flow = Running();
            var ts = core.timestamp();
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

                if(options.CollectApiDocs)
                    Wf.ApiComments().Collect();

                if(options.ProcessCultFiles)
                    Wf.CultProcessor().RunEtl();

                //Wf.CliEmitter().Emit(options,ts);


            }
            catch(Exception e)
            {
                Error(e);
            }

            Ran(flow);
        }
    }
}