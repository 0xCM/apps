//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmSourceLine
    {
        public static string format(in AsmSourceLine src)
        {
            if(src.Label.IsNonEmpty)
                return src.Label.Format();
            else if(src.Statement.IsNonEmpty)
            {
                if(src.Comment.IsNonEmpty)
                    return string.Format("{0,-46} {1}", src.Statement, src.Comment);
                else
                    return src.Statement.Format();
            }
            else if(src.Comment.IsNonEmpty)
            {
                return src.Comment.Format();
            }
            else
                return EmptyString;
        }

        public uint LineNumber {get;}

        public AsmLineClass Class {get;}

        public AsmBlockLabel Label {get;}

        public AsmExpr Statement {get;}

        public AsmComment Comment {get;}

        [MethodImpl(Inline)]
        public AsmSourceLine(uint number, AsmLineClass @class, AsmBlockLabel label, AsmExpr statement, AsmComment? comment = null)
        {
            LineNumber = number;
            Class = @class;
            Label = label;
            Statement = statement;
            Comment = comment ?? AsmComment.Empty;
        }

        public static AsmSourceLine Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSourceLine(0, 0, AsmBlockLabel.Empty, AsmExpr.Empty);
        }

        public string Format()
        {
            var dst = text.buffer();
            if(Label.IsNonEmpty)
                dst.AppendFormat(" {0,-12}", Label);

            if(Statement.IsNonEmpty)
                dst.AppendFormat(" {0,-60}", Statement);

            if(Comment.IsNonEmpty)
                dst.AppendFormat(" # {0}", Comment.Content);
            return dst.Emit();
        }

        public override string ToString()
            => Format();
    }
}