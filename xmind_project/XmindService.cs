using System;
using System.Collections.Generic;
using System.Linq;

namespace xmind_project

{
    public class XmindService
    {
        private readonly int _maxFloatingTopicNumber = 100;
        private readonly int _defaultTopicNumber = 4;
        private readonly int _defaultSpaceFromMain2Central = 1;
        private readonly double _defaultSpaceFromMain2MainTopic = 1.0;
        private readonly string _defaultTitleMainTopic = "Main Topic";
        private readonly string _defaultFloatingTopic = "Floating Topic";
        private readonly string _defaultSubTopic = "Sub Topic";
       
        private readonly string _defaultRelationshipTitle = "relationship";
        private readonly int _defaultSubTopicNumber = 3;
       
        private Root _root;
        private Children _topic;
        private Children _subtopic;

        public XmindService()
        {
        }

        public Root CreateDefaultXmind()
        {
            _root = new Root("Central Topic");
            _root.SetHeight(_root, 2.0);
            _root.SetWidth(_root, 5.0);
            CreateDefaultTopic(_root, _defaultTopicNumber);       
            return _root;
        }
        public void CreateDefaultTopic(Root _root, int _defaultTopicNumber)
        {
            for (int i = 0; i < _defaultTopicNumber; i++)
            {
                _topic = new Children(_defaultTitleMainTopic + " " + (i + 1));
                _root.SetHeight(_topic, 1.0);
                _root.SetWidth(_topic, 3.0);
                _root.AddAttechedChildren(_topic);
            }
        
            int rightSideNumberOfTopics = _defaultTopicNumber / 2;
            if (rightSideNumberOfTopics % 2 == 0)
            {
                SetPositionForEvenTopicNumber(rightSideNumberOfTopics);
            }
            var ListOfChild = _root.GetAttachedChildren();
            double x = _root.GetWidth() / 2.0 + _defaultSpaceFromMain2Central;

            for (int u = 0; u < rightSideNumberOfTopics; u++)
            {
                Equals(ListOfChild[u].GetPosition().SetNewXPosition(x));                          
            }

            for (int q = (rightSideNumberOfTopics); q < _defaultTopicNumber; q++)
            {
                Equals(ListOfChild[q].GetPosition().SetNewXPosition(-x));              
            }
            SetYPosition(_root);
            
        }

      
        

        private void SetPositionForEvenTopicNumber(int rightSideNumberOfTopics)
        {
            var ListOfChild = _root.GetAttachedChildren();
            double x = (_root.GetWidth()) / 2.0 + _defaultSpaceFromMain2Central;
            
            for (int u = 0; u <= rightSideNumberOfTopics; u++)
            {
                Equals(ListOfChild[u].GetPosition().SetNewXPosition(x));
            }

            for (int q = rightSideNumberOfTopics + 1; q < _defaultTopicNumber; q++)
            {
                Equals(ListOfChild[q].GetPosition().SetNewXPosition(-x));
                
            }
            SetYPosition(_root);
        }
        
        public void SetYPosition(Root child)
        {
            double rightSideNumberOfTopics = _defaultTopicNumber / 2;
            double defaultYposition = _defaultSpaceFromMain2MainTopic + (_root.GetHeight() / 2.0);
            double firstYvalue = defaultYposition * (rightSideNumberOfTopics / 2);
            foreach (var _attachedChildren in _root.GetAttachedChildren())
            {
                if (!IsFirstChild(_attachedChildren))
                {
            var previousY = child.GetPreviousChild(child,_attachedChildren)
                        .GetPosition().GetY();              
            _attachedChildren.GetPosition().SetNewYPosition(previousY+1);
                }                                               
                _root.GetAttachedChildren().First().GetPosition()
                .SetNewYPosition(firstYvalue);
                _root.GetAttachedChildren().Count();
                
            }    
        }
        public bool IsFirstChild(Children child)
        {
            if (child.GetId() == _root.GetAttachedChildren().First().GetId()) 
            {
                return true;
            }
                return false;
        }

