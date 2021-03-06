//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class EnumParser : IParser
    {
        [MethodImpl(Inline)]
        public static EnumParser<E> create<E>()
            where E : unmanaged, Enum
                => new();

        readonly SymIndex Syms;

        public EnumParser(Type src)
        {
            Syms = SymIndex.create(src);
            TargetType = src;
        }

        public Type TargetType {get;}

        public Outcome Parse(string src, out dynamic dst)
        {
            if(Syms.Parse(src, out dst))
            {
                return true;
            }
            else
            {
                dst = default;
                return (false, string.Format("The value '{0}' could not be interpreted as a {1} member", src, TargetType.Name));
            }
        }
    }
}