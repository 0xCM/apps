//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Flags, SymSource("files")]
    public enum FileChangeKind : byte
    {
        None = 0,

        [Symbol("+")]
        Created = 1,

        [Symbol("-")]
        Deleted = 2,

        [Symbol("M")]
        Modified = 4,

        [Symbol("R")]
        Renamed = 8,
    }
}