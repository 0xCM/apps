//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct Sqlite
    {
        static Identifier identifier(Identifier? id, FS.FileName file)
            => id != null ? id.Value.Format() : file.WithoutExtension.Format();
    }
}