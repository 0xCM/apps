// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0
// {
//     using static XedRules;
//     using static XedFields;
//     using static core;

//     using CK = XedRules.RuleCellKind;

//     class RuleAnalyzer
//     {
//         readonly IAppService App;

//         readonly XedPaths Paths;

//         readonly Action<string,Count,FS.FilePath> FileEmitter;

//         ITextEmitter Dst;

//         ushort RowSeq;

//         Index<FieldKind> LeftFields;

//         byte LeftFieldCount;

//         Index<FieldKind> RightFields;

//         byte RightFieldCount;

//         Index<FieldKind> FieldUsage;

//         FieldRender Render;

//         RuleBits FieldBits;

//         uint Counter;

//         public RuleAnalyzer(IAppService app, Action<string,Count,FS.FilePath> emitter)
//         {
//             App = app;
//             Paths = XedPaths.Service;
//             FileEmitter = emitter;
//             Dst = text.emitter();
//             LeftFields = alloc<FieldKind>(24);
//             RightFields = alloc<FieldKind>(24);
//             FieldUsage = alloc<FieldKind>(24);
//             Render = XedFields.render();
//             FieldBits = RuleBits.create();
//             Counter = 0;
//         }

//         void CollectFieldUsage(in CellKey key)
//         {
//             ref readonly var field = ref key.Field;
//             if(field  != 0)
//             {
//                 FieldUsage[key.Col] = field ;
//                 switch(key.Logic.Kind)
//                 {
//                     case LogicKind.Antecedant:
//                         LeftFields[LeftFieldCount++] = field;

//                     break;
//                     case LogicKind.Consequent:
//                         RightFields[RightFieldCount++] = field;
//                     break;
//                 }
//             }
//         }

//         void UsageClear()
//         {
//             FieldUsage.Clear();
//             LeftFields.Clear();
//             LeftFieldCount = 0;
//             RightFields.Clear();
//             RightFieldCount = 0;
//         }

//         string UsageEmit()
//         {
//             var usage = text.buffer();
//             usage.Append(Chars.LParen);

//             for(var i=0; i<LeftFieldCount; i++)
//             {
//                 if(i != 0)
//                     usage.Append(Chars.Comma);
//                 usage.Append(XedRender.format(LeftFields[i]));
//             }

//             if(RightFieldCount != 0)
//             {
//                 usage.Append(Chars.Colon);

//                 for(var i=0; i<RightFieldCount; i++)
//                 {
//                     if(i != 0)
//                         usage.Append(Chars.Comma);
//                     usage.Append(XedRender.format(RightFields[i]));
//                 }
//             }

//             usage.Append(Chars.RParen);

//             UsageClear();

//             return usage.Emit();
//         }

//         RuleFieldBits Run(in RuleCell src)
//         {
//             var dst = RuleFieldBits.Empty;
//             CollectFieldUsage(src.Key);
//             dst = FieldBits.Bits(src);
//             return dst;
//         }

//         void Run(in CellRow src)
//         {
//             Span<RuleFieldBits> fields = stackalloc RuleFieldBits[32];
//             var count = Demand.lteq(src.CellCount, 32u);
//             var bitfield = text.buffer();
//             for(var k=0; k<count; k++)
//             {
//                 var field = Run(src[k]);
//                 bitfield.AppendFormat(" | {0:X8}", (uint)field);
//                 ref readonly var cell = ref src[k];
//                 seek(fields,k) = field;
//                 var fk = FieldBits.FieldKind(field);
//                 var cv = FieldBits.CellValue(field);
//                 var type = cell.CellType;
//                 var ck = type.Kind;
//                 if(type.IsExpr)
//                 {
//                     switch(ck)
//                     {
//                         case CK.EqExpr:
//                             Counter++;
//                         break;
//                         case CK.NeqExpr:
//                             Counter++;
//                         break;
//                         case CK.NtExpr:
//                             var rule = (RuleName)cv;
//                             Counter++;
//                         break;
//                     }
//                 }
//                 else
//                 {
//                     switch(ck)
//                     {
//                         case CK.BitLit:
//                             var bits = (uint5)cv;
//                             Counter++;
//                         break;
//                         case CK.HexVal:
//                         case CK.HexLit:
//                             var hex = (Hex8)cv;
//                             Counter++;
//                         break;
//                         case CK.IntVal:
//                             var @int = cv;
//                             Counter++;
//                         break;
//                         case CK.Keyword:
//                             var kw = (KeywordKind)cv;
//                             Counter++;
//                         break;
//                         case CK.NtCall:
//                             var rule = (RuleName)cv;
//                             Counter++;
//                         break;
//                         case CK.SegVar:
//                             Counter++;
//                         break;
//                         case CK.FieldSeg:
//                         break;
//                         case CK.InstSeg:
//                             Counter++;
//                         break;
//                     }
//                 }
//             }

//             Dst.AppendFormat("{0:D4} | {1:D3} | {2:D3} | {3,-6} | {4,-32} | {5,-82} | {6,-48} ",
//                 RowSeq++,
//                 src.TableIndex,
//                 src.RowIndex,
//                 src.TableSig.TableKind,
//                 src.TableSig.TableName,
//                 src.Expression,
//                 UsageEmit());
//             Dst.AppendLine(bitfield.Emit());
//         }

//         void Run(in CellTable src)
//         {
//             for(var j=0; j<src.RowCount; j++)
//                 Run(src[j]);
//         }

//         public void Run(CellTables src)
//         {
//             for(var i=0; i<src.Count; i++)
//                 Run(src[i]);

//             FileEmitter(Dst.Emit(), Counter, Paths.RuleTarget("analysis", FS.Csv));
//         }
//     }
// }