//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct WfFileWritten
    {
        readonly IWfRuntime Wf;

        public ExecToken Token {get;}

        public FS.FilePath Target {get;}

        public Count EmissionCount {get;}

        [MethodImpl(Inline)]
        internal WfFileWritten(IWfRuntime wf, FS.FilePath dst, in ExecToken token, uint count = 0)
        {
            Wf = wf;
            Token = token;
            Target = dst;
            EmissionCount = count;
        }

        [MethodImpl(Inline)]
        public WfFileWritten WithCount(Count count)
            => new WfFileWritten(Wf, Target, Token, count);

        [MethodImpl(Inline)]
        public WfFileWritten WithToken(ExecToken token)
            => new WfFileWritten(Wf, Target, token, EmissionCount);

        [MethodImpl(Inline)]
        public static implicit operator WfExecFlow(WfFileWritten src)
            => new WfExecFlow(src.Wf, src.Token);
    }
}