//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static IWfEventTarget ToTarget(this WfEventLogger src)
            => new WfEventTarget(src);
    }

    public interface IWfEventTarget : ISink<IWfEvent>
    {

    }

    public readonly struct WfEventTarget : IWfEventTarget
    {
        readonly WfEventLogger Logger;

        [MethodImpl(Inline)]
        public WfEventTarget(WfEventLogger logger)
        {
            Logger = logger;
        }

        [MethodImpl(Inline)]
        public void Deposit(IWfEvent src)
            => Logger(src);

        [MethodImpl(Inline)]
        public static implicit operator WfEventTarget(WfEventLogger src)
            => new WfEventTarget(src);
    }
}