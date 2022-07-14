//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum SettingType : byte
    {
        None,

        [Symbol("asci16")]
        Asci16,

        [Symbol("asci32")]
        Asci32,

        [Symbol("asci64")]
        Asci64,

        [Symbol("bit")]
        Bit,

        [Symbol("bool")]
        Bool,

        [Symbol("string")]
        String,

        [Symbol("folder")]
        Folder,

        [Symbol("file")]
        File,

        [Symbol("int")]
        Integer,

        [Symbol("version")]
        Version,

        [Symbol("enum")]
        Enum,

        [Symbol("char")]
        Char,
    }
}