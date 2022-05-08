//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public partial class DbObjects
        {
            internal const byte ObjTypeCount = 24;

            static Index<ObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);

            [MethodImpl(Inline)]
            public static ref readonly uint ObjectCount(ObjectKind kind)
                => ref ObjectCounts[kind];

            public static ref readonly Index<ObjectKind,uint> ObjectCounts
            {
                [MethodImpl(Inline)]
                get => ref ObjSeqSource;
            }

            [MethodImpl(Inline)]
            public static uint NextSeq(ObjectKind kind)
                => inc(ref ObjSeqSource[kind]);
        }
    }
}