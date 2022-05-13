//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Bitfields
    {
        [MethodImpl(Inline)]
        public static BfOrigin<T> origin<T>(T src)
            => src;

        [MethodImpl(Inline)]
        public static BfOrigin<ClrTypeName> origin<T>()
            => new BfOrigin<ClrTypeName>(typeof(T), x => x.AssemblyQualifiedName.Format());
    }
}