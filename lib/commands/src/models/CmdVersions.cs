//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct CmdVersions
    {
        /// <summary>
        /// The windows SDK version specifier, e.g. '10.0.20348.0'
        /// </summary>
        public VersionSpec WinSdk;

        /// <summary>
        /// The legacy .Net sdk version specifier, e.g. '4.8'
        /// </summary>
        public VersionSpec NetFx;

        /// <summary>
        /// The msvc version specifier, e.g. '14.29.30133'
        /// </summary>
        public VersionSpec MsvcVer;
    }
}