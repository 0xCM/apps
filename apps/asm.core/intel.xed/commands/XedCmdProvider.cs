//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static core;

    public partial class XedCmdProvider : AppCmdService<XedCmdProvider,CmdShellState>, IProjectConsumer<XedCmdProvider>
    {
        IntelXed Xed => Service(Wf.IntelXed);

        XedDisasmSvc Disasm => Service(Wf.XedDisasm);

        XedDocs XedDocs => Service(Wf.XedDocs);

        WsProjects Projects => Service(Wf.WsProjects);

        XedPaths XedPaths => Service(Wf.XedPaths);

        XedDisasmSvc XedDisasmSvc => Service(Wf.XedDisasm);

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

        XedRules Rules => Service(Wf.XedRules);

        RuleTables CalcRules() => Rules.CalcRules();

        Index<InstPattern> CalcPatterns() => Rules.CalcPatterns();

        string CaclTableMetrics(RuleSig sig, Index<KeyedCell> src)
        {
            var view = src.View;
            var tid = src.IsNonEmpty ? src.First.Key.Table : Hex12.MaxValue;
            var rix = z16;
            var rowExpr = text.emitter();
            var dst = text.emitter();
            var count = src.Count;
            dst.AppendLine(string.Format("{0:D3} {1,-32} {2}", tid,  sig.Format(), XedPaths.CheckedTableDef(sig)));
            dst.AppendLine(RP.PageBreak120);
            dst.AppendLine();
            var emit = false;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref src[i];
                ref readonly var key = ref cell.Key;
                emit = key.Row != rix;
                if(key.Row != rix)
                    rix = key.Row;

                if(emit)
                {
                    dst.AppendLine(rowExpr.Emit());
                    dst.AppendLine();

                    dst.AppendLineFormat("{0:D3} {1:D3}", tid, rix);
                    dst.AppendLine(RP.PageBreak60);
                }

                var descriptor = string.Format("{0:D3} {1:D3} {2:D3} {3}", tid, rix, key.Col, key.FormatSemantic());
                dst.AppendLineFormat("{0} {1,-12} | {2}", descriptor, XedRender.format(cell.Field), cell);
                rowExpr.Append(cell.Format());
                rowExpr.Append(Chars.Space);


                if(i == count - 1 )
                    dst.AppendLine(rowExpr.Emit());

            }
            return dst.Emit();
        }

        void CalcRuleMetrics(KeyedCells src)
        {
            var sigs = src.Keys;
            var dst = text.emitter();
            for(var i=0; i<sigs.Length; i++)
            {
                ref readonly var sig = ref skip(sigs,i);
                var table = src[sig];
                dst.AppendLine(CaclTableMetrics(sig,table));
            }

            FileEmit(dst.Emit(), sigs.Length, XedPaths.RuleTargets() + FS.file("xed.rules.metrics", FS.Txt));
        }


        [Record(TableName)]
        public struct InstLayoutRecord : IComparable<InstLayoutRecord>
        {
            public const string TableName = "xed.inst.layouts";

            public const byte FieldCount = 7;

            public ushort PatternId;

            public InstClass Instruction;

            public XedOpCode OpCode;

            public InstSeg Seg0;

            public InstSeg Seg1;

            public InstSeg Seg2;

            public InstSeg Seg3;


            public int CompareTo(InstLayoutRecord src)
                => PatternId.CompareTo(src.PatternId);

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,18,26,12,12,12,12};
        }

        ConstLookup<InstPattern,Index<LayoutCell>> CalcLayoutCells()
        {
            var dst = dict<InstPattern,Index<LayoutCell>>();
            var patterns = Xed.Rules.CalcInstPatterns();
            for(var i=0; i<patterns.Count; i++)
            {
                ref readonly var pattern = ref patterns[i];
                ref readonly var fields = ref pattern.Fields;
                dst[pattern] = pattern.Layout.Map(x => new LayoutCell(x));
            }

            return dst;
        }
    }
}