//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


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