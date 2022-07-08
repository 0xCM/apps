//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdSource : ICmdSource
    {
        public readonly Name Name;

        readonly Settings64 Data;

        public CmdSource(Name name, Settings64 src)
        {
            Name = name;
            Data = src;
        }

        [MethodImpl(Inline)]
        public ref readonly Setting64 Command(uint index)
            => ref Data[index];

        [MethodImpl(Inline)]
        public ref readonly Setting64 Command(int index)
            => ref Data[index];

        public ref readonly ReadOnlySeq<Setting64> Commands
        {
            [MethodImpl(Inline)]
            get => ref Data.Settings;
        }

        [MethodImpl(Inline)]
        public bool Find(Name name, out Setting64 value)
            => Data.Find(name, out value);
    }
}