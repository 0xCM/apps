//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberRefInfo : IRecord<MemberRefInfo>
    {
        public const string TableId = "cli.metadata.memberref";

        public CliToken Token;

        public MemberRefKind RefKind;

        public CliToken Parent;

        public Name Name;

        public CliSig Sig;
    }

    public enum MemberRefKind : byte
    {
        Method,

        Field = 1,
    }
}