//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberRefInfo : IRecord<MemberRefInfo>
    {
        public const string TableId = "cli.metadata.memberref";

        public CliToken Token;

        public MemberRefKind RefKind;

        public CliToken Parent;

        public NameOld Name;

        public CliSig Sig;
    }

    public enum MemberRefKind : byte
    {
        Method,

        Field = 1,
    }
}