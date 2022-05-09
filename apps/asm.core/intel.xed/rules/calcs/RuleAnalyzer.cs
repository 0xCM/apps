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

        uint Counter;

        public RuleAnalyzer(IAppService app, Action<string,Count,FS.FilePath> emitter)
        {
            App = app;
            Paths = XedPaths.Service;
            FileEmitter = emitter;
            Dst = text.emitter();
            LeftFields = alloc<FieldKind>(24);
            RightFields = alloc<FieldKind>(24);
            FieldUsage = alloc<FieldKind>(24);
            Render = XedFields.render();
            FieldBits = RuleFieldBits.create();
            Counter = 0;
        }

        RuleField Run(LogicKind logic, FieldKind field, RuleOperator op, FieldValue value)
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
            => FieldBits.Define(FieldKind.INVALID, CK.Keyword, src);

        [MethodImpl(Inline)]
        RuleField Run(uint5 src)
            => FieldBits.Define(FieldKind.INVALID, CK.BitLiteral, src);

        [MethodImpl(Inline)]
        RuleField Run(FieldSeg src)
            => FieldBits.Define(src.Field, CK.FieldSeg, src);

        [MethodImpl(Inline)]
        RuleField Run(SegVar src)
            => FieldBits.Define(FieldKind.INVALID, CK.SegVar, src);

        [MethodImpl(Inline)]
        RuleField Run(Nonterminal src)
            => FieldBits.Define(FieldKind.INVALID, CK.NontermCall, src);

        [MethodImpl(Inline)]
        RuleField Run(Hex8 src)
            => FieldBits.Define(FieldKind.INVALID, CK.HexLiteral, src);

        void CollectFieldUsage(in CellKey key)
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

            if(RightFieldCount != 0)
            {
                usage.Append(Chars.Colon);

                for(var i=0; i<RightFieldCount; i++)
                {
                    if(i != 0)
                        usage.Append(Chars.Comma);
                    usage.Append(XedRender.format(RightFields[i]));
                }
            }

            usage.Append(Chars.RParen);

            UsageClear();

            return usage.Emit();
        }

        RuleField Run(in RuleCell src)
        {
            var dst = RuleField.Empty;
            CollectFieldUsage(src.Key);

            if(src.IsOperator)
                dst = FieldBits.Define(FieldKind.INVALID, src.Operator(), RuleCellKind.Operator, src.Operator());
            else if(src.IsCellExpr)
                dst = Run(src.Key, src.Value.ToCellExpr());
            else
            {
                switch(src.Key.CellType.Kind)
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
                    case CK.FieldSeg:
                    case CK.InstSeg:
                        dst = Run(src.Value.ToFieldSeg());
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
            Span<RuleField> fields = stackalloc RuleField[32];
            var count = Demand.lteq(src.CellCount, 32u);

            var bitfield = text.buffer();
            for(var k=0; k<count; k++)
            {
                var field = Run(src[k]);
                bitfield.AppendFormat(" | {0:X8}", (uint)field);
                ref readonly var cell = ref src[k];
                seek(fields,k) = field;
                var fk = FieldBits.FieldKind(field);
                var cv = FieldBits.CellValue(field);
                var type = cell.CellType;
                var ck = type.Kind;
                if(type.IsExpr)
                {
                    switch(ck)
                    {
                        case CK.EqExpr:
                            Counter++;
                        break;
                        case CK.NeqExpr:
                            Counter++;
                        break;
                        case CK.NontermExpr:
                            var rule = (RuleName)cv;
                            Counter++;
                        break;
                    }
                }
                else
                {
                    switch(ck)
                    {
                        case CK.BitLiteral:
                            var bits = (uint5)cv;
                            Counter++;
                        break;
                        case CK.HexVal:
                        case CK.HexLiteral:
                            var hex = (Hex8)cv;
                            Counter++;
                        break;
                        case CK.IntVal:
                            var @int = cv;
                            Counter++;
                        break;
                        case CK.Keyword:
                            var kw = (KeywordKind)cv;
                            Counter++;
                        break;
                        case CK.NontermCall:
                            var rule = (RuleName)cv;
                            Counter++;
                        break;
                        case CK.SegVar:
                            Counter++;
                        break;
                        case CK.FieldSeg:
                        break;
                        case CK.InstSeg:
                            Counter++;
                        break;
                    }
                }
            }

            Dst.AppendFormat("{0:D4} | {1:D3} | {2:D3} | {3,-6} | {4,-32} | {5,-82} | {6,-48} ",
                RowSeq++,
                src.TableIndex,
                src.RowIndex,
                src.TableSig.TableKind,
                src.TableSig.TableName,
                src.Expression,
                UsageEmit());
            Dst.AppendLine(bitfield.Emit());
        }

        void Run(in CellTable src)
        {
            for(var j=0; j<src.RowCount; j++)
                Run(src[j]);
        }

        void Run(CellTables src)
        {
            for(var i=0; i<src.Count; i++)
                Run(src[i]);
        }

        public void Run(RuleCells src)
        {
            Run(src.CellTables);
            FileEmitter(Dst.Emit(), Counter, Paths.RuleTarget("analysis", FS.Csv));
        }
    }
}