//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    public class CmdEnv
    {
        public CmdVersions Versions;

        public CmdPathRoots RootPaths;

        public CmdEnv(CmdVersions versions, CmdPathRoots roots)
        {
            Versions = versions;
            RootPaths = roots;
        }

        public CmdEnvCalcs Calcs
            => new CmdEnvCalcs(this);
    }
}