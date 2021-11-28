//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public struct CmdLogEntry<T>
    {
        public string Actor;

        public Facets Facets;

        public CmdSpec CmdSpec;

        public CmdFlows<T> Flows;
    }
}