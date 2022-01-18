//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Root;

    public readonly struct AsmSyntaxOpList
    {
        public readonly AsmSyntaxRow Row;

        public readonly Index<string> OpClasses;

        public readonly Index<int> Indices;

        public AsmSyntaxOpList(in AsmSyntaxRow row, Index<string> classes, Index<int> indices)
        {
            Row = row;
            OpClasses = classes;
            Indices = indices;
        }

        public string Format()
        {
            var dst = text.buffer();
            var content = Row.SyntaxContent;
            var mnemonic = AsmMnemonic.parse(content, out var mx);
            var optext = EmptyString;
            if(mx > 0)
                optext = text.right(content,mx);

            dst.AppendFormat(string.Format("{0,-8} | {1,-16}", Row.Seq, mnemonic.Format(MnemonicCase.Lowercase)));
            var count = OpClasses.Count;
            for(var j=0; j<count; j++)
                dst.AppendFormat(" | {0,-10} ", OpClasses[j]);

            var classes = dst.Emit();

            if(nonempty(classes))
                dst.AppendFormat("{0,-72} | {1}", classes, content);
            else
                dst.Append(Row.Expr.Format());

            return dst.Emit();
        }
    }
}