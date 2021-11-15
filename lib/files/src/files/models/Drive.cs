//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct FS
    {
        public readonly struct Drive : IFsEntry<Drive>
        {
            public DriveLetter Name {get;}

            PathPart IFsEntry.Name
                => new PathPart(Name.ToString());

            [MethodImpl(Inline)]
            public Drive(DriveLetter name)
                => Name = name;

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Name == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Name != 0;
            }

            [MethodImpl(Inline)]
            public string Format()
                => Name.ToString();

            [MethodImpl(Inline)]
            public static implicit operator Drive(DriveLetter src)
                => new Drive(src);


            public static Drive Empty => default;
        }
    }
}