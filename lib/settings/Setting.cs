//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    public readonly struct Setting : ISetting
    {
        public readonly string Name;

        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public Setting(string name, dynamic value)
        {
            Name = name ?? EmptyString;
            Value = value ?? EmptyString;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => core.empty(Name) || Value is null;
        }

        dynamic ISetting.Value
            => Value;

        string ISetting.Name
            => Name;

        public string ValueText
            => Value?.ToString() ?? EmptyString;

        public string Format(bool json)
            => api.format(this, json);

        public string Format()
            => Format(false);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Setting((string name, dynamic value) src)
            => new (src.name, src.value);

        public static Setting Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString, EmptyString);
        }
    }
}