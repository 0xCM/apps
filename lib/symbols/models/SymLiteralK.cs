//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SymLiteral<K> : IComparableRecord<SymLiteral<K>>
    {
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
        public SymExpr<K> Symbol;

        /// <summary>
        /// The literal's primitive classifier
        /// </summary>
        public ClrPrimitiveKind DataType;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        public SymVal Value;

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
        public int CompareTo(SymLiteral<K> src)
            => Identity.CompareTo(src.Identity);
    }
}