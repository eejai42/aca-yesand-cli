using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using dc = EAPI.CLI.Lib.DataClasses;
using System.Collections.Generic;


namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {
        public string RoutingKey { get; set; }
        
        private StandardPayload(SMQActorBase actor, string content, bool final)
        {
            this.PayloadId = Guid.NewGuid().ToString();

            this.__Actor = actor;
            if (!ReferenceEquals(this.__Actor, null))
            {
                this.SenderId = actor.SenderId.ToString();
                this.SenderName = actor.SenderName;
                this.AccessToken = actor.AccessToken;
            }
            else
            {
                this.SenderId = Guid.NewGuid().ToString();
                this.SenderName = "Unnamed Actor";
                this.AccessToken = null;
            }

            this.Content = content;
        }

        // 11 odxml properties
        
        public String EpisodeHostId { get; set; }
        
        public dc.EpisodeHost EpisodeHost { get; set; }
        
        public List<dc.EpisodeHost> EpisodeHosts { get; set; }
        
        public String FallacyId { get; set; }
        
        public dc.Fallacy Fallacy { get; set; }
        
        public List<dc.Fallacy> Fallacies { get; set; }
        
        public String TopicAgreementId { get; set; }
        
        public dc.TopicAgreement TopicAgreement { get; set; }
        
        public List<dc.TopicAgreement> TopicAgreements { get; set; }
        
        public String CallTopicId { get; set; }
        
        public dc.CallTopic CallTopic { get; set; }
        
        public List<dc.CallTopic> CallTopics { get; set; }
        
        public String EpisodeCallId { get; set; }
        
        public dc.EpisodeCall EpisodeCall { get; set; }
        
        public List<dc.EpisodeCall> EpisodeCalls { get; set; }
        
        public String OpenIssueId { get; set; }
        
        public dc.OpenIssue OpenIssue { get; set; }
        
        public List<dc.OpenIssue> OpenIssues { get; set; }
        
        public String CallParticipantId { get; set; }
        
        public dc.CallParticipant CallParticipant { get; set; }
        
        public List<dc.CallParticipant> CallParticipants { get; set; }
        
        public String PersonId { get; set; }
        
        public dc.Person Person { get; set; }
        
        public List<dc.Person> People { get; set; }
        
        public String ShowSeasonId { get; set; }
        
        public dc.ShowSeason ShowSeason { get; set; }
        
        public List<dc.ShowSeason> ShowSeasons { get; set; }
        
        public String ShowId { get; set; }
        
        public dc.Show Show { get; set; }
        
        public List<dc.Show> Shows { get; set; }
        
        public String SeasonEpisodeId { get; set; }
        
        public dc.SeasonEpisode SeasonEpisode { get; set; }
        
        public List<dc.SeasonEpisode> SeasonEpisodes { get; set; }
        
        
        public String ToJSON() 
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private void HandleReplyTo(object sender, PayloadEventArgs e)
        {
            if (e.Payload.IsHandled && e.BasicDeliverEventArgs.BasicProperties.CorrelationId == this.PayloadId)
            {
                this.ReplyPayload = e.Payload;
                this.ReplyBDEA = e.BasicDeliverEventArgs;
                this.ReplyRecieved = true;
            }
        }

       
        public Task WaitForReply(PayloadHandler payloadHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var actor = this.__Actor;
            if (ReferenceEquals(actor, null)) throw new Exception("Can't handle response if payload.Actor is null");
            else
            {
                actor.ReplyTo += this.HandleReplyTo;
                var waitTask = System.Threading.Tasks.Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (waitTimeout > 0 && !ReferenceEquals(payloadHandler, null))
                        {

                            this.TimedOutWaiting = false;
                            var startedAt = DateTime.Now;

                            while (!this.ReplyRecieved && !this.TimedOutWaiting && DateTime.Now < startedAt.AddSeconds(waitTimeout))
                            {
                                Thread.Sleep(100);
                            }

                            if (!this.ReplyRecieved) this.TimedOutWaiting = true;

                            var errorMessageReceived = !ReferenceEquals(this.ReplyPayload, null) && !String.IsNullOrEmpty(this.ReplyPayload.ErrorMessage);

                            if (this.ReplyRecieved && (!errorMessageReceived || ReferenceEquals(timeoutHandler, null)))
                            {
                                this.ReplyPayload.__Actor = actor;
                                payloadHandler(this.ReplyPayload, this.ReplyBDEA);
                            }
                            else if (!ReferenceEquals(timeoutHandler, null)) timeoutHandler(this.ReplyPayload, default(BasicDeliverEventArgs));
                        }

                    }
                    finally
                    {
                        actor.ReplyTo -= this.HandleReplyTo;
                    }
                });
                return waitTask;
            }
        }
    }
}