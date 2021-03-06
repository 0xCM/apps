//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MsgPattern<T> : IMsgPattern<MsgPattern<T>,T>
    {
        public string PatternText {get;}

        [MethodImpl(Inline)]
        public MsgPattern(string src)
            => PatternText = src;

        public string Format(in T src)
            => string.Format(PatternText, $"<{src}>");

        public MsgCapture Capture(in T src)
            => RpOps.msgcap(this, $"<{src}>");


        [MethodImpl(Inline)]
        public static implicit operator MsgPattern<T>(string src)
            => new MsgPattern<T>(src);
    }
}