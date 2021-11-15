//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct AsmParser
    {
        public static Outcome document(FS.FilePath src, out AsmDocument dst)
        {
            var parser = new AsmDocParser();
            return parser.Parse(src, out dst);
        }
    }
}