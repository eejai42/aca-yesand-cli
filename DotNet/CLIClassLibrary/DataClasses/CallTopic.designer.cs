using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace EAPI.CLI.Lib.DataClasses
{                            
    public partial class CallTopic
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallTopicId")]
        public String CallTopicId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Notes")]
        public String Notes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Attachments")]
        public AirtableAttachment[] Attachments { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Status")]
        public String Status { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EpisodeCall")]
        [RemoteIsCollection]
        public String EpisodeCall { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Subject")]
        public String Subject { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ParentTopic")]
        [RemoteIsCollection]
        public String ParentTopic { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SeasonEpisode")]
        [RemoteIsCollection]
        public String SeasonEpisode { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "AutoNumber")]
        public String AutoNumber { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ParentTopicSubject")]
        [RemoteIsCollection]
        public String ParentTopicSubject { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticipant")]
        [RemoteIsCollection]
        public String CallParticipant { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TopicAgreement")]
        [RemoteIsCollection]
        public String[] TopicAgreement { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticpants")]
        [RemoteIsCollection]
        public String CallParticpants { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallStartTime")]
        [RemoteIsCollection]
        public Nullable<DateTime> CallStartTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CreatedTime")]
        public Nullable<DateTime> CreatedTime { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Timstamp")]
        public Nullable<decimal> Timstamp { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "EpisodeCalls")]
        [RemoteIsCollection]
        public String[] EpisodeCalls { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticipantDisplayNames")]
        [RemoteIsCollection]
        public String CallParticipantDisplayNames { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticipantsDisplayNames")]
        [RemoteIsCollection]
        public String CallParticipantsDisplayNames { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticipantDisplayName")]
        [RemoteIsCollection]
        public String CallParticipantDisplayName { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CallParticipantAvatar")]
        [RemoteIsCollection]
        public AirtableAttachment[] CallParticipantAvatar { get; set; }
    

        

        
        
        
    }
}
