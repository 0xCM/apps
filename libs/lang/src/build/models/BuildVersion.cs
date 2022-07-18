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
    public readonly struct BuildVersion
    {
        public readonly int Major;

        public readonly int Minor;

        public readonly int Patch;

        public readonly string Pre;

        public readonly string Build;

        [MethodImpl(Inline)]
        public BuildVersion(int major, int minor, int patch, string pre = "", string build = "")
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Pre = pre;
            Build = build;
        }
    }
}