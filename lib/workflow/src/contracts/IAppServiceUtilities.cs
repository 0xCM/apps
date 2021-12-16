//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Text;

    using static Root;
    using static core;

    public interface IAppServiceUtilities
    {
        IWfRuntime Wf {get;}

        WfHost Host {get;}
    }
}