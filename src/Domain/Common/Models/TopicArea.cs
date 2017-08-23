using System.Collections.Generic;
using Mmu.Khb.Domain.Infrastructure.Invariance;
using Mmu.Khb.Domain.Infrastructure.ModelAbstractions;

namespace Mmu.Khb.Domain.Common.Models
{
    public class TopicArea : AggregateRoot
    {
        public TopicArea(string topicAreaTitle, int topicAreaSequence, IReadOnlyCollection<Topic> topîcs)
        {
            Guard.StringNotNullorEmpty(() => topicAreaTitle);

            TopicAreaTitle = topicAreaTitle;
            TopicAreaSequence = topicAreaSequence;
            Topics = topîcs;
        }

        public int TopicAreaSequence { get; private set; }

        public string TopicAreaTitle { get; private set; }

        public IReadOnlyCollection<Topic> Topics { get; private set; }
    }
}