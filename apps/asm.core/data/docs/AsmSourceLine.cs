//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using Asm;

    public readonly struct AsmSourceLine
    {
        public uint LineNumber {get;}

        public AsmLineClass Class {get;}

        public AsmBlockLabel Block {get;}

        public AsmExpr Statement {get;}

        public AsmComment Comment {get;}

        [MethodImpl(Inline)]
        public AsmSourceLine(uint number, AsmLineClass @class, AsmBlockLabel block, AsmExpr statement, AsmComment? comment = null)
        {
            LineNumber = number;
            Class = @class;
            Block = block;
            Statement = statement;
            Comment = comment ?? AsmComment.Empty;
        }

        public string Format()
        {
            var dst = text.buffer();
            if(Block.IsNonEmpty)
                dst.AppendFormat(" {0,-12}", Block);

            if(Statement.IsNonEmpty)
                dst.AppendFormat(" {0,-60}", Statement);

            if(Comment.IsNonEmpty)
                dst.AppendFormat(" # {0}", Comment.Content);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        public static AsmSourceLine Empty
        {
            [MethodImpl(Inline)]
            get => new AsmSourceLine(0, 0, AsmBlockLabel.Empty, AsmExpr.Empty);
        }
    }
}