//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmModelGen
    {
        const string StatementFactoryDefaultPattern = "public {0} {1}() => default;";

        const string StatementFactoryArgPattern = "public {0} {1}(AsmHexCode encoded) => new {0}(encoded);";

        public void EmitStatementFactories(uint margin, ReadOnlySpan<string> src, ITextBuffer dst)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                EmitStatementFactories(margin, skip(src,i), dst);
        }

        public void EmitStatementFactories(uint margin, string mnemonic, ITextBuffer dst)
        {
            dst.IndentLine(margin, string.Format(StatementFactoryDefaultPattern, captitalize(mnemonic), MonicFactoryName(mnemonic)));
            dst.AppendLine();
            dst.IndentLine(margin, InlineOpAttributeSpec);
            dst.IndentLine(margin, string.Format(StatementFactoryArgPattern, captitalize(mnemonic), MonicFactoryName(mnemonic)));
            dst.AppendLine();
        }
    }
}