        public double GetdefaultSpaceFromMain2MainTopic()
        {
            return _defaultSpaceFromMain2MainTopic;
        }
        public void CreateFloatingTopic(int _maxFloatingTopicNumber)
        {
            for (int i = 0; i < _maxFloatingTopicNumber; i++)
            {
                var topic = new Children(_defaultFloatingTopic);
                _root.AddDetachedChildren(topic);
            }

        }
        public bool CreateTopic()
        {
            var topic = new Children(_defaultFloatingTopic);
            _root.AddAttechedChildren(topic);
            return true;
        }
        public int GetMaxFloatingTopicNumber()
        {
            return _maxFloatingTopicNumber;
        }
        public int GetDefaultMainTopic()
        {
            return _defaultTopicNumber;
        }
        public void Deleting(Guid id)
        {
            var topic = _root.GetAttachedChildren().Where(x => x.GetId() == id).FirstOrDefault();
            if (topic != null)
            {
                _root.DeletingAttached(topic);
            }
        }
        public void Renaming(Guid id, string newname)
        {
            var topic = _root.GetAttachedChildren().Where(x => x.GetId() == id).FirstOrDefault();
            if (topic != null)
            {
                _root.RenamingAttached(topic, newname);
            }
        }
        public void DeleteAllNodes(Root _root)
        {
            var AttachedTopic = _root.GetAttachedChildren();
            var DetachedTopic = _root.GetDetachedChildren();
            if (AttachedTopic != null && DetachedTopic != null)
            {
                _root.DeleteAllAttached();
                _root.DeleteAllDetached();
            }
        }
        public void LinkNode(Root _root, Guid id)
        {
            var node = _root.GetDetachedChildren().Where(x => x.GetId() == id).FirstOrDefault();
            if (node != null)
            {
                _root.DeleteDetachedNode(node);
                _root.AddAttechedChildren(node);
            }
        }
        public void LinkDeToDe(Root _root, Guid id)
        {
            var node = _root.GetDetachedChildren().Where(x => x.GetId() == id).FirstOrDefault();
            if (node != null)
            {
                _root.DeleteDetachedNode(node);
                _root.AddAttechedChildren(node);
            }
        }
        public int GetTotalNodes(Root _root)
        {
            var AttachedNodes = _root.GetAttachedChildren().Count();
            var DetachedNodes = _root.GetDetachedChildren().Count();
            var totalNodes = AttachedNodes + DetachedNodes;
            return totalNodes;
        }
        public void CreateMultiple(Root _root)
        {
            var AttachedNodes = _root.GetAttachedChildren().Count();
            var DetachedNodes = _root.GetDetachedChildren().Count();
            var totalNodes = AttachedNodes + DetachedNodes;
            for (int i = 0; i <= totalNodes; i++)
            {
                var topic = new Children(_defaultSubTopic);
                _root.AddAttechedChildren(topic);
            }
        }
        public List<Relationship> CreateNodeRelationship(Guid StartId, Guid EndId)
        {
            
            var node = _root.GetDetachedChildren().Where(x => x.GetId() == EndId).FirstOrDefault();
            var rootnode = _root.GetAttachedChildren().Where(x => x.GetId() == StartId).FirstOrDefault();

            if (node != null && rootnode != null)
            {
                var title = _defaultRelationshipTitle;
                var relationship = new Relationship(title, EndId, StartId);
                
                rootnode.AddRelationship(relationship);
            }
            return rootnode.GetRelationship();
        }

        public Root GetRoot()
        {
            return _root;
        }

        public Position MovingNode(Children node, int x, int y)
        {
           return node.SetNewPosition(x, y);
        }

        public List<Relationship> CreateNodeRelationship(Guid StartId)
        {
            var rootnode = _root.GetDetachedChildren().Where(x => x.GetId() == StartId).FirstOrDefault();        

            CreateFloatingTopic(1);
            var node = _root.GetDetachedChildren().Last();
               
            Guid EndId = node.GetId();
            var title = _defaultRelationshipTitle;
            var relationship = new Relationship(title, EndId, StartId);
            rootnode.AddRelationship(relationship);
            return rootnode.GetRelationship();
        }

        public List<Relationship> CreateNodeRelationship()
        {
            CreateFloatingTopic(1);
            var rootchild = _root.GetDetachedChildren().First();
            Guid StartId = rootchild.GetId();
            
            var lists = CreateNodeRelationship(StartId);
            rootchild.AddRelationships(lists);
            return rootchild.GetRelationship();
        }

        
    }
}