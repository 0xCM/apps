//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct WfExecFlow : IDisposable
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal WfExecFlow(IWfRuntime wf, in ExecToken token)
        {
            Wf = wf;
            Token = token;
        }

        public void Dispose()
            => Wf.Ran(this);
    }

    public readonly struct WfExecFlow<T>: IDisposable
    {
        readonly IWfRuntime Wf;

        public T Data {get;}

        public ExecToken Token {get;}

        [MethodImpl(Inline)]
        internal WfExecFlow(IWfRuntime wf, T data, in ExecToken token)
        {
            Wf = wf;
            Data = data;
            Token = token;
        }

        [MethodImpl(Inline)]
        internal WfExecFlow<string> WithMsg(string  msg)
            => new WfExecFlow<string>(Wf, msg, Token);

        public void Dispose()
            => Wf.Ran(this);
    }
}