//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct StanfordForm : IRecord<StanfordForm>
    {
        public const string TableId = "asm.forms";

        public uint Seq;

        public AsmOpCodeString OpCode;

        public AsmSigInfo Sig;

        public AsmFormInfo FormExpr;
    }
}