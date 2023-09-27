using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace xmind_project
{
    public class BaseNode
    {
        private List<Children> _attachedChildren;

        public BaseNode()
        {
            Id = Guid.NewGuid();

        }
        public BaseNode(string title)
        {
            this.Title = title;
            Position = new Position(0, 0);
            Id = Guid.NewGuid();
        }

        private Guid Id { get; set; }
        private Position Position { get; set; }
        private string Title { get; set; } = string.Empty;
        private double Width { get; set; }
        private double Height { get; set; }
        private List<Relationship> RelationshipList { get; set; }
        public Guid GetId()
        {
            return Id;
        }

        public Position GetPosition() 
        {
            return Position;
        } 
         
       

        public string GetTitle()
        {  
            return Title; 
        }

        public double GetHeight() 
        {
            return Height;
        }
        public double GetWidth() 
        {
            return Width;
        }
        public void AddAttechedChildren(Children _topic)
        {
            if (_attachedChildren == null)
            {
                _attachedChildren = new List<Children>();
            }
            _attachedChildren.Add(_topic);
        }
        public void SetHeight(Children topic, double x)
        {
            topic.Height = x;                       
        }
        public void SetWidth(Children topic, double x)
        {
            topic.Width = x;
        }

        public void SetHeight(Root _root, double x)
        {
           _root.Height = x;       
        }
        public void SetWidth(Root _root, double x)
        {
          _root.Width = x;
        }       
        public void DeletingAttached(Children topic)
        {
            _attachedChildren.Remove(topic);
        }
       

        public void RenamingAttached(Children topic, string newname)
        { 
             topic.Title = newname;              
        }

        public void DeleteAllAttached()
        {
            _attachedChildren.Clear();
        }

        public List<Children> GetAttachedChildren()
        {
            return _attachedChildren;
        }
        public Children GetPreviousChild(Root child, Children attachedChildren)
        {          
            int x = child.GetAttachedChildren().IndexOf(attachedChildren);
            return _attachedChildren[x-1];
        }
        public void AddRelationship(Relationship relationship)
        {
            if (RelationshipList == null)
            {
                RelationshipList = new List<Relationship>();
            }
            RelationshipList.Add(relationship);
        }
        public List<Relationship> GetRelationship()
        {
           return RelationshipList;
        }

        public Position SetNewPosition(double x, double y)
        {
           return Position.SetNewPosition(x, y);
        }

        public void AddRelationships(List<Relationship> lists)
        {
            RelationshipList = lists;
        }
        
    }
}