//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct PathVar
    {
        public VarName Name {get;}

        FS.FilePath _Value;

        [MethodImpl(Inline)]
        public PathVar(VarName name)
        {
            Name = name;
            _Value = FS.FilePath.Empty;
        }

        [MethodImpl(Inline)]
        public PathVar(VarName name, FS.FilePath value)
        {
            Name = name;
            _Value = value;
        }

        [MethodImpl(Inline)]
        public FS.FilePath Value()
            => _Value;

        [MethodImpl(Inline)]
        public PathVar Assign(FS.FilePath src)
        {
            _Value = src;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator PathVar(string name)
            => new PathVar(name);

        [MethodImpl(Inline)]
        public static implicit operator PathVar(VarName name)
            => new PathVar(name);
    }
}