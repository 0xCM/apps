//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct DiagnosticRecords
    {
        public readonly struct PdbInfo
        {
            public Guid Id {get;}

            public int Revision {get;}

            public FS.FilePath Path {get;}

            [MethodImpl(Inline)]
            public PdbInfo(Guid id, int rev, FS.FilePath path)
            {
                Id = id;
                Revision = rev;
                Path = path;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Id != Guid.Empty && Path.IsNonEmpty;
            }

            public static PdbInfo Empty
            {
                [MethodImpl(Inline)]
                get => new PdbInfo(Guid.Empty, 0, FS.FilePath.Empty);
            }

            public string Format()
                => IsNonEmpty ? string.Format("[{0}]{1}", Id, Path.ToUri()) : "Unavailable";

            public override string ToString()
                => Format();
        }
    }
}