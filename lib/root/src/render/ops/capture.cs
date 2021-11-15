//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
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
