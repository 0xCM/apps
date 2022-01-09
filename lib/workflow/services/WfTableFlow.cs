//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WfTableFlow<T>
        where T : struct
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        public FS.FilePath Target {get;}

        public Count EmissionCount {get;}

        [MethodImpl(Inline)]
        internal WfTableFlow(IWfRuntime wf, FS.FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public WfTableFlow<T> WithCount(Count count)
            => new WfTableFlow<T>(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public WfTableFlow<T> WithToken(ExecToken token)
            => new WfTableFlow<T>(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator WfExecFlow(WfTableFlow<T> src)
            => new WfExecFlow(src.Wf, src.Token);
    }
}