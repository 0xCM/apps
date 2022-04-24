//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Char5
    {
        [MethodImpl(Inline)]
        static Char5 define(byte b)
            => new Char5(b);

        public static Char5 _ => define(1);

        public static Char5 a => define(A);

        public static Char5 b => define(A + 1);

        public static Char5 c => define(A + 2);

        public static Char5 d => define(A + 3);

        public static Char5 e => define(A + 4);

        public static Char5 f => define(A + 5);

        public static Char5 g => define(A + 6);

        public static Char5 h => define(A + 7);

        public static Char5 i => define(A + 8);

        public static Char5 j => define(A + 9);

        public static Char5 k => define(A + 10);

        public static Char5 l => define(A + 11);

        public static Char5 m => define(A + 12);

        public static Char5 n => define(A + 13);

        public static Char5 o => define(A + 14);

        public static Char5 p => define(A + 15);

        public static Char5 q => define(A + 16);

        public static Char5 r => define(A + 17);

        public static Char5 s => define(A + 18);

        public static Char5 t => define(A + 19);

        public static Char5 u => define(A + 20);

        public static Char5 v => define(A + 21);

        public static Char5 w => define(A + 22);

        public static Char5 x => define(A + 23);

        public static Char5 y => define(A + 24);

        public static Char5 z => define(A + 25);
    }
}