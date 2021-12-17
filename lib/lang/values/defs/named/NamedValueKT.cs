//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Assigns a K-parametric name to a T-value
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=1), Blittable]
    public readonly struct NamedValue<K,T>
    {
        /// <summary>
        /// The name of the value
        /// </summary>
        public K Name {get;}

        /// <summary>
        /// The named value
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public NamedValue(K name, T value)
        {
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public NamedValue((K name, T value) nv)
        {
            Name = nv.name;
            Value = nv.value;
        }

        [MethodImpl(Inline)]
        public void Deconstruct(out K name, out T value)
        {
            name = Name;
            value = Value;
        }

        [MethodImpl(Inline)]
        public static implicit operator NamedValue(NamedValue<K,T> src)
            => new NamedValue(src.Name.ToString(), src.Value?.ToString() ?? EmptyString);

        public string Format()
            => string.Format(RP.Attrib, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator NamedValue<K,T>((K name, T value) src)
            => new NamedValue<K,T>(src.name, src.value);

        [MethodImpl(Inline)]
        public static implicit operator (K name, T value)(NamedValue<K,T> src)
            => (src.Name, src.Value);

        public static NamedValue<K,T> Empty
            => default;
    }
}