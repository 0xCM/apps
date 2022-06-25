//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly record struct CmdId : IIdentity<CmdId>
    {
        public static CmdId identify<T>()
            => identify(typeof(T));

        [Op]
        public static CmdId identify(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(empty(name))
                    return new CmdId(spec.Name);
                else
                    return new CmdId(name);
            }
            else
                return new CmdId(spec.Name);
        }

        [MethodImpl(Inline), Op]
        public static Name name(string src)
            => new Name(src);

        readonly string Data;

        [MethodImpl(Inline)]
        public CmdId(string src)
            => Data = src;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => sys.empty(Data);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => sys.nonempty(Data);
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Data);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Data;

        [MethodImpl(Inline)]
        public bool Equals(CmdId src)
            => string.Equals(Data, src.Data);

        public override string ToString()
            => Format();

        public int CompareTo(CmdId src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(Type spec)
            => identify(spec);

        [MethodImpl(Inline)]
        public static implicit operator Name(CmdId src)
            => name(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(Name src)
            => new CmdId(src.Content);

        public static CmdId Empty => default;
    }
}