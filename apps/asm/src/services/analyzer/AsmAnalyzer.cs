//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    public sealed class AsmAnalyzer : AppService<AsmAnalyzer>
    {
        AsmRowBuilder AsmRows;

        AsmCallPipe Calls;

        AsmJmpPipe Jumps;

        AsmAnalyzerSettings Settings;

        public AsmAnalyzer()
        {
        }

        protected override void OnInit()
        {
            AsmRows = Wf.AsmRowBuilder();
            Calls = Wf.AsmCallPipe();
            Jumps = Wf.AsmJmpPipe();
            AsmAnalyzerSettings.@default(out Settings);
        }

        public void Analyze(ReadOnlySpan<AsmRoutine> src, ApiPackArchive dst)
        {
            var blocks = CollectBlocks(src);
            var statements = Wf.AsmStatementPipe();
            var asmcsv = Wf.AsmCsv();
            if(Settings.EmitCalls)
                EmitCalls(src, dst);

            if(Settings.EmitJumps)
                EmitJumps(src, dst);

            if(Settings.EmitStatements)
                asmcsv.EmitStatements(src, dst);

            if(Settings.EmitProcessAsm)
                statements.EmitProcessAsm(src, dst.ProcessAsmPath());

            if(Settings.EmitAsmDetails)
                EmitDetails(blocks, dst);
        }

        void EmitDetails(ReadOnlySpan<ApiCodeBlock> src, ApiPackArchive dst)
        {
            var target = dst.DetailTables();
            target.Clear();
            var rows = AsmRows.Emit(src, target);
        }

        public SortedSpan<ApiCodeBlock> CollectBlocks(ReadOnlySpan<AsmRoutine> src)
        {
            var count = src.Length;
            var flow = Wf.Running(Msg.CollectingBlocks.Format(count));
            var blocks = AsmRoutines.blocks(src);
            Wf.Ran(flow, Msg.CollectedBlocks.Format(count));
            return blocks;
        }

        void EmitCalls(ReadOnlySpan<AsmRoutine> src, ApiPackArchive dst)
            => Calls.EmitRows(src, dst.AsmCallsPath());

        void EmitJumps(ReadOnlySpan<AsmRoutine> src, ApiPackArchive dst)
            => Jumps.EmitRows(src, dst.JmpTarget());
    }
}