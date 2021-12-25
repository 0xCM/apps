//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class WfHost<H> : IWfHost<H>
        where H : WfHost<H>, new()
    {
        [MethodImpl(Inline)]
        public static H create() => new H();

        public virtual WfStepId StepId {get;}

        public Type Type {get;}

        public virtual string Identifier
            => typeof(H).Name;

        [MethodImpl(Inline)]
        protected WfHost()
        {
            Type = typeof(H);
            StepId = Type;
        }

        public virtual void Run(IWfRuntime wf)
        {
            try
            {
                Execute(wf);
            }
            catch(Exception e)
            {
                wf.Error(e);
            }
        }

        protected virtual void Init() { }

        protected abstract void Execute(IWfRuntime shell);

        public virtual string Format()
            => StepId.Format();

        [MethodImpl(Inline)]
        public static implicit operator WfStepId(WfHost<H> src)
            => src.StepId;

        [MethodImpl(Inline)]
        public static implicit operator WfHost(WfHost<H> src)
            => new WfHost(src.StepId, src.Type);
    }
}