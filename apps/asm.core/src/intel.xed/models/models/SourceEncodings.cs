//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public readonly struct SourceEncodings
        {
            public FS.FilePath Source {get;}

            public Index<AsmStatementEncoding> Encoded {get;}

            public SourceEncodings(FS.FilePath src, AsmStatementEncoding[] encoded)
            {
                Source =src;
                Encoded = encoded;
            }

            public static SourceEncodings Empty => new SourceEncodings(FS.FilePath.Empty, sys.empty<AsmStatementEncoding>());
        }
    }
}