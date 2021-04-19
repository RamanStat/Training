using System.Collections.Generic;

namespace Training.SDK.DTO
{
    public class BulkDTO
    {
        public IList<int> ProducersIds = new List<int>();
        public IList<string> Models = new List<string>();
        public IList<int> IssueYears = new List<int>();
    }
}
