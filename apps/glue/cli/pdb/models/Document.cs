//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Microsoft.DiaSymReader;

    using static Root;

    partial struct PdbModel
    {
        public readonly struct Document : IEquatable<Document>
        {
            public string Name {get;}

            public Guid Type {get;}

            internal readonly ISymUnmanagedDocument Unmanaged;

            [MethodImpl(Inline)]
            public Document(ISymUnmanagedDocument doc, string name, Guid type)
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
            public bool Equals(Document src)
                => text.equals(Name,src.Name) && Type == src.Type;

            public override bool Equals(object src)
                => src is Document x && Equals(x);
        }
    }
}