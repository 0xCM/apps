//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedFields;
    using static core;

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

        FieldRender Render;

        RuleFieldBits FieldBits;

        public RuleAnalyzer(IAppService app, Action<string,Count,FS.FilePath> emitter)
        {
            App = app;
            Paths = XedPaths.Service;
            FileEmitter = emitter;
            Dst = text.emitter();
            LeftFields = alloc<FieldKind>(24);
            RightFields = alloc<FieldKind>(24);
            FieldUsage = alloc<FieldKind>(24);
            Render = FieldRender.create();
            FieldBits = RuleFieldBits.create();
        }

        RuleField Run(LogicKind logic, FieldKind field, RuleOperator op, CellValue value)
        {
            var dst = RuleField.Empty;
            switch(value.CellKind)
            {
                case CK.BitVal:
                    dst = FieldBits.Define(field, op, value.CellKind, (bit)value.Data);
                break;
                case CK.IntVal:
                    dst = FieldBits.Define(field, op, value.CellKind, (byte)value.Data);
                break;
                case CK.HexVal:
                    dst = FieldBits.Define(field, op, value.CellKind, (Hex8)value.Data);
                break;
                case CK.BitLiteral:
                    dst = FieldBits.Define(field, op, value.CellKind, (uint5)value.Data);
                break;
                case CK.HexLiteral:
                    dst = FieldBits.Define(field, op, value.CellKind, (Hex8)value.Data);
                break;
                case CK.NontermCall:
                    dst = FieldBits.Define(field, op, value.CellKind, (Nonterminal)value.Data);
                break;
                case CK.Keyword:
                    dst = FieldBits.Define(field, op, value.CellKind, (KeywordKind)value.Data);
                break;
                case CK.EqExpr:
                    dst = FieldBits.Define(field, op, value.CellKind, (ushort)value.Data);
                break;
                case CK.NeqExpr:
                    dst = FieldBits.Define(field, op, value.CellKind, (ushort)value.Data);
                break;
                case CK.NontermExpr:
                    dst = FieldBits.Define(field, op, value.CellKind, (Nonterminal)value.Data);
                break;
                default:
                    term.warn(value.CellKind);
                break;
            }
            return dst;
        }

        [MethodImpl(Inline)]
        RuleField Run(in CellKey key, in CellExpr src)
            => Run(key.Logic, src.Field, src.Operator, src.Value);

        [MethodImpl(Inline)]
        RuleField Run(RuleKeyword src)
            => FieldBits.Define(FieldKind.INVALID, RuleCellKind.Keyword, src);

        [MethodImpl(Inline)]
        RuleField Run(uint5 src)
            => FieldBits.Define(FieldKind.INVALID, RuleCellKind.BitLiteral, src);

        [MethodImpl(Inline)]
        RuleField Run(SegField src)
            => RuleField.Empty;

        [MethodImpl(Inline)]
        RuleField Run(SegVar src)
            => RuleField.Empty;

        [MethodImpl(Inline)]
        RuleField Run(Nonterminal src)
            => FieldBits.Define(FieldKind.INVALID, RuleCellKind.NontermCall, src);

        [MethodImpl(Inline)]
        RuleField Run(Hex8 src)
            => FieldBits.Define(FieldKind.INVALID, RuleCellKind.HexLiteral, src);

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

        LogicValue Value(in RuleCell src)
        {
            var dst = LogicValue.Empty;
            if(src.IsOperator)
            {

            }

            return dst;
        }

        RuleField Run(in RuleCell src)
        {
            var dst = RuleField.Empty;
            UsageCollect(src.Key);

            if(src.IsOperator)
                dst = FieldBits.Define(FieldKind.INVALID, src.Operator(), RuleCellKind.Operator, src.Operator());
            else if(src.IsCellExpr)
                dst = Run(src.Key, src.Value.ToCellExpr());
            else
            {
                switch(src.Key.DataType.Kind)
                {
                    case CK.BitLiteral:
                        dst = Run(src.Value.AsBitLit());
                    break;
                    case CK.Keyword:
                        dst = Run(src.Value.ToKeyword());
                    break;
                    case CK.HexLiteral:
                        dst = Run(src.Value.AsHexLit());
                    break;
                    case CK.NontermCall:
                        dst = Run(src.Value.AsNonterm());
                    break;
                    case CK.SegVar:
                        dst = Run(src.Value.AsSegVar());
                    break;
                    case CK.SegField:
                    case CK.InstSeg:
                        dst = Run(src.Value.ToSegField());
                    break;
                    default:
                        term.error("Unhandled ");
                        break;
                }
            }
            return dst;
        }

        void Run(in CellRow src)
        {
            for(var k=0; k<src.CellCount; k++)
            {
                var field = Run(src[k]);
                term.print(FieldBits.Format(field, Render));
            }

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
}