//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class EnvProvider<P> : IEnvProvider2
    {
        readonly EnvVars Data;

        readonly ConstLookup<VarSymbol,object> Lookup;

        public virtual string Name {get;}

        protected EnvProvider(EnvVar[] src)
        {
            Data = src;
            Lookup = src.Select(x => (x.VarName,(object)x.VarValue)).ToDictionary();
            Name = typeof(P).Name;
        }

        public Index<EnvSetting> Records()
        {
            return default;
        }

        public bool Value<T>(VarSymbol name, out T dst)
            where T : IEquatable<T>
        {
            var result = Lookup.Find(name, out var found);
            if(result)
                dst = (T)found;
            else
                dst = default;
            return result;
        }

        public T Value<T>(VarSymbol name)
            where T : IEquatable<T>
                => (T)Lookup[name];

        public ReadOnlySpan<VarSymbol> VarNames
        {
            [MethodImpl(Inline)]
            get => Lookup.Keys;
        }

        public ReadOnlySpan<object> VarValues
        {
            [MethodImpl(Inline)]
            get => Lookup.Values;
        }

        public uint VarCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ref readonly EnvVar this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly EnvVar this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref readonly EnvVars Vars
            => ref Data;

        public override string ToString()
        {
            var dst = text.emitter();
            for(var i=0; i<VarCount; i++)
            {
                ref readonly var v = ref this[i];
                dst.AppendLineFormat("{0}={1}", v.VarName, v.VarValue);
            }
            return dst.Emit();
        }
    }
}