//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a symver-aligned build/publication version specifier
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly record struct BuildVersion
    {
        public readonly int Major;

        public readonly int Minor;

        public readonly int Patch;

        [MethodImpl(Inline)]
        public BuildVersion(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        public string Format()
            => $"{Major}.{Minor}.{Patch}";

        public override string ToString()
            => Format();
    }
}