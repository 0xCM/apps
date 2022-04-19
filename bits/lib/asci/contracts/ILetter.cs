//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Characterizes a letter
    /// </summary>
    public interface ILetter : ITextual
    {
        /// <summary>
        /// The unicode character representation
        /// </summary>
        char Character {get;}
    }

    /// <summary>
    /// Characterizes a letter
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="C"></typeparam>
    public interface ILetter<S,C> : ILetter
        where S : unmanaged
        where C : unmanaged
    {
        S Symbol {get;}

        C Code {get;}

        char ILetter.Character
             => core.c16(Code);

        string ITextual.Format()
            => Character.ToString();
    }

    public interface ILetter<L,S,C> : ILetter<S,C>, IEquatable<L>
        where L : unmanaged, ILetter<L,S,C>
        where S : unmanaged
        where C : unmanaged
    {

    }
}