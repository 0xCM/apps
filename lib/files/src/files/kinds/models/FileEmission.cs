//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a file emission payload
    /// </summary>
    public readonly struct FileEmission
    {
        /// <summary>
        /// The emission target
        /// </summary>
        public FS.FilePath Target {get;}

        public Count Count {get;}

        [MethodImpl(Inline)]
        public FileEmission(FS.FilePath target, Count count)
        {
            Target = target;
            Count = count;
        }

        public bool Succeeded
        {
            [MethodImpl(Inline)]
            get => Count >= 0;
        }
    }
}