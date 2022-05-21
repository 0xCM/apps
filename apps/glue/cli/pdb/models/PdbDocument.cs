//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PdbDocument : IEquatable<PdbDocument>
    {
        public static PdbDocument adapt(ISymUnmanagedDocument src)
            => new PdbDocument(src, src.GetName(), src.GetDocumentType());

        public readonly string Name;

        public readonly Guid Type;

        readonly ISymUnmanagedDocument Unmanaged;

        [MethodImpl(Inline)]
        public PdbDocument(ISymUnmanagedDocument doc, string name, Guid type)
        {
            Unmanaged = doc;
            Name = name;
            Type = type;
        }

        public FS.FilePath Path
        {
            [MethodImpl(Inline)]
            get => FS.path(Name);
        }

        [MethodImpl(Inline)]
        public string Format()
            => Name;

        public override int GetHashCode()
            => (int)alg.hash.calc(Name);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(PdbDocument src)
            => text.equals(Name,src.Name) && Type == src.Type;

        public override bool Equals(object src)
            => src is PdbDocument x && Equals(x);
    }
}