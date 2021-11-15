//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    public readonly struct CmdId : ITextual, IEquatable<CmdId>, INullity, IHashed
    {
        public static CmdId from<T>()
            => from(typeof(T));

        [Op]
        public static CmdId from(Type spec)
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
        public static CmdId from(string src)
            => new CmdId(src);

        public static Name name<T>()
            => name(typeof(T));

        [MethodImpl(Inline), Op]
        public static Name name(string src)
            => new Name(src);
        [Op]
        public static Name name(Type spec)
        {
            var tag = spec.Tag<CmdAttribute>();
            if(tag)
            {
                var name = tag.Value.Name;
                if(empty(name))
                    return spec.Name;
                else
                    return name;
            }
            else
                return spec.Name;
        }

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

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)Data.GetHashCode();
        }

        [MethodImpl(Inline)]
        public string Format()
            => Data;

        [MethodImpl(Inline)]
        public bool Equals(CmdId src)
            => string.Equals(Data, src.Data);

        public override bool Equals(object obj)
            => obj is CmdId x ? Equals(x) : false;

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public static bool operator ==(CmdId a, CmdId b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(CmdId a, CmdId b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(Type spec)
            => from(spec);

        [MethodImpl(Inline)]
        public static implicit operator Name(CmdId src)
            => name(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator CmdId(Name src)
            => new CmdId(src.Content);

        public static CmdId Empty => default;
    }
}