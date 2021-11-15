//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct WfFileFlow
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        public FS.FilePath Target {get;}

        public Count EmissionCount {get;}

        [MethodImpl(Inline)]
        internal WfFileFlow(IWfRuntime wf, FS.FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public WfFileFlow WithCount(Count count)
            => new WfFileFlow(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public WfFileFlow WithToken(ExecToken token)
            => new WfFileFlow(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator WfExecFlow(WfFileFlow src)
            => new WfExecFlow(src.Wf, src.Token);
    }
}