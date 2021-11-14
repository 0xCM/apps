//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    using System;

    partial class AsmCmdService
    {
        [CmdOp(".capture")]
        Outcome Capture(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            var part = ApiParsers.part(id);
            if(part != 0)
                Captured(CapturePart(part));
            else
                result = (false, string.Format("{0} is not a part", id));
            return result;
        }

        void Captured(ReadOnlySpan<AsmHostRoutines> src)
        {

        }
    }
}