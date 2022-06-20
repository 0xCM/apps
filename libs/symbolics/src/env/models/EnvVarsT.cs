//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class EnvVars<T> : Seq<EnvVars<T>,EnvVar<T>>
        where T : IEquatable<T>
    {
        readonly ConstLookup<SettingName<asci64>,T> Lookup;

        public EnvVars(EnvVar<T>[] src)
            : base(src)
        {
            Lookup = src.Select(x => (x.Name, x.Value)).ToDictionary();
        }

        public bool Find(asci64 name, out T value)
            => Lookup.Find(name, out value);

        public ReadOnlySpan<SettingName<asci64>> Names
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public static implicit operator EnvVars<T>(EnvVar<T>[] src)
            => new EnvVars<T>(src);
    }
}