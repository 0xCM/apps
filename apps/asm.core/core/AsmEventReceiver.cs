//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    public interface IAsmEventReceiver
    {
        void Consolidated(in ObjDumpRow src);

        void Correlated(in AsmEncodingRow enc, in AsmSyntaxRow syn, in AsmInstructionRow inst, in AsmDocCorrelation result);
    }

    public class AsmEventReceiver : IAsmEventReceiver
    {
        public virtual void Consolidated(in ObjDumpRow src)
        {

        }

        public virtual void Correlated(in AsmEncodingRow enc, in AsmSyntaxRow syn, in AsmInstructionRow inst, in AsmDocCorrelation result)
        {

        }
    }
}