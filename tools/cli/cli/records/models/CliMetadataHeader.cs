//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes the length-invariant leading bytes of the metadata root as specified in II.24.2.1
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CliMetadataHeader : ITextual
    {
        const uint RequiredMagic = 0x42_4A_53_42;

        /// <summary>
        /// The value 0x424A5342 identifies the beginning of the metadata header
        /// </summary>
        public Hex32 Magic;

        public ushort MajorVersion;

        public ushort MinorVersion;

        uint Reserved;

        uint _VersionSize;

        public utf8 VersionText;

        /// <summary>
        /// The size of the utf8-encoded version string, including the null terminator, with 32-bit alignment
        /// </summary>
        public byte VersionSize
        {
            [MethodImpl(Inline)]
            get => (byte)_VersionSize;

            [MethodImpl(Inline)]
            set => _VersionSize = (byte)value;
        }

        public bool IsValid
        {
            [MethodImpl(Inline)]
            get => Magic == RequiredMagic;
        }

        public string Format()
            => IsValid ? VersionText : "Invalid";

        public override string ToString()
            => Format();
    }
}