//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".symstore")]
        Outcome SymStore(CmdArgs args)
        {
            var store = SymbolStores.symstore<string>(24);
            store.Deposit("abc", out var s1);
            Write(s1);
            store.Deposit("def", out var s2);
            Write(s2);
            store.Deposit("hij", out var s3);
            Write(s3);
            store.Deposit("klm", out var s4);
            Write(s4);
            store.Deposit("nop", out var s5);
            Write(s5);

            var e1 = store.Find(s1);
            var e2 = store.Find(s2);
            var e3 = store.Find(s3);
            var e4 = store.Find(s4);
            var e5 = store.Find(s5);
            Write(e1 + e2 + e3 + e4 + e5);
            return true;
        }
    }
}