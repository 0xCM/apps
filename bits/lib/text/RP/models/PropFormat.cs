//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct PropFormat : ITextual
    {
        public Name Name {get;}

        public dynamic Value {get;}

        public sbyte Pad {get;}

        [MethodImpl(Inline)]
        internal PropFormat(Name name, dynamic value, sbyte pad)
        {
            Name = name;
            Value = value;
            Pad = pad;
        }

        public string Format(char sep)
            => string.Format("{0}{1}{2}",
                string.Format(RP.pad(Pad), Name),
                string.Format("{0} ", sep),
                    Value);

        public string Format()
            => Format(RP.PropertySep);

        public override string ToString()
            => Format();
    }

    public readonly struct PropFormat<T> : ITextual
    {
        public Name Name {get;}

        public T Value {get;}

        public sbyte Pad {get;}

        [MethodImpl(Inline)]
        public PropFormat(Name name, T value, sbyte pad)
        {
            Name = name;
            Value = value;
            Pad = pad;
        }

        [MethodImpl(Inline)]
        public PropFormat(Name name, T value)
        {
            Name = name;
            Value = value;
            Pad = RP.PropertyPad;
        }

        public string Format(char sep)
            => string.Format("{0}{1}{2}",
                string.Format(RP.pad(Pad), Name),
                string.Format("{0} ",sep),
                    Value);

        public string Format()
            => Format(RP.PropertySep);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PropFormat<T>((string name, T value) src)
            => new PropFormat<T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator PropFormat<T>((string name, T value, int pad) src)
            => new PropFormat<T>(src.name, src.value, (sbyte)src.pad);

        [MethodImpl(Inline)]
        public static implicit operator PropFormat(PropFormat<T> src)
            => new PropFormat(src.Name, src.Value, src.Pad);
    }
}