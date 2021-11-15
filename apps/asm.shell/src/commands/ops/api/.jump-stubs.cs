//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static Root;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".jump-stubs")]
        Outcome FindJumpStubs(CmdArgs args)
        {
            var host = typeof(Prototypes.Calc64);
            var contract = typeof(Prototypes.ICalc64);
            var stubs = JmpStubs.search(host);
            Write(stubs, JmpStub.RenderWidths);

            var imap = Clr.imap(host,contract);
            Write(imap.Format());

            return true;
        }

        [CmdOp(".api-jump-stubs")]
        Outcome ApiJumpStubs(CmdArgs args)
        {
            var stubs = JmpStubs.create(Wf);
            var blocks = stubs.SearchApi();
            return true;
        }

        [CmdOp(".jump-stub-encode")]
        Outcome Poc(CmdArgs args)
        {
            var result = Outcome.Success;
            var stubs = JmpStubs.create(Wf);
            if(stubs.Create<ulong>(0))
            {
                var encoded = stubs.EncodeDispatch(0);
                Write(encoded.FormatHexData());
            }

            return result;
        }
    }
}