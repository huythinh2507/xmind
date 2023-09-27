using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace xmind_project
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Xmind_Init()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateDefaultXmind();
            
            Assert.IsNotNull(root);
            Assert.AreEqual(4, root.GetAttachedChildren().Count);
        }

        [TestMethod]
        public void Create_FloatingTopic()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateDefaultXmind();
            var defaultFloatingTopicNumber = xmindService.GetMaxFloatingTopicNumber();
            xmindService.CreateFloatingTopic(defaultFloatingTopicNumber);
            Assert.AreEqual(defaultFloatingTopicNumber, root.GetDetachedChildren().Count);
        }

        [TestMethod]
        public void Creating_AttachedTopic()
        {  
            var xmindService = new XmindService();
            var root = xmindService.CreateDefaultXmind();
            Assert.AreEqual(4, root.GetAttachedChildren().Count);

            var result = xmindService.CreateTopic();

            Assert.IsNotNull(result);
            Assert.IsTrue(result);
            Assert.AreEqual(5, root.GetAttachedChildren().Count);
        }

        [TestMethod]
        public void Test_Xmind_Delete_Node()
        {
            var xmindService = new XmindService();
            var root = xmindService.CreateDefaultXmind();
            var firstTopic = root.GetAttachedChildren().FirstOrDefault();

            xmindService.Deleting(firstTopic.GetId());

            Assert.AreEqual(3, root.GetAttachedChildren().Count);
        }

        [TestMethod]
        public void Renaming()
        {          
            var xmindService = new XmindService();
            var root = xmindService.CreateDefaultXmind();
            var firstTitle = root.GetAttachedChildren().FirstOrDefault();
            string newname = "new";
            xmindService.Renaming(firstTitle.GetId(), newname);
            var newTitle = root.GetAttachedChildren().FirstOrDefault();
            Assert.AreEqual(newname, newTitle.GetTitle());
        }

        [TestMethod]
        public void DeleteAllNodes()
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();
            xmindService.CreateTopic();
            xmindService.CreateFloatingTopic(5);

            xmindService.DeleteAllNodes(_root);
            
            var result = xmindService.GetTotalNodes(_root);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LinkDetachedtoAttachedNode()
        {  var xmindService = new XmindService();
           var _root = xmindService.CreateDefaultXmind();
           int numberOfFloatingTopic = 2;
           xmindService.CreateFloatingTopic(numberOfFloatingTopic);        
           var child = _root.GetDetachedChildren().FirstOrDefault();

           xmindService.LinkNode(_root, child.GetId());

           var result1 = _root.GetDetachedChildren().Count();
           Assert.AreEqual(1, result1);
        }

        [TestMethod]
        public void LinkDetachedtoDetachedNode() 
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();
            xmindService.CreateFloatingTopic(2);
            var child = _root.GetDetachedChildren().FirstOrDefault();

            xmindService.LinkDeToDe(_root, child.GetId());
            var result = _root.GetDetachedChildren().Count();
            var result1 = _root.GetAttachedChildren().Count();
            Assert.AreEqual(1, result);
            Assert.AreEqual(5, result1);
        }

        [TestMethod]
        public void CreateMultipleTopicsAtOnce()
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();

            int numberOfFloatingTopic = 1;
            xmindService.CreateFloatingTopic(numberOfFloatingTopic);
            
            xmindService.CreateMultiple(_root);

            var totalNodes = xmindService.GetTotalNodes(_root);

            Assert.AreEqual(totalNodes-numberOfFloatingTopic, 
                _root.GetAttachedChildren().Count());
        }

        [TestMethod]    
        public void CreateRelationship() 
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();

            xmindService.CreateFloatingTopic(1);

            var child = _root.GetDetachedChildren().FirstOrDefault().GetId();
            var rootChild = _root.GetAttachedChildren().FirstOrDefault().GetId();
            var result = xmindService.CreateNodeRelationship(child, rootChild);
            
            Assert.AreEqual(1,result.Count());    
        }

        [TestMethod]
        public void MovingNode()
        {
            var xmindService = new XmindService();
            xmindService.CreateDefaultXmind();
            xmindService.CreateFloatingTopic(1);
            var _root = xmindService.GetRoot();
            var node = _root.GetDetachedChildren().FirstOrDefault();
          
            var result = xmindService.MovingNode(node,2,3);

            Assert.AreEqual(2 ,result.GetX());
            Assert.AreEqual(3 ,result.GetY());
        }

        [TestMethod]

        public void CreateRelationshipWith1RootNode()
        {  
            var xmindService = new XmindService(); 
            var _root = xmindService.CreateDefaultXmind();
            xmindService.CreateFloatingTopic(1);
            var rootchild = _root.GetDetachedChildren().FirstOrDefault();
            var result = xmindService.CreateNodeRelationship(rootchild.GetId());
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void CreateRelationshipWith0RootNode() 
        { 
            var xmindService = new XmindService();
            xmindService.CreateDefaultXmind();
            var result = xmindService.CreateNodeRelationship();
            Assert.AreEqual(1, result.Count());
        }
        [TestMethod]
        public void DrawXmind()     
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();
            var x_First_position = _root.GetAttachedChildren().FirstOrDefault().GetPosition().GetX();
            var y_Firtstposition = _root.GetAttachedChildren().FirstOrDefault().GetPosition().GetY();
            
            var x_Last = _root.GetAttachedChildren().Last().GetPosition().GetX();
            var y_last = _root.GetAttachedChildren().Last().GetPosition().GetY();

            var no_SpaceBetweenFirstAndLast = xmindService.GetDefaultMainTopic() - 1;

            // x = defaultSpaceFromMain2MainTopic
            var x = xmindService.GetdefaultSpaceFromMain2MainTopic(); 
            // Test X position
            Assert.AreEqual(x_First_position, -x_Last); 
            // Test y position
           // Assert.AreEqual(8,(x*no_SpaceBetweenFirstAndLast) + y_last);            
        }    

        public void TestSubtopicPosition()
        {
            var xmindService = new XmindService();
            var _root = xmindService.CreateDefaultXmind();
          


        }
    }
}
