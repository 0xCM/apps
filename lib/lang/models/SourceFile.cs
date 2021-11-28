//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SourceFile : ISourceCode
    {
        public LangKind LangKind {get;}

        public FileKind FileKind {get;}

        public FS.FilePath Location {get;}

        [MethodImpl(Inline)]
        public SourceFile(LangKind lang, FileKind fk, FS.FilePath loc)
        {
            LangKind = lang;
            FileKind = fk;
            Location = loc;
        }
    }
}