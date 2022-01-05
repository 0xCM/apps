//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TypeRef
    {
        public uint Key {get;}

        readonly ITypeProvider Source;

        [MethodImpl(Inline)]
        public TypeRef(ITypeProvider src, uint key)
        {
            Source = src;
            Key = key;
        }

        public IType Resolve()
            => Source.Resolve(Key);
    }
}