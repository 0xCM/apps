//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public partial class IntelInstrinsicsCmd : AppCmdProvider<IntelInstrinsicsCmd>
    {
        IntelIntrinsicSvc IntelIntrinsics => Service(Wf.IntelIntrinsics);

        [CmdOp("intel/int/emit")]
        Outcome ImportIntrinsics(CmdArgs args)
        {
            var intrinsics = IntelIntrinsics.Emit();
            var types = intrinsics.SelectMany(x => x.parameters).Select(x => x.type.Format().Remove("*").Remove("const").Trim()).Distinct().Sort();
            iter(types, t => Write(t));
            return true;
        }
    }
}