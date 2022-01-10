//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial struct XedModels
    {
        public struct SourceEncodings
        {
            public FS.FilePath Source;

            public Index<AsmDocEncoding> Encoded;

            public SourceEncodings(FS.FilePath src, AsmDocEncoding[] encoded)
            {
                Source =src;
                Encoded = encoded;
            }

            public static SourceEncodings Empty => new SourceEncodings(FS.FilePath.Empty, sys.empty<AsmDocEncoding>());
        }
    }
}