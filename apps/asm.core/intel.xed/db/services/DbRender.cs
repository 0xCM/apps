//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
    {
        public class DbRender
        {
            Index<ObjectKind,string> Patterns;

            Index<ObjectKind,string> Headers;

            Index<ObjectKind,Index<asci32>> Cols;

            [MethodImpl(Inline)]
            public ref readonly string Pattern(ObjectKind kind)
                => ref Patterns[kind];

            [MethodImpl(Inline)]
            public ref readonly Index<asci32> ColNames(ObjectKind kind)
                => ref Cols[kind];

            [MethodImpl(Inline)]
            public ref readonly string Header(ObjectKind kind)
                => ref Headers[kind];

            internal DbRender(DbObjects objects)
            {
                const byte Count = DbObjects.ObjTypeCount;
                var kinds = objects.ObjKinds;

                Patterns = alloc<string>(Count);
                broadcast(EmptyString, Patterns);

                Patterns[ObjectKind.None] = EmptyString;

                Headers = alloc<string>(Count);
                broadcast(EmptyString, Headers);

                Cols = alloc<Index<asci32>>(Count);
                broadcast(Index<asci32>.Empty, Cols);

                for(var i=1; i<kinds.Count; i++)
                {
                    ref readonly var kind = ref kinds[i];
                    ref readonly var cols = ref objects.Cols(kind);
                    switch(kind)
                    {
                        case ObjectKind.TypeTable:
                            Cols[kind] = map(cols, col => col.ColName);
                            Patterns[kind] = cols.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                        break;
                        case ObjectKind.TypeTableField:
                            Cols[kind] = map(cols, col => col.ColName);
                            Patterns[kind] = cols.Select(x => RP.slot((byte)x.Pos, (sbyte)-x.RenderWidth)).Concat(" | ");
                        break;
                    }
                }
            }
        }
    }
}