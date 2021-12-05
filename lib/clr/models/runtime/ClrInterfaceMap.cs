//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    /// <summary>
    /// Captures the content of a <see cref="InterfaceMapping"/>
    /// </summary>
    public struct ClrInterfaceMap : ITextual
    {
        /// <summary>
        /// The methods declared by an interface
        /// </summary>
        public Index<MethodInfo> Specs;

        /// <summary>
        /// The interface type
        /// </summary>
        public Type SpecType;

        /// <summary>
        /// The methods that realize an interface implementation
        /// </summary>
        public Index<MethodInfo> Impl;

        /// <summary>
        /// The type that declares the methods that realize an interface contract
        /// </summary>
        public Type ImplType;

        /// <summary>
        /// The number of interface members
        /// </summary>
        public uint OperationCount
        {
            [MethodImpl(Inline)]
            get => Specs.Count;
        }

        public string Format()
        {
            var buffer = TextTools.buffer();
            Format(buffer);
            return buffer.Emit();
        }

        // https://mattwarren.org/2020/02/19/Under-the-hood-of-Default-Interface-Methods/
        public void Format(ITextBuffer dst)
        {
            dst.AppendLine(string.Format("{0} -> {1}", SpecType.Name, ImplType.Name));
            var count = OperationCount;
            for(var i=0u; i<count; i++)
            {
                ClrMethodAdapter spec = Specs[i];
                ClrMethodAdapter impl = Impl[i];
                dst.AppendLine($"   {spec.DeclaringType}::{spec.Name} --> {impl.DeclaringType}::{impl.Name}");
                dst.AppendLineFormat("       Spec(MethodHandle) {0} --> Impl(MethodHandle) {1}", spec.HandleAddress, impl.HandleAddress);
                dst.AppendLineFormat("       Spec(FunctionPtr) {0} --> Impl(FunctionPtr)  {1}", spec.PointerAddress, impl.PointerAddress);
            }
        }

        public override string ToString()
            => Format();
    }
}