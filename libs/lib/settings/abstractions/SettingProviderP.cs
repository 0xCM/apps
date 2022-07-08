//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SettingProvider<V> : ISettingProvider<V>
    {
        readonly Index<Setting<Name,V>> Data;

        readonly SortedLookup<Name,V> Lookup;

        public virtual Name Name {get;}

        protected SettingProvider(Setting<Name,V>[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.Name,x.Value)).ToDictionary();
            Name = typeof(V).Name;
        }

        protected SettingProvider(Name name, Setting<Name,V>[] src, Dictionary<Name,V> lookup)
        {
            Name = name;
            Data = src;
            Lookup = lookup;
            Name = typeof(V).Name;
        }

        public Index<EnvVarRow> Records()
        {
            return default;
        }

        public bool Value(Name name, out V dst)
        {
            var result = Lookup.Find(name, out var found);
            if(result)
                dst = found;
            else
                dst = default;
            return result;
        }

        public V Value(Name name)
            => Lookup[name];

        public ReadOnlySpan<Name> Names
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ReadOnlySpan<V> Values
        {
            [MethodImpl(Inline)]
            get => Lookup.Values;
        }

        public uint VarCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly Setting<Name,V> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly Setting<Name,V> this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public override string ToString()
        {
            var dst = text.emitter();
            for(var i=0; i<VarCount; i++)
            {
                ref readonly var v = ref this[i];
                dst.AppendLineFormat("{0}={1}", v.Name, v.Value);
            }
            return dst.Emit();
        }
    }
}