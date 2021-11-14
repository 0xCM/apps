//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    using K = AsmLayoutKind;

    public readonly struct AsmLayoutModels
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout0
        {
            public RexPrefix Rex;

            public Hex8 OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public K Kind => K.Rex | K.OpCode | K.ModRm | K.Sib;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout1
        {
            public Hex8 OpCode;

            public K Kind => K.OpCode;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout11
        {
            public EscapePrefix Escape;

            public Hex8 OpCode;

            public K Kind => K.Escape | K.OpCode;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout2
        {
            public Hex8 OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public K Kind => K.OpCode | K.ModRm | K.Sib;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout12
        {
            public EscapePrefix Escape;

            public Hex8 OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public K Kind => K.Escape | K.OpCode | K.ModRm | K.Sib;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout3
        {
            public Hex8 OpCode;

            public ModRm ModRm;

            public K Kind => K.OpCode | K.ModRm;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout4
        {
            public RexPrefix Rex;

            public Hex8 OpCode;

            public ModRm ModRm;

            public K Kind => K.Rex | K.OpCode | K.ModRm;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout7
        {
            public Hex8 OpCode;

            public Disp8 Disp;

            public K Kind => K.OpCode | K.Disp;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout8
        {
            public Hex8 OpCode;

            public Disp16 Disp;

            public K Kind => K.OpCode | K.Disp;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout9
        {
            public Hex8 OpCode;

            public Disp32 Disp;

            public K Kind => K.OpCode | K.Disp;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout6
        {
            public VexPrefix Vex;

            public Hex8 OpCode;

            public ModRm ModRm;

            public Sib Sib;

            public K Kind => K.Vex | K.OpCode | K.ModRm | K.Sib;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct Layout10
        {
            public VexPrefix Vex;

            public Hex8 OpCode;

            public ModRm ModRm;

            public K Kind => K.Vex | K.OpCode | K.ModRm;
        }
    }
}