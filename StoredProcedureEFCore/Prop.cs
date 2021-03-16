using System;

namespace StoredProcedureEFCore
{
    internal struct Prop
    {
        public bool AcceptsNull { get; set; }
        public int ColumnOrdinal { get; set; }
        public Action<object, object> Setter { get; set; }
    }
}
