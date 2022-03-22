//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [DataWidth(4)]
        public enum OpAspectIndex : byte
        {
            None = 0,

            /// <summary>
            /// Indicates an operand index value
            /// </summary>
            Index = 1,

            /// <summary>
            /// Indicates a <see cref='XedRegId'/> value
            /// </summary>
            Reg,

            /// <summary>
            /// Indicates a <see cref='OpAction'/> value
            /// </summary>
            Action,

            /// <summary>
            /// Indicates a <see cref='OpVisibility'/> value
            /// </summary>
            Visibilty,

            /// <summary>
            /// Indicates a <see cref='OpType'/> value
            /// </summary>
            Type,

            /// <summary>
            /// Indicates a <see cref='OpWidthCode'/> value
            /// </summary>
            Width,

            /// <summary>
            /// Indicates a <see cref='ElementKind'/> value
            /// </summary>
            EType,

            /// <summary>
            /// Indicates a <see cref='NontermKind'/> value
            /// </summary>
            NT,
        }
    }
}