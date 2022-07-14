//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum SettingType : byte
    {
        None,

        [Symbol("string")]
        String,

        [Symbol("folder")]
        Folder,

        [Symbol("file")]
        File,

        [Symbol("bool")]
        Bool,

        Bit,

        [Symbol("int")]
        Integer,

        [Symbol("asci16")]
        Asci16,

        [Symbol("asci32")]
        Asci32,

        [Symbol("asci64")]
        Asci64,

        Version,

        [Symbol("enum")]
        Enum,

        [Symbol("char")]
        Char,
    }
}