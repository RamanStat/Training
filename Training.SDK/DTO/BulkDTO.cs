using System.Collections.Generic;

namespace Training.SDK.DTO
{
    public class BulkDTO
    {
        public IList<int> ProducersIds { get; set; }

        public IList<string> Models { get; set; }

        public IList<int> IssueYears { get; set; }
    }
}
