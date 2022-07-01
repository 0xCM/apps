//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct WsId : IDataType<WsId>, INamed<WsId>
    {
        readonly asci32 Data;

        [MethodImpl(Inline)]
        public WsId(asci32 src)
        {
            Data = src;
        }

        public asci32 Name
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(WsId src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(WsId src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator WsId(string src)
            =>new WsId(src);

        [MethodImpl(Inline)]
        public static implicit operator WsId(asci16 src)
            =>new WsId(src);
    }
}