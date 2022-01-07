//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = TypeRefKind;

    public readonly struct TypeRef
    {
        public TypeSpec Type {get;}

        public TypeRefKind Kind {get;}

        [MethodImpl(Inline)]
        public TypeRef(TypeSpec src, TypeRefKind kind)
        {
            Type = src;
            Kind = kind;
        }

        public string Format(params object[] args)
        {
            var pattern = Kind switch{
                K.In => "in {0}",
                K.Out => "out {0}",
                K.Ptr => "{0}*",
                _ => "{0}",
            };
            var format = args.Length != 0 ? string.Format(Type.Text, args) : Type.Text;
            return string.Format(pattern,format);
        }
    }
}