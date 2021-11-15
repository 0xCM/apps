//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".respack-members")]
        Outcome RespackMembers(CmdArgs args)
        {
            var provider = Wf.ApiResProvider();
            var accessors = provider.ResPackAccessors();
            var count = accessors.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var accessor = ref skip(accessors,i);
                var seg = SpanRes.capture(accessor);
                var def = CapturedAccessor.define(i, accessor, seg);
                Write(def);
            }
            return true;
        }
    }
}