//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct CoffSymbol
    {
        public CoffSymbolName Name;

        public Hex32 Value;

        public ushort Section;

        public ImageSymType Type;

        public SymStorageClass Class;

        public byte NumberOfAuxSymbols;
    }
}
