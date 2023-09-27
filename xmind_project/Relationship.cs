using System;

namespace xmind_project
{
    public class Relationship
    {
        private Guid id;
        private Guid idEnd1;
        private Guid idEnd2;
        private string title;

        public Relationship(string title, Guid endId, Guid startId)
        {
            id = Guid.NewGuid();
            this.title = title;
            this.idEnd2 = endId;
            this.idEnd1 = startId;
        }
    }
}