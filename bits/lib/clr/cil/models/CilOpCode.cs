// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0
{
    using System;
    using System.Reflection.Metadata;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static Cil;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct CilOpCode : IRecord<CilOpCode>
    {
        public const string TableId ="cil.opcodes";

        public const byte FieldCount = 7;

        public ILOpCode OpCode;

        public StringAddress Name;

        public OpCodeType CodeType;

        public OperandType ArgType;

        public byte ArgCount;

        public StackBehaviour Sb1;

        public StackBehaviour Sb2;

        [MethodImpl(Inline)]
        public CilOpCode(ILOpCode id, StringAddress name, OpCodeType type, OperandType optype, byte opcount, StackBehaviour sb1, StackBehaviour sb2)
        {
            OpCode = id;
            Name = name;
            CodeType = type;
            ArgType =  optype;
            ArgCount = opcount;
            Sb1 = sb1;
            Sb2 = sb2;
        }
    }
}