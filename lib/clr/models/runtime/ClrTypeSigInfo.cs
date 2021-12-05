//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// A succinct type signature
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ClrTypeSigInfo : IRecord<ClrTypeSigInfo>
    {
        public const string TableId = "clr.typesigs";

        public string DisplayName;

        public string Modifier;

        public bool IsOpenGeneric;

        public bool IsClosedGeneric;

        public bool IsByRef;

        public bool IsIn;

        public bool IsOut;

        public bool IsPointer;

        public bool IsArray;

        public static ClrTypeSigInfo Empty
        {
            get
            {
                var dst = new ClrTypeSigInfo();
                dst.DisplayName = EmptyString;
                dst.Modifier = EmptyString;
                return dst;
            }
        }
    }
}