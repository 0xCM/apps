//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedModels;
    using static XedRules;

    using P = XedRules.InstPattern;
    using M = XedModels;
    using R = XedRules;

    partial class XedMachine
    {
        /// <summary>
        /// Specifies the dependency <see cref='M.OpName'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly Index<OpName> OpNames
        {
            [MethodImpl(Inline)]
            get => ref Pattern.OpNames;
        }

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => (byte)Pattern.Ops.Count;
        }

        /// <summary>
        /// Specifies the dependency <see cref='R.FieldSet'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly FieldSet FieldDeps
        {
            [MethodImpl(Inline)]
            get => ref Pattern.FieldDeps;
        }

        /// <summary>
        /// Specifies the expression-related <see cref='R.InstFields'/>  of the current <see cref='P'/>
        /// </summary>
        public ref readonly InstFields InstExpr
        {
            [MethodImpl(Inline)]
            get => ref Pattern.Expr;
        }

        /// <summary>
        /// Specifies the <see cref='XedOpCode'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly XedOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => ref Pattern.OpCode;
        }

        /// <summary>
        /// Specifies the <see cref='M.Isa'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly InstIsa Isa
        {
            [MethodImpl(Inline)]
            get => ref Pattern.Isa;
        }

        /// <summary>
        /// Specifies the <see cref='M.Category'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly Category Category
        {
            [MethodImpl(Inline)]
            get => ref Pattern.Category;
        }

        /// <summary>
        /// Specifies the <see cref='M.Extension'/> of the current <see cref='P'/>
        /// </summary>
        public ref readonly Extension Extension
        {
            [MethodImpl(Inline)]
            get => ref Pattern.Extension;
        }

        /// <summary>
        /// Specifies the pattern Id of the<see cref='P'/>
        /// </summary>
        public ref readonly ushort PatternId
        {
            [MethodImpl(Inline)]
            get => ref @as<uint,ushort>(Pattern.PatternId);
        }

        /// <summary>
        /// Specifies layout <see cref='R.InstFields'/> associated with the current <see cref='P'/>
        /// </summary>
        public ref readonly InstFields InstLayout
        {
            [MethodImpl(Inline)]
            get => ref Pattern.Layout;
        }

        /// <summary>
        /// Specifies <see cref='R.InstOpDetail'/> associated with the current <see cref='P'/>
        /// </summary>
        public ref readonly Index<InstOpDetail> Ops
        {
            [MethodImpl(Inline)]
            get => ref Pattern.OpDetails;
        }

        /// <summary>
        /// Specifies the asm source text of the current instruction
        /// </summary>
        public ref readonly asci64 AsmText
        {
            [MethodImpl(Inline)]
            get => ref AsmInfo.Asm;
        }

        /// <summary>
        /// Specifies the IP of the current instruction
        /// </summary>
        public ref readonly MemoryAddress IP
        {
            [MethodImpl(Inline)]
            get => ref AsmInfo.IP;
        }

        /// <summary>
        /// Specifies the encoding of the current instruction
        /// </summary>
        public ref readonly AsmHexCode Encoding
        {
            [MethodImpl(Inline)]
            get => ref AsmInfo.Encoded;
        }
    }
}