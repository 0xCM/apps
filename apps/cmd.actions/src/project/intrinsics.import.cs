//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("intrinsics/import")]
        Outcome ImportIntrinsics(CmdArgs args)
        {
            var intrinsics = IntelIntrinsics.Emit();
            var types = intrinsics.SelectMany(x => x.parameters).Select(x => x.type.Format().Remove("*").Remove("const").Trim()).Distinct().Sort();
            iter(types, t => Write(t));

            return true;
        }

        [CmdOp("cult/import")]
        Outcome ImportCultData(CmdArgs args)
            => Wf.CultProcessor().Process();
    }
}