//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class SettingProvider<P> : ISettingProvider
    {
        readonly Index<Setting<string,object>> Data;

        readonly ConstLookup<string,object> Lookup;

        public virtual string Name {get;}

        protected SettingProvider(Setting<string,object>[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.Name,x.Value)).ToDictionary();
            Name = typeof(P).Name;
        }

        public Index<EnvVarRow> Records()
        {
            return default;
        }

        public bool Value<T>(string name, out T dst)
            where T : IEquatable<T>
        {
            var result = Lookup.Find(name, out var found);
            if(result)
                dst = (T)found;
            else
                dst = default;
            return result;
        }

        public T Value<T>(string name)
            where T : IEquatable<T>
                => (T)Lookup[name];

        public ReadOnlySpan<string> Names
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ReadOnlySpan<object> Values
        {
            [MethodImpl(Inline)]
            get => Lookup.Values;
        }

        public uint VarCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly Setting<string,object> this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly Setting<string,object> this[int index]
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