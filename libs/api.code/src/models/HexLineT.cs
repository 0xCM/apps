//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct HexLine
    {
        public const string HexPackPattern = "x{0:x}[{1:D5}:{2:D5}]=<{3}>";
    }

    public readonly struct HexLine<T>
        where T : unmanaged
    {
        public readonly HexFileKind Kind;
    }
}