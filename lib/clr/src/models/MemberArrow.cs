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
    /// Defines a directed association between two data members
    /// </summary>
    public class MemberArrow : IArrow<ClrMember>
    {
        /// <summary>
        /// The supplier member
        /// </summary>
        public ClrMember Source {get;}

        /// <summary>
        /// The client member
        /// </summary>
        public ClrMember Target {get;}

        const string MemberFormat = "{0}[{1}]";

        public string IdentityText
            => string.Format(RP.Arrow,
                string.Format(MemberFormat, Source.Name, Source.Token),
                string.Format(MemberFormat, Target.Name, Target.Token)
                );

        [MethodImpl(Inline)]
        public MemberArrow(ClrMember s, ClrMember t)
        {
            Source = s;
            Target = t;
        }

        public string Format()
            => IdentityText;


        public override string ToString()
            => Format();


        [MethodImpl(Inline)]
        public static implicit operator MemberArrow((MemberInfo src, MemberInfo dst) a)
            => new MemberArrow(a.src, a.dst);
    }
}