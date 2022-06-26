//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a value-parametric application setting
    /// </summary>
    [Record(TableId)]
    public readonly struct Setting<T> : IComparable<Setting<T>>
    {
        const string TableId = "settings";

        /// <summary>
        /// The setting name
        /// </summary>
        [Render(32)]
        public readonly VarName Name;

        /// <summary>
        /// The setting value
        /// </summary>
        [Render(1)]
        public readonly T Value;

        [Ignore]
        public readonly PrimalKind Primitive;

        [MethodImpl(Inline)]
        public Setting(VarName name, T value)
        {
            Name = name;
            Value = value;
            Primitive = 0;
        }

        [MethodImpl(Inline)]
        public Setting(VarName name, PrimalKind primitive, T value)
        {
            Name = name;
            Value = value;
            Primitive = primitive;
        }

        public Setting NonGeneric
        {
            [MethodImpl(Inline)]
            get => new (Name, Value.ToString());
        }

        public string Format()
            => string.Format(RP.Setting, Name, Value);

        public string Json()
            => string.Format(RP.JsonProp, Name, Value);
        public int CompareTo(Setting<T> src)
            => Name.CompareTo(src.Name);

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