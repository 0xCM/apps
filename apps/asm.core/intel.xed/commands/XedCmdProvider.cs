//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static core;

    public partial class XedCmdProvider : AppCmdService<XedCmdProvider,CmdShellState>, IProjectConsumer<XedCmdProvider>
    {
        AppCmdRunner _AppCmdRunner;

        IProjectProvider ProjectProvider;

        XedRuntime Xed;

        IntelXed Main => Xed.Main;

        XedDocs XedDocs => Xed.Docs;

        XedPaths XedPaths => Xed.Paths;

        XedRules Rules => Xed.Rules;

        XedDisasmSvc Disasm => Xed.XedDisasm;

        XedDb XedDb => Xed.XedDb;

        AppServices AppServices => Xed.AppServices;

        AppDb AppDb => Xed.AppDb;

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        ApiComments ApiComments => Service(Wf.ApiComments);

        WsProjects Projects => Service(Wf.WsProjects);

        public XedCmdProvider With(XedRuntime runtime)
        {
            Xed = runtime;
            runtime.Start();
            return this;
        }

        public XedCmdProvider With(IProjectProvider provider)
            => throw new NotSupportedException();

        WsContext Context()
            => Projects.Context(ProjectProvider);

        RuleTables CalcRules() => Rules.CalcRuleTables();

        Index<InstPattern> CalcPatterns() => Rules.CalcPatterns();

        Index<PatternOpCode> CalcPatternOpCodes() => XedOpCodes.poc(CalcPatterns());

        RuleCells CalcRuleCells() => Rules.CalcRuleCells(CalcRules());

        void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        void LoadProject(string name)
            => RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, name)});

        protected override void Initialized()
        {
            _AppCmdRunner = AppCmdRunner.create(Wf);
            ProjectProvider = _AppCmdRunner;
            LoadProject("canonical");
        }

        [CmdOp("project")]
        Outcome LoadProject(CmdArgs args)
            => _AppCmdRunner.LoadProject(args);

        protected void TableEmit<T>(T[] src, ReadOnlySpan<byte> widths, FS.FilePath dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(src), widths, dst, fk, encoding);

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, FS.FilePath dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var emitting = EmittingTable<T>(dst);
            using var emitter = dst.AsciEmitter();
            TableEmit(src,widths, emitter,fk,encoding);
            EmittedTable(emitting, src.Length, dst);
        }

        protected void TableEmit<T>(ReadOnlySpan<T> src, ReadOnlySpan<byte> widths, ITextEmitter dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
        {
            var formatter = Tables.formatter<T>(widths,fk:fk);
            var buffer = text.buffer();
            dst.AppendLine(formatter.FormatHeader());

            for(var i=0; i<src.Length; i++)
            {
                ref readonly var row = ref skip(src,i);
                if(i != src.Length - 1)
                    dst.AppendLine(formatter.Format(row));
                else
                    dst.Append(formatter.Format(row));
            }
        }

        protected void FormatRows<T>(T[] src, ReadOnlySpan<byte> widths, ITextEmitter dst, RecordFormatKind fk, TextEncodingKind encoding = TextEncodingKind.Asci)
            where T : struct
                => TableEmit(@readonly(src), widths, dst, fk, encoding);
    }
}