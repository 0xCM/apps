//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a value-parametric application setting
    /// </summary>
    public readonly struct Setting<T> : ISetting<T>
    {
        /// <summary>
        /// The setting name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The setting value
        /// </summary>
        public T Value {get;}

        [MethodImpl(Inline)]
        public Setting(string name, T value)
        {
            Name = name ?? EmptyString;
            Value = value;
        }

        public Setting NonGeneric
        {
            [MethodImpl(Inline)]
            get => new Setting(Name, Value.ToString());
        }

        public string Format()
            => string.Format(RP.Setting, Name, Value);

        public string Json()
            => string.Format(RP.JsonProp, Name, Value);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Setting(Setting<T> src)
            => src.NonGeneric;

        [MethodImpl(Inline)]
        public static implicit operator T(Setting<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator Setting<T>(T src)
            => new Setting<T>(EmptyString, src);

        [MethodImpl(Inline)]
        public static implicit operator Setting<T>((string name, T value) src)
            => new Setting<T>(src.name, src.value);

        public static Setting<T> Empty
        {
            [MethodImpl(Inline)]
            get => new Setting<T>(String.Empty, core.EmptyType<T>());
        }
    }
}