//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using S = ContentNames;

    [SymSource]
    public enum ContentKind : ulong
    {
        None = 0,

        [Symbol(S.coff, "Specifies the content of a coff object file")]
        Coff,

        [Symbol(S.pe, "Specifies the content of a portable executable file")]
        Pe,

        [Symbol(S.exe, "Specifies the content of an exebutable pe file")]
        Exe,

        [Symbol(S.dll, "Specifies the content of a dynamic library")]
        Dll,

        [Symbol(S.lib, "Specifies the content of a static library")]
        Lib,

        [Symbol(S.zip, "Specifies the content of a zip archive")]
        Zip,

        [Symbol(S.tar, "Specifies the content of a zip archive")]
        Tar,

        [Symbol(S.hexstring, "Specifies the content sequence of hex characters that define a sequence of bytes")]
        HexString,
    }
}