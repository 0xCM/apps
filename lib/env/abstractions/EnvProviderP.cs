//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class EnvProvider<P> : IEnvProvider2
    {
        readonly Index<EnvVar> Data;

        protected EnvProvider(EnvVar[] src)
        {
            Data = src;
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

        public ref readonly Index<EnvVar> Vars
            => ref Data;

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