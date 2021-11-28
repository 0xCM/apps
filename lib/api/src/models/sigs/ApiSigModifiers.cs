//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    using K = ApiSigModKind;

    [ApiHost]
    public readonly struct ApiSigModifiers
    {
        [Op]
        public static In @in()
            => default;

        [Op]
        public static Out @out()
            => default;

        [Op]
        public static Ref @ref()
            => default;

        [Op]
        public static Ptr ptr()
            => default;

        [Op]
        public static Imm imm()
            => default;

        public readonly struct In : IApiSigMod<In>
        {
            public Name Name => "in";

            public K Kind => K.In;

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ApiSigMod(In src)
                => new ApiSigMod(src.Name,src.Kind);
        }

        public readonly struct Out : IApiSigMod<Out>
        {
            public Name Name => "out";

            public K Kind => K.Out;

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ApiSigMod(Out src)
                => new ApiSigMod(src.Name,src.Kind);
        }

        public readonly struct Ref : IApiSigMod<Ref>
        {
            public Name Name => "ref";

            public K Kind => K.Ref;

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ApiSigMod(Ref src)
                => new ApiSigMod(src.Name,src.Kind);
        }

        public readonly struct Ptr : IApiSigMod<Ptr>
        {
            public Name Name => "ptr";

            public K Kind => K.Ptr;

            public string Format()
                => Name;

            public override string ToString()
                => Name;


            [MethodImpl(Inline)]
            public static implicit operator ApiSigMod(Ptr src)
                => new ApiSigMod(src.Name,src.Kind);

        }

        public readonly struct Imm : IApiSigMod<Imm>
        {
            public Name Name => "imm";

            public K Kind => K.Imm;

            public string Format()
                => Name;

            public override string ToString()
                => Name;

            [MethodImpl(Inline)]
            public static implicit operator ApiSigMod(Imm src)
                => new ApiSigMod(src.Name,src.Kind);
        }
    }
}