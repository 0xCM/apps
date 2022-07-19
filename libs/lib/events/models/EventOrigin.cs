//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct EventOrigin : ITextual
    {
        public NameOld OriginName {get;}

        public CallingMember Caller {get;}

        [MethodImpl(Inline)]
        public EventOrigin(string name, in CallingMember caller)
        {
            OriginName = name;
            Caller = caller;
        }

        public EventOrigin(string caller, string file, uint line)
        {
            Caller = new (caller,file,(int)line);
            OriginName = caller;
        }

        public string Format()
            => RpOps.piped(OriginName, Caller);

        public override string ToString()
            => Format();
    }
}