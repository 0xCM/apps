//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    /// <summary>
    /// Describes the assembly encoding of a member api
    /// </summary>
    public class AsmRoutine : IComparable<AsmRoutine>
    {
        /// <summary>
        /// The defining operation uri
        /// </summary>
        public OpUri Uri {get;}

        /// <summary>
        /// The source member signature
        /// </summary>
        public @string DisplaySig {get;}

        /// <summary>
        /// The function encoding
        /// </summary>
        public ApiCodeBlock Code {get;}

        /// <summary>
        /// The encoded instructions
        /// </summary>
        public Index<ApiInstruction> Instructions {get;}

        /// <summary>
        /// Specifies the reason for capture termination
        /// </summary>
        public ExtractTermCode TermCode {get;}

        [MethodImpl(Inline)]
        public AsmRoutine(OpUri uri, @string sig, ApiCodeBlock code, ExtractTermCode term, Index<ApiInstruction> instructions)
        {
            Uri = uri;
            DisplaySig = sig;
            Instructions = instructions;
            Code = code;
            TermCode = term;
        }

        [MethodImpl(Inline)]
        public int CompareTo(AsmRoutine other)
            => Code.BaseAddress.CompareTo(other.BaseAddress);

        /// <summary>
        /// The head of the address range
        /// </summary>
        public MemoryAddress BaseAddress
        {
            [MethodImpl(Inline)]
            get => Code.BaseAddress;
        }

        /// <summary>
        /// The number of encoded instructions
        /// </summary>
        public int InstructionCount
        {
            [MethodImpl(Inline)]
            get => Instructions.Length;
        }

        public bool IsEmpty
            => InstructionCount == 0;

        public bool IsNonEmpty
            => InstructionCount != 0;

        public static AsmRoutine Empty
            => new AsmRoutine(OpUri.Empty, @string.Empty, ApiCodeBlock.Empty, 0, Index<ApiInstruction>.Empty);
    }
}