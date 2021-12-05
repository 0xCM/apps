//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = ApiSigs;

    public class ApiOperandSig
    {
        public Name Name {get;}

        public ApiTypeSig Type {get;}

        public Index<ApiSigModKind> Modifiers {get;}

        [MethodImpl(Inline)]
        public ApiOperandSig(Name name, ApiTypeSig type, ApiSigModKind[] modifiers)
        {
            Name = name;
            Type = type;
            Modifiers = modifiers;
        }

        public bool IsReturn
        {
            [MethodImpl(Inline)]
            get => api.returns(this);
        }

        public bool IsVoid
        {
            [MethodImpl(Inline)]
            get => Type.IsVoid;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsNonEmpty;
        }

        public static ApiOperandSig Empty
        {
            [MethodImpl(Inline)]
            get => new ApiOperandSig(Name.Empty, ApiTypeSig.Empty, sys.empty<ApiSigModKind>());
        }
    }
}