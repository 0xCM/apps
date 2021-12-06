//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmCaseArchive
    {
        [ApiHost("cases.callrel32")]
        public struct CallRel32Case
        {
            [Op]
            public static ulong f(int i, byte a, ushort b, uint c, ulong d)
                => (ulong)f0(a) & f1(b) | f2(c) ^ f3(c);

            [MethodImpl(NotInline), Op]
            public static byte f0(byte a)
                => (byte)(a & 0xF0);

            [MethodImpl(NotInline), Op]
            public static ushort f1(ushort b)
                => (ushort)(b & 0xF0F0);

            [MethodImpl(NotInline), Op]
            public static uint f2(uint c)
                => (uint)(c & 0xF0F0F0F0);

            [MethodImpl(NotInline), Op]
            public static ulong f3(ulong d)
                => (ulong)(d & 0xF0F0F0F0F0F0F0F0);

            public static string format(in CallRel32Case src)
            {
                var dst = text.buffer();
                dst.AppendLine(src.AsmSource);
                dst.AppendLine(text.prop(nameof(src.Caller), AsmRender.format(src.Caller)));
                dst.AppendLine(text.prop(nameof(src.Ip), src.Ip.Format()));
                dst.AppendLine(text.prop(nameof(src.NextIp), src.NextIp.Format()));
                dst.AppendLine(text.prop(nameof(src.Target), src.Target.Format()));
                dst.AppendLine(text.prop(nameof(src.RelTarget), src.RelTarget.Format()));
                dst.AppendLine(text.prop(nameof(src.Encoding), src.Encoding.Format()));
                return dst.Emit();
            }

            /// <summary>
            /// Validates the integrity of the case itself
            /// </summary>
            /// <param name="src">The case to validate</param>
            /// <param name="errors">An error receiver</param>
            public static Outcome validate(in CallRel32Case src, ITextBuffer errors)
            {
                var valid = Outcome.Success;
                const byte fxsize = 5;

                if(src.IpDelta != fxsize)
                {
                    errors.AppendLineFormat($"{nameof(src.IpDelta)} = ${src.IpDelta} != {fxsize}");
                    valid = false;
                }

                if(src.Encoding.Size != fxsize)
                {
                    errors.AppendLineFormat($"{nameof(src.Encoding.Size)} = ${src.Encoding.Size} != {fxsize}");
                    valid = false;
                }

                if(src.Offset != src.RelTarget)
                {
                    errors.AppendLineFormat($"{nameof(src.Offset)} = ${src.Offset} != {src.RelTarget} = {nameof(src.RelTarget)}");
                    valid = false;
                }

                return valid;
            }

            public SyntaxFragment AsmSource;

            public AsmCaller Caller;

            public MemoryAddress Ip;

            public MemoryAddress NextIp;

            public MemoryAddress Target;

            public Address32 RelTarget;

            public AsmHexCode Encoding;

            public Address32 Offset
                => (Address32)(Target - NextIp);

            public ByteSize IpDelta
                => (ByteSize)(NextIp - Ip);

            public string Format()
                => format(this);

            public Outcome Validate(ITextBuffer errors)
                => validate(this, errors);

            public override string ToString()
                => Format();
        }
    }
}