//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EnvSet<S> :  EnvProvider<EnvSet<S>>, IEnvSet<S>
        where S : struct
    {
        readonly ConstLookup<string,object> Data;

        internal EnvSet(ConstLookup<string,object> data, S src, Index<EnvVar> vars)
            : base(vars)
        {
            Data = data;
        }

        public bool Value<T>(string name, out T dst)
        {
            var result = Data.Find(name, out var found);
            if(result)
                dst = (T)found;
            else
                dst = default;
            return result;
        }

        public T Value<T>(string name)
            => (T)Data[name];

        public ReadOnlySpan<string> VarNames
        {
            [MethodImpl(Inline)]
            get => Data.Keys;
        }

        public ReadOnlySpan<object> VarValues
        {
            [MethodImpl(Inline)]
            get => Data.Values;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.EntryCount;
        }
    }
}