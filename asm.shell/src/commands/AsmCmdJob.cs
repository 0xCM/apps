//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    public class AsmCmdJob
    {
        public static AsmCmdJob create(Action worker, Action finished)
            => new AsmCmdJob(worker,finished);

        public Action Worker {get;}

        public Action Finished {get;}

        public AsmCmdJob(Action worker, Action finished)
        {
            Worker = worker;
            Finished = finished;
        }
    }
}