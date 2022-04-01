//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpAspectKind : ushort
        {
            None = 0,

            /// <summary>
            /// Indicates an operand index value
            /// </summary>
            Index = 1,

            /// <summary>
            /// Indicates a <see cref='XedRegId'/> value
            /// </summary>
            Reg = 2,

            /// <summary>
            /// Indicates a <see cref='OpAction'/> value
            /// </summary>
            Action = 4,

            /// <summary>
            /// Indicates a <see cref='OpVisibility'/> value
            /// </summary>
            Visibilty = 8,

            /// <summary>
            /// Indicates a <see cref='OpType'/> value
            /// </summary>
            Type = 16,

            /// <summary>
            /// Indicates a <see cref='OpWidthCode'/> value
            /// </summary>
            Width = 32,

            /// <summary>
            /// Indicates a <see cref='ElementKind'/> value
            /// </summary>
            EType = 64,

            /// <summary>
            /// Indicates a <see cref='NontermKind'/> value
            /// </summary>
            NT = 128,
        }
    }
}