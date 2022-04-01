//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum OpAttribKind : byte
        {
            None = 0,

            /// <summary>
            /// Indicates a <see cref='OpAction'/> value
            /// </summary>
            Action = 1,

            /// <summary>
            /// Indicates a <see cref='OpWidthCode'/> value
            /// </summary>
            Width = 2,

            /// <summary>
            /// Indicates a <see cref='OpVisibility'/> value
            /// </summary>
            Visibilty = 4,

            /// <summary>
            /// Indicates a <see cref='Nonterminal'/> value
            /// </summary>
            NT = 8,

            /// <summary>
            /// Indicates a <see cref='XedRegId'/> value
            /// </summary>
            RegLiteral = 16,

            Scale = 32,

            /// <summary>
            /// Indicates a <see cref='ElementKind'/> value
            /// </summary>
            ElementType = 64,

            Modifier = 128,
        }
    }
}