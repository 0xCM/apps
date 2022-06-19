//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [CmdReactor]
    public abstract class CmdReactor<C,T> : ICmdReactor<C,T>
        where C : struct, ICmd
    {
        protected IWfRuntime Wf;

        protected IWfDb Db => Wf.Db();

        public static C Spec() => new C();

        public CmdId CmdId => Spec().CmdId;

        protected abstract T Run(C cmd);

        public CmdResult<C,T> Invoke(C cmd)
        {
            try
            {
                return new CmdResult<C,T>(cmd, true, Run(cmd));
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return new CmdResult<C,T>(cmd, e);
            }
        }

        CmdResult ICmdReactor.Invoke(ICmd src)
            => Invoke((C)src);

        public void Init(IWfRuntime wf)
        {
            Wf = wf;
        }
    }
}