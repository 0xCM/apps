//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct AsmFormatConfig : IRecord<AsmFormatConfig>
    {
        public const string TableId = "asm.format-config";

        public bool EmitCaptureTermCode;

        public bool EmitFileHeader;

        public bool EmitLineLabels;

        public bool EmitLineAddresses;

        public bool AbsoluteLabels;

        public HexFormatOptions HeaderEncodingFormat;

        public static AsmFormatConfig DefaultStreamFormat
            => @default(out var _);

        public static ref AsmFormatConfig @default(out AsmFormatConfig dst)
        {
            dst.EmitCaptureTermCode = true;
            dst.EmitFileHeader = true;
            dst.EmitLineLabels = false;
            dst.AbsoluteLabels = false;
            dst.EmitLineAddresses = true;
            dst.HeaderEncodingFormat = HexFormatSpecs.options();
            return ref dst;
        }
    }
}