//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=16)]
    public struct FeatureMnemonicInfo : IRecord<FeatureMnemonicInfo>
    {
        public const string TableId = "feature-mnemonics";

        public const byte FieldCount = 4;

        public AsciBlock<N16> Name;

        public AsciBlock<N16> Identifier;

        public AsciBlock<N16> Symbol;

        public string Description;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,16,8};
    }
}