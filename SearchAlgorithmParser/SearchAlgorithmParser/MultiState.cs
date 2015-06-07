using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmParser
{
    public class MultiState<T> : HashSet<T>
    {
        public IMultiStateView<T> View { get; set; }

        public MultiState(IMultiStateView<T> view) : base()
        {
            this.View = view;
        }

        public MultiState(IEnumerable<T> collection, IMultiStateView<T> view)
            : base(collection)
        {
            this.View = view;
        }

        public MultiState(IEqualityComparer<T> comparer, IMultiStateView<T> view)
            : base(comparer)
        {
            this.View = view;
        }

        public MultiState(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context, IMultiStateView<T> view)
            : base(info, context)
        {
            this.View = view;
        }

        public MultiState(IEnumerable<T> collection, IEqualityComparer<T> comparer, IMultiStateView<T> view)
            : base(collection, comparer)
        {
            this.View = view;
        }

        public override bool Equals(object obj)
        {
            MultiState<T> state = obj as MultiState<T>;
            if(state == null)
                    return false;
            return state.SetEquals(this);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override string ToString()
        {
            if(this.View == null)
                return "";

            return this.View.GetString(this);
        }
    }
}
