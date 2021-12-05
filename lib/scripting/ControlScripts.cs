//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ControlScripts
    {
        public static FS.FileName BuildRespack => FS.file("build-respack", FS.Cmd);

        public static FS.FileName PackRespack => FS.file("deploy-respack", FS.Cmd);
    }
}