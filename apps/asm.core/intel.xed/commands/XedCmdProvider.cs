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
        IntelXed Xed => Service(Wf.IntelXed);

        XedForms XedForms => Service(Wf.XedForms);

        XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        XedDocs XedDocs => Service(Wf.XedDocs);

        WsProjects Projects => Service(Wf.WsProjects);

        XedPaths XedPaths => Service(Wf.XedPaths);

        XedRules Rules => Service(Wf.XedRules);

        RuleTables CalcRules() => Rules.CalcRuleTables();

        Index<InstPattern> CalcPatterns() => Rules.CalcPatterns();

        Index<PatternOpCode> CalcPatternOpCodes() => XedOpCodes.poc(CalcPatterns());

        RuleCells CalcRuleCells() => Rules.CalcRuleCells(CalcRules());

        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

        BitMaskServices ApiBitMasks => Service(Wf.ApiBitMasks);

        XedDb XedDb => Service(Wf.XedDb);

        AppDb AppDb => Service(Wf.AppDb);

        AppCmdRunner _AppCmdRunner;

        IProjectWs _Project;

        IProjectProvider _ProjectProvider;

        [MethodImpl(Inline)]
        IProjectProvider ProjectProvider()
            => _ProjectProvider;

        public XedCmdProvider With(IProjectProvider provider)
        {
            _ProjectProvider = provider;
            return this;
        }

        IProjectWs Project()
            => ProjectProvider().Project();

        WsContext Context()
            => Projects.Context(ProjectProvider(), Project());

        [MethodImpl(Inline)]
        public IProjectWs Project(ProjectId id)
        {
            _Project = Ws.Project(id);
            return Project();
        }

        void RunCmd(string name, CmdArgs args)
            => Dispatcher.Dispatch(name, args);

        void LoadProject(string name)
            => RunCmd("project", new CmdArg[]{new CmdArg(EmptyString, name)});

        protected override void Initialized()
        {
            _AppCmdRunner = AppCmdRunner.create(Wf);
            _ProjectProvider = _AppCmdRunner;
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