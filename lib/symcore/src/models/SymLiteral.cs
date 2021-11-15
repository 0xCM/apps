//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymLiteral : IComparableRecord<SymLiteral>
    {
        public const string TableId = "symbolic.literals";

        /// <summary>
        /// The component that defines the literal
        /// </summary>
        public ClrAssemblyName Component;

        /// <summary>
        /// The literal's declaring type
        /// </summary>
        public Identifier Type;

        /// <summary>
        /// A literal classifier
        /// </summary>
        public SymClass Class;

        /// <summary>
        /// The container-relative declaration order of the literal
        /// </summary>
        public ushort Position;

        /// <summary>
        /// The literal name
        /// </summary>
        public string Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        public SymExpr Symbol;

        /// <summary>
        /// The literal's primitive classifier
        /// </summary>
        public PrimalKind DataType;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        public ulong ScalarValue;

        /// <summary>
        /// Indicates whether the literal is occluded
        /// </summary>
        public bool Hidden;

        /// <summary>
        /// The meaning of the literal, if available; otherwise empty
        /// </summary>
        public TextBlock Description;

        /// <summary>
        /// A unique identifier
        /// </summary>
        public SymIdentity Identity;

        [MethodImpl(Inline)]
        public int CompareTo(SymLiteral src)
            => Identity.CompareTo(src.Identity);
    }
}