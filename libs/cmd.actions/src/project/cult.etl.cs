//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmd
    {
        [CmdOp("cult/etl")]
        void ImportCultData()
            => Wf.CultProcessor().RunEtl();
    }
}