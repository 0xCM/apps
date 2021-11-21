//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using llvm.COFF;

    using static Root;

    [StructLayout(LayoutKind.Sequential)]
    public struct CoffSymbol
    {
        public uint Seq;

        public string Name;

        public uint Value;

        public string SectionName;

        public uint SectionNumber;

        public SymbolBaseType BaseType;

        public SymbolStorageClass StorageClass;

        public bool IsNonEmpty
        {
            get => text.nonempty(Name);
        }

        public static CoffSymbol Empty
        {
            get
            {
                var dst = new CoffSymbol();
                dst.Name = EmptyString;
                dst.SectionName = EmptyString;
                return dst;
            }
        }
    }
}