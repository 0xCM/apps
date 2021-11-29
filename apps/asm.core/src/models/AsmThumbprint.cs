//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Chars;
    using static core;


    public readonly struct AsmThumbprint : IComparable<AsmThumbprint>, IEquatable<AsmThumbprint>
    {
        static Fence<char> SigFence => (LParen, RParen);

        static Fence<char> OpCodeFence => (Lt, Gt);

        const string Implication = " => ";

        public static Outcome parse(string src, out AsmThumbprint thumbprint)
        {
            thumbprint = AsmThumbprint.Empty;
            var result = Outcome.Success;
            var a = src.LeftOfFirst(Semicolon);
            Hex.parse16u(a.LeftOfFirst(Chars.Space), out var offset);
            AsmExpr statement = a.RightOfFirst(Semicolon);

            var parts = @readonly(src.RightOfFirst(Semicolon).SplitClean(Implication));
            if(parts.Length < 2)
                return (false, $"Could not partition {src} ");

            var A = skip(parts,0);
            var B = skip(parts,1).Trim();

            // For thumbprints that include a bitstring such as 0001 0000 0000 1111
            var C = parts.Length > 2 ? skip(parts,2) : EmptyString;
            if(text.unfence(A, SigFence, out var sigexpr))
            {
                result = AsmParser.sigxpr(sigexpr, out var sig);
                if(result.Fail)
                    return (false, $"Could not parse sig expression from ${sigexpr}");

                if(text.unfence(A, OpCodeFence, out var opcode))
                {
                    if(AsmHexCode.parse(B, out var encoded))
                    {
                        thumbprint = new AsmThumbprint(statement, sig, new AsmOpCodeString(opcode), encoded);
                        return true;
                    }
                    else
                        return (false, "Could not parse the encoded bytes");
                }
                else
                    return (false, Msg.OpCodeFenceNotFound.Format(OpCodeFence));
            }
            else
                return (false, $"Could not locate the signature fence {SigFence}");
        }

        public AsmExpr Statement {get;}

        public AsmSigInfo Sig {get;}

        public AsmOpCodeString OpCode {get;}

        public AsmHexCode Encoded {get;}

        [MethodImpl(Inline), Op]
        public AsmThumbprint(AsmExpr statement, AsmSigInfo sig, AsmOpCodeString opcode, AsmHexCode encoded)
        {
            Statement = statement;
            Sig = sig;
            OpCode = opcode;
            Encoded = encoded;
        }

        public byte CodeSize
        {
            [MethodImpl(Inline)]
            get => Encoded.Size;
        }

        public int CompareTo(AsmThumbprint src)
            => cmp(this, src);

        public bool Equals(AsmThumbprint src)
            => eq(this, src);

        public override int GetHashCode()
            => Format().GetHashCode();
        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        public static AsmThumbprint Empty
        {
            [MethodImpl(Inline)]
            get => new AsmThumbprint(AsmExpr.Empty, AsmSigInfo.Empty, AsmOpCodeString.Empty, AsmHexCode.Empty);
        }

        [Op]
        static int cmp(in AsmThumbprint a, in AsmThumbprint b)
            => AsmRender.format(a).CompareTo(AsmRender.format(b));

        [Op]
        static bool eq(in AsmThumbprint a, in AsmThumbprint b)
            => AsmRender.format(a).Equals(AsmRender.format(b));
    }
}