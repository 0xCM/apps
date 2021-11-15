//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CodedTokenRefSizes
    {
        public const string TableId = "clisize.coded-token-ref";

        public uint TypeDefOrRefRefSize;

        public uint HasConstantRefSize;

        public uint HasCustomAttributeRefSize;

        public uint HasFieldMarshalRefSize;

        public uint HasDeclSecurityRefSize;

        public uint MemberRefParentRefSize;

        public uint HasSemanticsRefSize;

        public uint MethodDefOrRefRefSize;

        public uint MemberForwardedRefSize;

        public uint ImplementationRefSize;

        public uint CustomAttributeTypeRefSize;

        public uint ResolutionScopeRefSize;

        public uint TypeOrMethodDefRefSize;
    }
}