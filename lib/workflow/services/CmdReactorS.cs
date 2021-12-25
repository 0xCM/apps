//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [CmdReactor]
    public abstract class CmdReactor<S> : ICmdReactor<S>
        where S : struct, ICmd<S>
    {
        protected IWfRuntime Wf;

        protected IWfDb Db => Wf.Db();

        public static S Spec() => new S();

        public CmdId CmdId => Spec().CmdId;

        protected abstract CmdResult Run(S cmd);

        public CmdResult<S> Invoke(S cmd)
        {
            try
            {
                var flow = Wf.Running(cmd);
                var ran = Run(cmd);
                var result = new CmdResult<S>(cmd, ran.Succeeded, ran.Message);
                Wf.Ran(flow, result);
                return result;
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return new CmdResult<S>(cmd, e);
            }
        }

        CmdResult ICmdReactor.Invoke(ICmd src)
            => Invoke((S)src);

        public void Init(IWfRuntime wf)
        {
            Wf = wf;
        }
    }
}