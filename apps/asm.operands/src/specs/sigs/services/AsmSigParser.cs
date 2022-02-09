// //-----------------------------------------------------------------------------
// // Copyright   :  (c) Chris Moore, 2020
// // License     :  MIT
// //-----------------------------------------------------------------------------
// namespace Z0.Asm
// {
//     using static core;

//     public class AsmSigParser
//     {
//         AsmSigDatasets Datasets;

//         public AsmSigParser()
//         {
//             Datasets = AsmSigDatasets.load();
//         }

//         public static AsmMnemonic partition(string src, out Index<AsmSigOpExpr> dst)
//         {
//             var input = text.trim(text.despace(src));
//             var i= text.index(input, Chars.Space);
//             if(i > 0)
//                 dst = map(text.trim(text.split(text.right(input,i), Chars.Comma)), x => new AsmSigOpExpr(x));
//             else
//                 dst = sys.empty<AsmSigOpExpr>();

//             return AsmMnemonic.parse(input, out _);
//         }


//         static MsgPattern<string,AsmSigOpExpr> OpParseError => "Unable to parse {0} from '{1}'";

//         static bool operand(AsmSigOpExpr src, out AsmSigOp dst)
//         {
//             if(AsmSigs.modifier(src, out var op, out var mod))
//             {
//                 if(_Datasets.TokensByExpression.Find(op, out dst))
//                 {
//                     dst = dst.WithModifier(mod);
//                     return true;
//                 }
//                 else
//                     return false;
//             }
//             else
//                 return _Datasets.TokensByExpression.Find(src.Text, out dst);
//         }

//         public bool Token(string src, out AsmSigOp dst)
//             => Datasets.TokensByExpression.Find(src, out dst);

//         static AsmSigParser()
//         {
//             _Datasets = AsmSigDatasets.load();
//         }

//         static AsmSigDatasets _Datasets;
//     }
// }