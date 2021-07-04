using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using EAPI.CLI.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class ModeratorCLIHandler
    {
        public override void AddHelp(StringBuilder sb, string helpTerm)
        {
            sb.AppendLine($"Help for Moderator.");
            
            helpTerm = helpTerm.ToLower();
            var found = helpTerm == "general";
            
            if (helpTerm == "general")
            {
                sb.AppendLine();
                
                sb.AppendLine($"EpisodeHost: AddEpisodeHost");
                sb.AppendLine($"EpisodeHost: GetEpisodeHosts");
                sb.AppendLine($"EpisodeHost: UpdateEpisodeHost");
                sb.AppendLine($"void: DeleteEpisodeHost");
                sb.AppendLine($"TopicAgreement: AddTopicAgreement");
                sb.AppendLine($"TopicAgreement: GetTopicAgreements");
                sb.AppendLine($"TopicAgreement: UpdateTopicAgreement");
                sb.AppendLine($"void: DeleteTopicAgreement");
                sb.AppendLine($"CallTopic: AddCallTopic");
                sb.AppendLine($"CallTopic: GetCallTopics");
                sb.AppendLine($"CallTopic: UpdateCallTopic");
                sb.AppendLine($"void: DeleteCallTopic");
                sb.AppendLine($"EpisodeCall: AddEpisodeCall");
                sb.AppendLine($"EpisodeCall: GetEpisodeCalls");
                sb.AppendLine($"EpisodeCall: UpdateEpisodeCall");
                sb.AppendLine($"void: DeleteEpisodeCall");
                sb.AppendLine($"CallParticipant: AddCallParticipant");
                sb.AppendLine($"CallParticipant: GetCallParticipants");
                sb.AppendLine($"CallParticipant: UpdateCallParticipant");
                sb.AppendLine($"void: DeleteCallParticipant");
                sb.AppendLine($"Person: AddPerson");
                sb.AppendLine($"Person: GetPeople");
                sb.AppendLine($"Person: UpdatePerson");
                sb.AppendLine($"void: DeletePerson");
                sb.AppendLine($"ShowSeason: AddShowSeason");
                sb.AppendLine($"ShowSeason: GetShowSeasons");
                sb.AppendLine($"ShowSeason: UpdateShowSeason");
                sb.AppendLine($"void: DeleteShowSeason");
                sb.AppendLine($"Show: AddShow");
                sb.AppendLine($"Show: GetShows");
                sb.AppendLine($"Show: UpdateShow");
                sb.AppendLine($"void: DeleteShow");
                sb.AppendLine($"SeasonEpisode: AddSeasonEpisode");
                sb.AppendLine($"SeasonEpisode: GetSeasonEpisodes");
                sb.AppendLine($"SeasonEpisode: UpdateSeasonEpisode");
                sb.AppendLine($"void: DeleteSeasonEpisode");                                            
            }
            
            sb.AppendLine($"{Environment.NewLine}Available Actions Matching: {helpTerm}");
            
            if ("addepisodehost".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddEpisodeHost");
                if ("addepisodehost".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddEpisodeHostHelp(sb);
                }
                found = true;
            }
            if ("getepisodehosts".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEpisodeHosts");
                if ("getepisodehosts".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEpisodeHostsHelp(sb);
                }
                found = true;
            }
            if ("updateepisodehost".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateEpisodeHost");
                if ("updateepisodehost".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateEpisodeHostHelp(sb);
                }
                found = true;
            }
            if ("deleteepisodehost".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteEpisodeHost");
                if ("deleteepisodehost".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteEpisodeHostHelp(sb);
                }
                found = true;
            }
            if ("addtopicagreement".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddTopicAgreement");
                if ("addtopicagreement".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddTopicAgreementHelp(sb);
                }
                found = true;
            }
            if ("gettopicagreements".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetTopicAgreements");
                if ("gettopicagreements".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetTopicAgreementsHelp(sb);
                }
                found = true;
            }
            if ("updatetopicagreement".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateTopicAgreement");
                if ("updatetopicagreement".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateTopicAgreementHelp(sb);
                }
                found = true;
            }
            if ("deletetopicagreement".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteTopicAgreement");
                if ("deletetopicagreement".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteTopicAgreementHelp(sb);
                }
                found = true;
            }
            if ("addcalltopic".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddCallTopic");
                if ("addcalltopic".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddCallTopicHelp(sb);
                }
                found = true;
            }
            if ("getcalltopics".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetCallTopics");
                if ("getcalltopics".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetCallTopicsHelp(sb);
                }
                found = true;
            }
            if ("updatecalltopic".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateCallTopic");
                if ("updatecalltopic".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateCallTopicHelp(sb);
                }
                found = true;
            }
            if ("deletecalltopic".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteCallTopic");
                if ("deletecalltopic".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteCallTopicHelp(sb);
                }
                found = true;
            }
            if ("addepisodecall".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddEpisodeCall");
                if ("addepisodecall".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddEpisodeCallHelp(sb);
                }
                found = true;
            }
            if ("getepisodecalls".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetEpisodeCalls");
                if ("getepisodecalls".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetEpisodeCallsHelp(sb);
                }
                found = true;
            }
            if ("updateepisodecall".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateEpisodeCall");
                if ("updateepisodecall".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateEpisodeCallHelp(sb);
                }
                found = true;
            }
            if ("deleteepisodecall".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteEpisodeCall");
                if ("deleteepisodecall".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteEpisodeCallHelp(sb);
                }
                found = true;
            }
            if ("addcallparticipant".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddCallParticipant");
                if ("addcallparticipant".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddCallParticipantHelp(sb);
                }
                found = true;
            }
            if ("getcallparticipants".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetCallParticipants");
                if ("getcallparticipants".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetCallParticipantsHelp(sb);
                }
                found = true;
            }
            if ("updatecallparticipant".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateCallParticipant");
                if ("updatecallparticipant".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateCallParticipantHelp(sb);
                }
                found = true;
            }
            if ("deletecallparticipant".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteCallParticipant");
                if ("deletecallparticipant".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteCallParticipantHelp(sb);
                }
                found = true;
            }
            if ("addperson".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddPerson");
                if ("addperson".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddPersonHelp(sb);
                }
                found = true;
            }
            if ("getpeople".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetPeople");
                if ("getpeople".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetPeopleHelp(sb);
                }
                found = true;
            }
            if ("updateperson".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdatePerson");
                if ("updateperson".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdatePersonHelp(sb);
                }
                found = true;
            }
            if ("deleteperson".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeletePerson");
                if ("deleteperson".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeletePersonHelp(sb);
                }
                found = true;
            }
            if ("addshowseason".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddShowSeason");
                if ("addshowseason".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddShowSeasonHelp(sb);
                }
                found = true;
            }
            if ("getshowseasons".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetShowSeasons");
                if ("getshowseasons".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetShowSeasonsHelp(sb);
                }
                found = true;
            }
            if ("updateshowseason".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateShowSeason");
                if ("updateshowseason".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateShowSeasonHelp(sb);
                }
                found = true;
            }
            if ("deleteshowseason".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteShowSeason");
                if ("deleteshowseason".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteShowSeasonHelp(sb);
                }
                found = true;
            }
            if ("addshow".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddShow");
                if ("addshow".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddShowHelp(sb);
                }
                found = true;
            }
            if ("getshows".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetShows");
                if ("getshows".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetShowsHelp(sb);
                }
                found = true;
            }
            if ("updateshow".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateShow");
                if ("updateshow".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateShowHelp(sb);
                }
                found = true;
            }
            if ("deleteshow".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteShow");
                if ("deleteshow".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteShowHelp(sb);
                }
                found = true;
            }
            if ("addseasonepisode".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - AddSeasonEpisode");
                if ("addseasonepisode".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintAddSeasonEpisodeHelp(sb);
                }
                found = true;
            }
            if ("getseasonepisodes".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - GetSeasonEpisodes");
                if ("getseasonepisodes".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintGetSeasonEpisodesHelp(sb);
                }
                found = true;
            }
            if ("updateseasonepisode".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - UpdateSeasonEpisode");
                if ("updateseasonepisode".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintUpdateSeasonEpisodeHelp(sb);
                }
                found = true;
            }
            if ("deleteseasonepisode".Contains(helpTerm, StringComparison.OrdinalIgnoreCase))
            {
                sb.AppendLine($" - DeleteSeasonEpisode");
                if ("deleteseasonepisode".Equals(helpTerm, StringComparison.OrdinalIgnoreCase)) 
                {
                    this.PrintDeleteSeasonEpisodeHelp(sb);
                }
                found = true;
            }
                       
            if (!found)
            {
                sb.AppendLine();
                sb.AppendLine($"{Environment.NewLine}UNABLE TO FIND COMMAND: {helpTerm} not found.");
            }
        }

        private string HandlerFactory(string invokeRequest, string payloadString, string where, Int32 maxPages, string view)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject<StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;
            payload.MaxPages = maxPages;
            payload.View = view;

            switch (invokeRequest.ToLower())
            {
                case "addepisodehost":
                    this.SMQActor.AddEpisodeHost(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getepisodehosts":
                    this.SMQActor.GetEpisodeHosts(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateepisodehost":
                    this.SMQActor.UpdateEpisodeHost(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteepisodehost":
                    this.SMQActor.DeleteEpisodeHost(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addtopicagreement":
                    this.SMQActor.AddTopicAgreement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "gettopicagreements":
                    this.SMQActor.GetTopicAgreements(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatetopicagreement":
                    this.SMQActor.UpdateTopicAgreement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletetopicagreement":
                    this.SMQActor.DeleteTopicAgreement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcalltopic":
                    this.SMQActor.AddCallTopic(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcalltopics":
                    this.SMQActor.GetCallTopics(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecalltopic":
                    this.SMQActor.UpdateCallTopic(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecalltopic":
                    this.SMQActor.DeleteCallTopic(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addepisodecall":
                    this.SMQActor.AddEpisodeCall(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getepisodecalls":
                    this.SMQActor.GetEpisodeCalls(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateepisodecall":
                    this.SMQActor.UpdateEpisodeCall(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteepisodecall":
                    this.SMQActor.DeleteEpisodeCall(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcallparticipant":
                    this.SMQActor.AddCallParticipant(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcallparticipants":
                    this.SMQActor.GetCallParticipants(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecallparticipant":
                    this.SMQActor.UpdateCallParticipant(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecallparticipant":
                    this.SMQActor.DeleteCallParticipant(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addperson":
                    this.SMQActor.AddPerson(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getpeople":
                    this.SMQActor.GetPeople(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateperson":
                    this.SMQActor.UpdatePerson(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteperson":
                    this.SMQActor.DeletePerson(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addshowseason":
                    this.SMQActor.AddShowSeason(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getshowseasons":
                    this.SMQActor.GetShowSeasons(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateshowseason":
                    this.SMQActor.UpdateShowSeason(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteshowseason":
                    this.SMQActor.DeleteShowSeason(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addshow":
                    this.SMQActor.AddShow(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getshows":
                    this.SMQActor.GetShows(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateshow":
                    this.SMQActor.UpdateShow(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteshow":
                    this.SMQActor.DeleteShow(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addseasonepisode":
                    this.SMQActor.AddSeasonEpisode(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getseasonepisodes":
                    this.SMQActor.GetSeasonEpisodes(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateseasonepisode":
                    this.SMQActor.UpdateSeasonEpisode(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteseasonepisode":
                    this.SMQActor.DeleteSeasonEpisode(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
        
        
        public void PrintAddEpisodeHostHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeHost     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeHostId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - ShowHost");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - HostInitials");
                    sb.AppendLine($"CRUD      - HostName");
                    sb.AppendLine($"CRUD      - Role");
                
            
        }
        
        public void PrintGetEpisodeHostsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeHost     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeHostId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - ShowHost");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - HostInitials");
                    sb.AppendLine($"CRUD      - HostName");
                    sb.AppendLine($"CRUD      - Role");
                
            
        }
        
        public void PrintUpdateEpisodeHostHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeHost     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeHostId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - ShowHost");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - HostInitials");
                    sb.AppendLine($"CRUD      - HostName");
                    sb.AppendLine($"CRUD      - Role");
                
            
        }
        
        public void PrintDeleteEpisodeHostHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddTopicAgreementHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TopicAgreement     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TopicAgreementId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Topic");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - CallParticipant");
                
            
        }
        
        public void PrintGetTopicAgreementsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TopicAgreement     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TopicAgreementId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Topic");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - CallParticipant");
                
            
        }
        
        public void PrintUpdateTopicAgreementHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: TopicAgreement     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - TopicAgreementId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Topic");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - CallParticipant");
                
            
        }
        
        public void PrintDeleteTopicAgreementHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddCallTopicHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallTopic     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallTopicId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - ParentTopic");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ParentTopicSubject");
                    sb.AppendLine($"CRUD      - CallParticipant");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Timstamp");
                
            
        }
        
        public void PrintGetCallTopicsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallTopic     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallTopicId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - ParentTopic");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ParentTopicSubject");
                    sb.AppendLine($"CRUD      - CallParticipant");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Timstamp");
                
            
        }
        
        public void PrintUpdateCallTopicHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallTopic     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallTopicId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - ParentTopic");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - ParentTopicSubject");
                    sb.AppendLine($"CRUD      - CallParticipant");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - CreatedTime");
                    sb.AppendLine($"CRUD      - Timstamp");
                
            
        }
        
        public void PrintDeleteCallTopicHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddEpisodeCallHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeCall     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeCallId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                    sb.AppendLine($"CRUD      - EpisodeShow");
                
            
        }
        
        public void PrintGetEpisodeCallsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeCall     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeCallId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                    sb.AppendLine($"CRUD      - EpisodeShow");
                
            
        }
        
        public void PrintUpdateEpisodeCallHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: EpisodeCall     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - EpisodeCallId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - CallParticpants");
                    sb.AppendLine($"CRUD      - Subject");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - CallStartTime");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                    sb.AppendLine($"CRUD      - EpisodeShow");
                
            
        }
        
        public void PrintDeleteEpisodeCallHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddCallParticipantHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallParticipant     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallParticipantId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Person");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - PersonRoles");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - ChosenName");
                    sb.AppendLine($"CRUD      - CallSubject");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                
            
        }
        
        public void PrintGetCallParticipantsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallParticipant     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallParticipantId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Person");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - PersonRoles");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - ChosenName");
                    sb.AppendLine($"CRUD      - CallSubject");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                
            
        }
        
        public void PrintUpdateCallParticipantHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: CallParticipant     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - CallParticipantId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - EpisodeCall");
                    sb.AppendLine($"CRUD      - Person");
                    sb.AppendLine($"CRUD      - CallTopics");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - PersonRoles");
                    sb.AppendLine($"CRUD      - TopicAgreement");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - ChosenName");
                    sb.AppendLine($"CRUD      - CallSubject");
                    sb.AppendLine($"CRUD      - SeasonEpisode");
                    sb.AppendLine($"CRUD      - EpisodeShowName");
                
            
        }
        
        public void PrintDeleteCallParticipantHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddPersonHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Person     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PersonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Roles");
                    sb.AppendLine($"CRUD      - Location");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - Initials");
                    sb.AppendLine($"CRUD      - EmailAddress");
                
            
        }
        
        public void PrintGetPeopleHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Person     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PersonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Roles");
                    sb.AppendLine($"CRUD      - Location");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - Initials");
                    sb.AppendLine($"CRUD      - EmailAddress");
                
            
        }
        
        public void PrintUpdatePersonHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Person     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - PersonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Roles");
                    sb.AppendLine($"CRUD      - Location");
                    sb.AppendLine($"CRUD      - CallParticipants");
                    sb.AppendLine($"CRUD      - DisplayName");
                    sb.AppendLine($"CRUD      - AutoNumber");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - Initials");
                    sb.AppendLine($"CRUD      - EmailAddress");
                
            
        }
        
        public void PrintDeletePersonHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddShowSeasonHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ShowSeason     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - SeasonNumber");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - SeasonEpisodes");
                    sb.AppendLine($"CRUD      - ShowStartDate");
                    sb.AppendLine($"CRUD      - SeasonYear");
                    sb.AppendLine($"CRUD      - Shows");
                    sb.AppendLine($"CRUD      - LastEpisode");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                
            
        }
        
        public void PrintGetShowSeasonsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ShowSeason     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - SeasonNumber");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - SeasonEpisodes");
                    sb.AppendLine($"CRUD      - ShowStartDate");
                    sb.AppendLine($"CRUD      - SeasonYear");
                    sb.AppendLine($"CRUD      - Shows");
                    sb.AppendLine($"CRUD      - LastEpisode");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                
            
        }
        
        public void PrintUpdateShowSeasonHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: ShowSeason     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - SeasonNumber");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - SeasonEpisodes");
                    sb.AppendLine($"CRUD      - ShowStartDate");
                    sb.AppendLine($"CRUD      - SeasonYear");
                    sb.AppendLine($"CRUD      - Shows");
                    sb.AppendLine($"CRUD      - LastEpisode");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                
            
        }
        
        public void PrintDeleteShowSeasonHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddShowHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Show     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - StartDate");
                    sb.AppendLine($"CRUD      - ShowSeasons");
                    sb.AppendLine($"CRUD      - CurrentSeason");
                    sb.AppendLine($"CRUD      - CurrentSeasonNumber");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                    sb.AppendLine($"CRUD      - CurrentSeasonName");
                
            
        }
        
        public void PrintGetShowsHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Show     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - StartDate");
                    sb.AppendLine($"CRUD      - ShowSeasons");
                    sb.AppendLine($"CRUD      - CurrentSeason");
                    sb.AppendLine($"CRUD      - CurrentSeasonNumber");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                    sb.AppendLine($"CRUD      - CurrentSeasonName");
                
            
        }
        
        public void PrintUpdateShowHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: Show     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - ShowId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - StartDate");
                    sb.AppendLine($"CRUD      - ShowSeasons");
                    sb.AppendLine($"CRUD      - CurrentSeason");
                    sb.AppendLine($"CRUD      - CurrentSeasonNumber");
                    sb.AppendLine($"CRUD      - LastEpisodeNumber");
                    sb.AppendLine($"CRUD      - NextEpisodeNumber");
                    sb.AppendLine($"CRUD      - CurrentSeasonName");
                
            
        }
        
        public void PrintDeleteShowHelp(StringBuilder sb)
        {
            
        }
        
        public void PrintAddSeasonEpisodeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SeasonEpisode     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SeasonEpisodeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowSeason");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - EpisodeNumber");
                    sb.AppendLine($"CRUD      - AirDate");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - EpisodeCalls");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - EpisodeCallCount");
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                
            
        }
        
        public void PrintGetSeasonEpisodesHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SeasonEpisode     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SeasonEpisodeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowSeason");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - EpisodeNumber");
                    sb.AppendLine($"CRUD      - AirDate");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - EpisodeCalls");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - EpisodeCallCount");
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                
            
        }
        
        public void PrintUpdateSeasonEpisodeHelp(StringBuilder sb)
        {
            
                
                sb.AppendLine();
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine($"* *  OBJECT DEF: SeasonEpisode     *");
                sb.AppendLine($"* * * * * * * * * * * * * * * * * * * * * * * * * * *");
                sb.AppendLine();
                
                    sb.AppendLine($"CRUD      - SeasonEpisodeId");
                    sb.AppendLine($"CRUD      - Name");
                    sb.AppendLine($"CRUD      - Notes");
                    sb.AppendLine($"CRUD      - Attachments");
                    sb.AppendLine($"CRUD      - Status");
                    sb.AppendLine($"CRUD      - ShowSeason");
                    sb.AppendLine($"CRUD      - Show");
                    sb.AppendLine($"CRUD      - ShowName");
                    sb.AppendLine($"CRUD      - ShowCode");
                    sb.AppendLine($"CRUD      - EpisodeNumber");
                    sb.AppendLine($"CRUD      - AirDate");
                    sb.AppendLine($"CRUD      - EpisodeHosts");
                    sb.AppendLine($"CRUD      - EpisodeCalls");
                    sb.AppendLine($"CRUD      - LongName");
                    sb.AppendLine($"CRUD      - ShortName");
                    sb.AppendLine($"CRUD      - EpisodeCallCount");
                    sb.AppendLine($"CRUD      - ShowSeasonId");
                
            
        }
        
        public void PrintDeleteSeasonEpisodeHelp(StringBuilder sb)
        {
            
        }
        

    }
}
