//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    partial struct DiagnosticRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct MethodTableToken : IComparableRecord<MethodTableToken>
        {
            public const string TableId = "diagnostic.method-table";

            public MemoryAddress Table;

            public CliToken Method;

            [MethodImpl(Inline)]
            public MethodTableToken(MemoryAddress address, CliToken token)
            {
                Table = address;
                Method = token;
            }

            [MethodImpl(Inline)]
            public int CompareTo(MethodTableToken src)
            {
                var result = Table.CompareTo(src.Table);
                if(result == 0)
                    result = Method.CompareTo(src.Method);
                return result;
            }
        }
    }
}