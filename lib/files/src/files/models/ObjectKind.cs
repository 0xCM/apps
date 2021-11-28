//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public enum ObjectKind : byte
        {
            None = 0,

            Directory,

            File,

            Volume,

            Drive,
        }
    }
}