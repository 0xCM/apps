//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a symver-aligned build/publication version specifier
    /// </summary>
    public readonly struct BuildVersion
    {
        public int Major {get;}

        public int Minor {get;}

        public int Patch {get;}

        public string Pre {get;}

        public string Build {get;}

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