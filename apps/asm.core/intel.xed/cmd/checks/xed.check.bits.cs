//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/check/bits")]
        void CheckBitfields()
        {
            CheckInstBits();
        }

        void CheckInstBits()
        {
            var f0 = InstFields.define((uint5)0b1101);
            Write(string.Format("{0,-12} | {1,-12} | {2}", f0.Kind, f0.ValueKind, f0.Value<uint5>()));
        }

        void EmitInstBits()
        {
            var calcs = InstFieldBits.Calcs;
            Write(calcs.Description().Format());
            Write(calcs.Descriptor());
            Write(calcs.Model().Format());
        }
    }
}