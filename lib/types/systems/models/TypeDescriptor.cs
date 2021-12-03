//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct TypeDescriptor
    {
        public Identifier Scope;

        public Identifier Name;

        public string Specifier;

        public ClrTypeKind RuntimeKind;

        public TextBlock Description;

        public Index<TypeParamDescriptor> Parameters;

        public bool IsParametric
            => Parameters.IsNonEmpty;
    }
}