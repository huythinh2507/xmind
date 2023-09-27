using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace xmind_project
{
    public class Root : BaseNode 
    {
        private List<Children> _detachedChildren;
        public BaseNode basenode;
        public Children Children { get; set; }
        public Root(string title) : base(title) { } 
        public List<Children> children { get; internal set; }


        public void AddDetachedChildren(Children topic)
        {
            if(_detachedChildren == null)
            { 
                _detachedChildren = new List<Children>();          
            }
            _detachedChildren.Add(topic);
        }

        public List<Children> GetDetachedChildren()
        {
            return _detachedChildren;
        }
       
        public void DeleteAllDetached()
        {
            _detachedChildren.Clear();
        }

        internal void DeleteDetachedNode(Children node)
        {
            _detachedChildren.Remove(node);
        }

       
    }
}
