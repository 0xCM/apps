//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    [Record(TableId)]
    public readonly record struct Setting : ISetting, IComparable<Setting>
    {
        const string TableId = "settings";

        public readonly PrimalKind Primitive;

        [Render(32)]
        public readonly VarName Name;

        [Render(1)]
        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public Setting(VarName name, dynamic value)
        {
            Primitive = 0;
            Name = name;
            Value = value;
        }

        [MethodImpl(Inline)]
        public Setting(VarName name, PrimalKind primal, dynamic value)
        {
            Name = name;
            Primitive = primal;
            Value = value ?? EmptyString;
        }

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

        dynamic ISetting.Value
            => Value;

        VarName ISetting.Name
            => Name;

        public override int GetHashCode()
            => Hash;

        public bool Equals(Setting src)
            => Object.Equals(Value, src.Value) && Name == src.Name;

        public string Format(bool json)
            => api.format(this, json);

        public string Format()
            => Format(false);

        public override string ToString()
            => Format();

        public int CompareTo(Setting src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public static implicit operator Setting<VarName,dynamic>(Setting src)
            => new Setting<VarName,dynamic>(src.Name, src.Value);

        public static Setting Empty
        {
            [MethodImpl(Inline)]
            get => new (EmptyString, 0, EmptyString);
        }
    }
}