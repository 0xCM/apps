//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static FS.ChangeKind;

    partial struct FS
    {
        [Flags]
        public enum ChangeKind : byte
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

        [Op]
        public static char symbol(ChangeKind change)
            => change switch{
                Created => Chars.Plus,
                Deleted => Chars.Dash,
                Modified => 'M',
                Renamed => 'R',
                _ => Chars.Question
            };
    }
}