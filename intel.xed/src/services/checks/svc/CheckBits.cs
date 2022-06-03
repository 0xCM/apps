//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static Markdown;
    using static core;

    partial class XedChecks
    {
        [CmdOp("xed/check/bits")]
        void CheckBitfields()
            => EmitInstBits();

        void EmitInstBits()
        {
            var calcs = InstFieldBits.Calcs;
            Write(calcs.Description().Format());
            Write(calcs.Descriptor());
            Write(calcs.Model().Format());
        }
    }
}