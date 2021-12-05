//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Asci
    {
        [MethodImpl(Inline), Op]
        public static bool contains(asci4 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains(asci8 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains(in asci16 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains(in asci32 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains(in asci64 src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains(AsciSequence src, char match)
            => AsciG.contains(src, (AsciCharSym)match);

        [MethodImpl(Inline), Op]
        public static bool contains<T>(AsciSequence<T> src, char match)
            where T : unmanaged, IAsciSeq
                => AsciG.contains(src, (AsciCharSym)match);
    }
}