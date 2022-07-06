//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct RpOps
    {
        [MethodImpl(Inline)]
        public static RenderCapture capture<T>(T src, params object[] args)
            where T : IFormatPattern
                => new RenderCapture(src, args);

        [MethodImpl(Inline)]
        public static MsgCapture msgcap<T>(T src, params object[] args)
            where T : IMsgPattern
                => new MsgCapture(src, args);
   }
}
