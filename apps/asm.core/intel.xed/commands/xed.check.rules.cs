//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static Char5;
    using static core;
    using static XedGrids;

    using CK = XedRules.RuleCellKind;

    class RuleAnalyzer
    {
        readonly IAppService App;

        readonly XedPaths Paths;

        readonly Action<string,Count,FS.FilePath> FileEmitter;

        ITextEmitter Dst;

        ushort RowSeq;

        Index<FieldKind> LeftFields;

        byte LeftFieldCount;

        Index<FieldKind> RightFields;

        byte RightFieldCount;

        Index<FieldKind> FieldUsage;

        byte UsageIndex;

        public RuleAnalyzer(IAppService app, Action<string,Count,FS.FilePath> emitter)
        {
            App = app;
            Paths = XedPaths.Service;
            FileEmitter = emitter;
            Dst = text.emitter();
            LeftFields = alloc<FieldKind>(24);
            RightFields = alloc<FieldKind>(24);
            FieldUsage = alloc<FieldKind>(24);
            UsageIndex = 0;
        }

        void Run(LogicKind logic, FieldKind field, RuleOperator op, CellValue value)
        {
            switch(value.CellKind)
            {
                case CK.BitLiteral:
                break;
                case CK.HexLiteral:
                break;
                case CK.SegVar:
                break;
                case CK.SegField:
                break;
                case CK.NontermCall:
                break;
                case CK.Keyword:
                break;
                default:
                    term.warn(value.CellKind);
                break;
            }
        }

        [MethodImpl(Inline)]
        void Run(in CellKey key, in CellExpr src)
            => Run(key.Logic, src.Field, src.Operator, src.Value);

        void Run(RuleKeyword src)
        {

        }

        void Run(uint5 src)
        {

        }

        void Run(SegField src)
        {

        }

        void Run(SegVar src)
        {

        }

        void Run(Nonterminal src)
        {

        }

        void Run(Hex8 src)
        {

        }

        void UsageCollect(in CellKey key)
        {
            ref readonly var field = ref key.Field;
            if(field  != 0)
            {
                FieldUsage[key.Col] = field ;
                switch(key.Logic.Kind)
                {
                    case LogicKind.Antecedant:
                        LeftFields[LeftFieldCount++] = field;

                    break;
                    case LogicKind.Consequent:
                        RightFields[RightFieldCount++] = field;
                    break;
                }
            }
        }

        void UsageClear()
        {
            FieldUsage.Clear();
            LeftFields.Clear();
            LeftFieldCount = 0;
            RightFields.Clear();
            RightFieldCount = 0;
        }

        string UsageEmit()
        {
            var usage = text.buffer();
            usage.Append(Chars.LParen);

            for(var i=0; i<LeftFieldCount; i++)
            {
                if(i != 0)
                    usage.Append(Chars.Comma);
                usage.Append(XedRender.format(LeftFields[i]));
            }

            usage.Append(Chars.Colon);

            for(var i=0; i<RightFieldCount; i++)
            {
                if(i != 0)
                    usage.Append(Chars.Comma);
                usage.Append(XedRender.format(RightFields[i]));
            }

            usage.Append(Chars.RParen);

            UsageClear();

            return usage.Emit();
        }

        void Run(in RuleCell src)
        {
            UsageCollect(src.Key);

            if(src.IsOperator)
                return;

            if(src.IsCellExpr)
                Run(src.Key, src.Value.ToCellExpr());
            else
            {
                switch(src.Key.DataType.Kind)
                {
                    case CK.BitLiteral:
                        Run(src.Value.AsBitLit());
                    break;
                    case CK.Keyword:
                        Run(src.Value.ToKeyword());
                    break;
                    case CK.HexLiteral:
                        Run(src.Value.AsHexLit());
                    break;
                    case CK.NontermCall:
                        Run(src.Value.AsNonterm());
                    break;
                    case CK.SegVar:
                        Run(src.Value.AsSegVar());
                    break;
                    case CK.SegField:
                    case CK.InstSeg:
                        Run(src.Value.ToSegField());
                    break;
                    default:
                        term.error("Unhandled ");
                        break;
                }
            }
        }

        void Run(in CellRow src)
        {
            for(var k=0; k<src.CellCount; k++)
                Run(src[k]);

            Dst.AppendLineFormat("{0:D4} | {1:D3} | {2:D3} | {3,-6} | {4,-32} | {5,-82} | {6} ",
                RowSeq++,
                src.TableIndex,
                src.RowIndex,
                src.TableSig.TableKind,
                src.TableSig.TableName,
                src.Expression,
                UsageEmit());
        }

        void Run(in CellTable src)
        {
            for(var j=0; j<src.RowCount; j++)
            {
                Run(src[j]);
            }
        }

        void Run(Index<CellTable> src)
        {
            for(var i=0; i<src.Count; i++)
            {
                Run(src[i]);
            }

        }
        public void Run(RuleCells src)
        {
            Run(src.Tables);
            FileEmitter(Dst.Emit(), src.TableCount, Paths.RuleTarget("cells.test", FS.Csv));
        }
    }

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var name = "A_GPR_B.DEC";
            var src = CalcRuleCells();
            var analyzer = new RuleAnalyzer(this, (data,count,path) => FileEmit(data, count,path, TextEncodingKind.Asci));
            analyzer.Run(src);
            return true;
        }
    }
}