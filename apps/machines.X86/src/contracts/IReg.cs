//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using Asm;
    using System;

    using static core;

    /// <summary>
    /// Characterizes a register representation
    /// </summary>
    public interface IReg : ITextual
    {
        /// <summary>
        /// The register's kind classifier
        /// </summary>
        RegKind RegKind {get;}

        RegIndexCode Index
            => (RegIndexCode)((byte)RegKind);
    }

    public interface IReg<T> : IReg, IContented<T>
        where T : unmanaged
    {
        ReadOnlySpan<byte> Value
            => bytes((T)this);

        T IContented<T>.Content
            => first(recover<T>(Value));

        NativeSizeCode Width
            => (NativeSizeCode)(ushort)core.width<T>();

        string ITextual.Format()
            => X86.RegModels.format(this);
    }

    /// <summary>
    /// Characterizes a width-parametric register operand reification
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="W">The register width</typeparam>
    public interface IReg<W,T> : IReg<T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }
    public interface IReg512<T> : IReg<W512,T>
        where T : unmanaged
    {

    }

    public interface IReg512<H,T> : IReg512<T>
        where H : struct, IReg512<H,T>
        where T : unmanaged
    {

    }

    /// <summary>
    /// Characterizes a width-parametric and state-parametric register operand reification
    /// </summary>
    /// <typeparam name="F">The reifying type</typeparam>
    /// <typeparam name="W">The register width</typeparam>
    public interface IReg<F,W,T> : IReg<W,T>
        where F : struct, IReg<F,W,T>
        where W : unmanaged, IDataWidth
        where T : unmanaged
    {

    }
}