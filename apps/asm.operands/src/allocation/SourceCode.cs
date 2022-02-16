//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SourceCode : ISourceCode<SourceCode>
    {
        public SourceText Source {get;}

        public CorrelationToken CT {get;}

        public uint Hash {get;}

        [MethodImpl(Inline)]
        public SourceCode(SourceText src, CorrelationToken ct)
        {
            Source = src;
            CT = ct;
            Hash = src.Hash;
        }

        [MethodImpl(Inline)]
        internal SourceCode(SourceText src, CorrelationToken ct, uint hash)
        {
            Source = src;
            CT = ct;
            Hash = hash;
        }

        [MethodImpl(Inline)]
        public bool Equals(SourceCode src)
            => CT.Equals(src.CT);

        [MethodImpl(Inline)]
        public int CompareTo(SourceCode src)
            => CT.CompareTo(src.CT);

        public override bool Equals(object src)
            => src is SourceCode x && Equals(x);

        public override int GetHashCode()
            => (int)Hash;

        public string Format()
            => Source.Format();

        public override string ToString()
            => Source.Format();
    }
}