//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Flags]
    public enum ClrAccessKind : uint
    {
        None = 0,

        Public = 1,

        Private = 2,

        Protected = 4,

        Internal = 8,

        ProtectedInternal = Protected | Internal
    }
}