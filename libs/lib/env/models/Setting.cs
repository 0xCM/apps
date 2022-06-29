//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public readonly record struct Setting : ISetting, IComparable<Setting>
    {
        const string TableId = "settings";

        public readonly SettingType Type;

        [Render(32)]
        public readonly VarName Name;

        [Render(1)]
        public readonly string Value;

        [MethodImpl(Inline)]
        public Setting(VarName name, string value)
        {
            Type = 0;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public Setting(VarName name, SettingType type, string value)
        {
            Name = name;
            Type = type;
            Value = value ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public Setting<T> Convert<T>(Func<string,T> f)
            => new Setting<T>(Name, f(ValueText));

        public string ValueText
            => Value?.ToString() ?? EmptyString;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty || Value is null;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => core.hash(Name) | (Hash32)(Value?.GetHashCode() ?? 0);
        }

        VarName ISetting.Name
            => Name;

        string ISetting.Value
            => Value;

        public override int GetHashCode()
            => Hash;

        public bool Equals(Setting src)
            => Object.Equals(Value, src.Value) && Name == src.Name;

        public string Json()
            => Settings.json(this);

        public string Format(char sep)
            => $"{Name}{sep}{ValueText}";

        public int CompareTo(Setting src)
            => Name.CompareTo(src.Name);

        public static Setting Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString, 0, EmptyString);
        }
    }
}