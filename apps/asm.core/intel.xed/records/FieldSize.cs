//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record struct FieldSize
        {
            public ushort DataSize;

            public ushort DataWidth;

            public ushort DomainSize;

            public ushort DomainWidth;

            [MethodImpl(Inline)]
            public FieldSize(ByteSize datsz, BitWidth datw, ByteSize domsz, BitWidth domw)
            {
                DataSize = (ushort)datsz;
                DataWidth = (ushort)datw;
                DomainSize = (ushort)domsz;
                DomainWidth = (ushort)domw;
            }

            public string Format()
                => string.Format("{0,-3} {1,-3} {2,-3}", DataSize, DomainSize, DomainWidth);

            [MethodImpl(Inline)]
            public static FieldSize operator +(FieldSize a, FieldSize b)
                => new FieldSize(
                    a.DataSize + b.DataSize,
                    a.DataWidth + b.DataWidth,
                    a.DomainSize + b.DomainSize,
                    a.DomainWidth + b.DomainWidth
                    );

            public override string ToString()
                => Format();

            public static FieldSize Empty => default;
        }
    }
}