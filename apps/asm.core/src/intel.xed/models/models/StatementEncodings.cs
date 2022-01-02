//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    partial struct XedModels
    {
        public readonly struct StatementEncodings
        {
            public FS.FilePath Source {get;}

            public Index<AsmStatementEncoding> Encoded {get;}

            public StatementEncodings(FS.FilePath src, AsmStatementEncoding[] encoded)
            {
                Source =src;
                Encoded = encoded;
            }

            public static StatementEncodings Empty => new StatementEncodings(FS.FilePath.Empty, sys.empty<AsmStatementEncoding>());
        }
    }
}