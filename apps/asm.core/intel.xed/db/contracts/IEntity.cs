//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        public interface IElement
        {

        }

        public interface IColDataType
        {


        }

        public interface IElement<T> : IEquatable<T>, IComparable<T>
            where T : IElement<T>
        {

        }

        public interface IColDataType<T> : IColDataType, IElement<T>
            where T : IElement<T>
        {

        }

        public interface IEntity<T> : IElement<T>
            where T : IEntity<T>
        {
            ref readonly Index<Relation> Rels {get;}
        }

        public interface ITableDef<T> : IElement<T>
            where T : ITableDef<T>
        {
            Index<ColDef> Cols {get;}

        }
        public interface ITable<T> : IElement<T>
            where T : ITable<T>
        {
        }

        public interface IRow<T>  : IElement<T>
            where T : IRow<T>
        {

        }
    }
}