//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Identifies a projection
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct ProjectionKey
    {
        public SourceKey Source {get;}

        public TargetKey Target {get;}

        public uint Id {get;}

        [MethodImpl(Inline)]
        public ProjectionKey(uint id, SourceKey src, TargetKey dst)
        {
            Id = id;
            Source = src;
            Target = dst;
        }
    }
}