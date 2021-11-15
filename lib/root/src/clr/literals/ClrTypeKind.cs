//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Defines classifiers that correspond to the basic CLR types
    /// </summary>
    [Flags]
    public enum ClrTypeKind : uint
    {
        None = 0,

        Class = ClrArtifactKind.Class,

        Struct = ClrArtifactKind.Struct,

        Delegate = ClrArtifactKind.Delegate,

        Enum = ClrArtifactKind.Enum,

        Interface = ClrArtifactKind.Interface
    }
}
