using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQCRUDCoordinator : SMQActorBase
    {

        public SMQCRUDCoordinator(String amqpConnectionString)
            : base(amqpConnectionString, "crudcoordinator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "crudcoordinator.general.guest.requesttoken":
                        this.OnGuestRequestTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.validatetemporaryaccesstoken":
                        this.OnGuestValidateTemporaryAccessTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoami":
                        this.OnGuestWhoAmIReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoareyou":
                        this.OnGuestWhoAreYouReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.utlity.guest.storetempfile":
                        this.OnGuestStoreTempFileReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration":
                        this.OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetjwtsecretkey":
                        this.OnCRUDCoordinatorResetJWTSecretKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addepisodehost":
                        this.OnAdminAddEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getepisodehosts":
                        this.OnAdminGetEpisodeHostsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateepisodehost":
                        this.OnAdminUpdateEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteepisodehost":
                        this.OnAdminDeleteEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addepisodehost":
                        this.OnModeratorAddEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getepisodehosts":
                        this.OnModeratorGetEpisodeHostsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateepisodehost":
                        this.OnModeratorUpdateEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteepisodehost":
                        this.OnModeratorDeleteEpisodeHostReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addtopicagreement":
                        this.OnAdminAddTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.gettopicagreements":
                        this.OnAdminGetTopicAgreementsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatetopicagreement":
                        this.OnAdminUpdateTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletetopicagreement":
                        this.OnAdminDeleteTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addtopicagreement":
                        this.OnModeratorAddTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.gettopicagreements":
                        this.OnModeratorGetTopicAgreementsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updatetopicagreement":
                        this.OnModeratorUpdateTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deletetopicagreement":
                        this.OnModeratorDeleteTopicAgreementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcalltopic":
                        this.OnAdminAddCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcalltopics":
                        this.OnAdminGetCallTopicsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecalltopic":
                        this.OnAdminUpdateCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecalltopic":
                        this.OnAdminDeleteCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addcalltopic":
                        this.OnModeratorAddCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getcalltopics":
                        this.OnModeratorGetCallTopicsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updatecalltopic":
                        this.OnModeratorUpdateCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deletecalltopic":
                        this.OnModeratorDeleteCallTopicReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addepisodecall":
                        this.OnAdminAddEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getepisodecalls":
                        this.OnAdminGetEpisodeCallsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateepisodecall":
                        this.OnAdminUpdateEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteepisodecall":
                        this.OnAdminDeleteEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addepisodecall":
                        this.OnModeratorAddEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getepisodecalls":
                        this.OnModeratorGetEpisodeCallsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateepisodecall":
                        this.OnModeratorUpdateEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteepisodecall":
                        this.OnModeratorDeleteEpisodeCallReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcallparticipant":
                        this.OnAdminAddCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcallparticipants":
                        this.OnAdminGetCallParticipantsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecallparticipant":
                        this.OnAdminUpdateCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecallparticipant":
                        this.OnAdminDeleteCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addcallparticipant":
                        this.OnModeratorAddCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getcallparticipants":
                        this.OnModeratorGetCallParticipantsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updatecallparticipant":
                        this.OnModeratorUpdateCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deletecallparticipant":
                        this.OnModeratorDeleteCallParticipantReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addperson":
                        this.OnAdminAddPersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getpeople":
                        this.OnAdminGetPeopleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateperson":
                        this.OnAdminUpdatePersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteperson":
                        this.OnAdminDeletePersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addperson":
                        this.OnModeratorAddPersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getpeople":
                        this.OnModeratorGetPeopleReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateperson":
                        this.OnModeratorUpdatePersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteperson":
                        this.OnModeratorDeletePersonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addshowseason":
                        this.OnAdminAddShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getshowseasons":
                        this.OnAdminGetShowSeasonsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateshowseason":
                        this.OnAdminUpdateShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteshowseason":
                        this.OnAdminDeleteShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addshowseason":
                        this.OnModeratorAddShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getshowseasons":
                        this.OnModeratorGetShowSeasonsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateshowseason":
                        this.OnModeratorUpdateShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteshowseason":
                        this.OnModeratorDeleteShowSeasonReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getshows":
                        this.OnGuestGetShowsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addshow":
                        this.OnAdminAddShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getshows":
                        this.OnAdminGetShowsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateshow":
                        this.OnAdminUpdateShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteshow":
                        this.OnAdminDeleteShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addshow":
                        this.OnModeratorAddShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getshows":
                        this.OnModeratorGetShowsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateshow":
                        this.OnModeratorUpdateShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteshow":
                        this.OnModeratorDeleteShowReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addseasonepisode":
                        this.OnAdminAddSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getseasonepisodes":
                        this.OnAdminGetSeasonEpisodesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateseasonepisode":
                        this.OnAdminUpdateSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteseasonepisode":
                        this.OnAdminDeleteSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.addseasonepisode":
                        this.OnModeratorAddSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.getseasonepisodes":
                        this.OnModeratorGetSeasonEpisodesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.updateseasonepisode":
                        this.OnModeratorUpdateSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.moderator.deleteseasonepisode":
                        this.OnModeratorDeleteSeasonEpisodeReceived(payload, bdea);
                        break;
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            var reply = payload.ReplyPayload is null ? payload  : payload.ReplyPayload;
            reply.IsHandled = payload.IsHandled;
            if (reply.AccessToken == originalAccessToken) reply.AccessToken = null;            
            this.Reply(reply, bdea.BasicProperties);
        }

        
        /// <summary>
        /// Responds to: RequestToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestRequestTokenReceived;
        protected virtual void OnGuestRequestTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestRequestTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestRequestTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ValidateTemporaryAccessToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestValidateTemporaryAccessTokenReceived;
        protected virtual void OnGuestValidateTemporaryAccessTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestValidateTemporaryAccessTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestValidateTemporaryAccessTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAmI from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAmIReceived;
        protected virtual void OnGuestWhoAmIReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAmIReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAmIReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAreYou from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAreYouReceived;
        protected virtual void OnGuestWhoAreYouReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAreYouReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAreYouReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StoreTempFile from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestStoreTempFileReceived;
        protected virtual void OnGuestStoreTempFileReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestStoreTempFileReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestStoreTempFileReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetRabbitSassyMQConfiguration from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetRabbitSassyMQConfigurationReceived;
        protected virtual void OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetJWTSecretKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetJWTSecretKeyReceived;
        protected virtual void OnCRUDCoordinatorResetJWTSecretKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetJWTSecretKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetJWTSecretKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEpisodeHost from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEpisodeHostReceived;
        protected virtual void OnAdminAddEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEpisodeHosts from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEpisodeHostsReceived;
        protected virtual void OnAdminGetEpisodeHostsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEpisodeHostsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEpisodeHostsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEpisodeHost from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEpisodeHostReceived;
        protected virtual void OnAdminUpdateEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEpisodeHost from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEpisodeHostReceived;
        protected virtual void OnAdminDeleteEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEpisodeHost from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddEpisodeHostReceived;
        protected virtual void OnModeratorAddEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEpisodeHosts from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetEpisodeHostsReceived;
        protected virtual void OnModeratorGetEpisodeHostsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetEpisodeHostsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetEpisodeHostsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEpisodeHost from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateEpisodeHostReceived;
        protected virtual void OnModeratorUpdateEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEpisodeHost from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteEpisodeHostReceived;
        protected virtual void OnModeratorDeleteEpisodeHostReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteEpisodeHostReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteEpisodeHostReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTopicAgreement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddTopicAgreementReceived;
        protected virtual void OnAdminAddTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTopicAgreements from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetTopicAgreementsReceived;
        protected virtual void OnAdminGetTopicAgreementsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetTopicAgreementsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetTopicAgreementsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTopicAgreement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateTopicAgreementReceived;
        protected virtual void OnAdminUpdateTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTopicAgreement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteTopicAgreementReceived;
        protected virtual void OnAdminDeleteTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTopicAgreement from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddTopicAgreementReceived;
        protected virtual void OnModeratorAddTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTopicAgreements from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetTopicAgreementsReceived;
        protected virtual void OnModeratorGetTopicAgreementsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetTopicAgreementsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetTopicAgreementsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTopicAgreement from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateTopicAgreementReceived;
        protected virtual void OnModeratorUpdateTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTopicAgreement from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteTopicAgreementReceived;
        protected virtual void OnModeratorDeleteTopicAgreementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteTopicAgreementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteTopicAgreementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCallTopic from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCallTopicReceived;
        protected virtual void OnAdminAddCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCallTopics from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCallTopicsReceived;
        protected virtual void OnAdminGetCallTopicsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCallTopicsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCallTopicsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCallTopic from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCallTopicReceived;
        protected virtual void OnAdminUpdateCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCallTopic from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCallTopicReceived;
        protected virtual void OnAdminDeleteCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCallTopic from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddCallTopicReceived;
        protected virtual void OnModeratorAddCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCallTopics from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetCallTopicsReceived;
        protected virtual void OnModeratorGetCallTopicsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetCallTopicsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetCallTopicsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCallTopic from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateCallTopicReceived;
        protected virtual void OnModeratorUpdateCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCallTopic from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteCallTopicReceived;
        protected virtual void OnModeratorDeleteCallTopicReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteCallTopicReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteCallTopicReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEpisodeCall from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEpisodeCallReceived;
        protected virtual void OnAdminAddEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEpisodeCalls from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEpisodeCallsReceived;
        protected virtual void OnAdminGetEpisodeCallsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEpisodeCallsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEpisodeCallsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEpisodeCall from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEpisodeCallReceived;
        protected virtual void OnAdminUpdateEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEpisodeCall from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEpisodeCallReceived;
        protected virtual void OnAdminDeleteEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEpisodeCall from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddEpisodeCallReceived;
        protected virtual void OnModeratorAddEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEpisodeCalls from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetEpisodeCallsReceived;
        protected virtual void OnModeratorGetEpisodeCallsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetEpisodeCallsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetEpisodeCallsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEpisodeCall from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateEpisodeCallReceived;
        protected virtual void OnModeratorUpdateEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEpisodeCall from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteEpisodeCallReceived;
        protected virtual void OnModeratorDeleteEpisodeCallReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteEpisodeCallReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteEpisodeCallReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCallParticipant from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCallParticipantReceived;
        protected virtual void OnAdminAddCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCallParticipants from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCallParticipantsReceived;
        protected virtual void OnAdminGetCallParticipantsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCallParticipantsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCallParticipantsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCallParticipant from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCallParticipantReceived;
        protected virtual void OnAdminUpdateCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCallParticipant from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCallParticipantReceived;
        protected virtual void OnAdminDeleteCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCallParticipant from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddCallParticipantReceived;
        protected virtual void OnModeratorAddCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCallParticipants from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetCallParticipantsReceived;
        protected virtual void OnModeratorGetCallParticipantsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetCallParticipantsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetCallParticipantsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCallParticipant from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateCallParticipantReceived;
        protected virtual void OnModeratorUpdateCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCallParticipant from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteCallParticipantReceived;
        protected virtual void OnModeratorDeleteCallParticipantReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteCallParticipantReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteCallParticipantReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPerson from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddPersonReceived;
        protected virtual void OnAdminAddPersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddPersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddPersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPeople from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetPeopleReceived;
        protected virtual void OnAdminGetPeopleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetPeopleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetPeopleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePerson from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdatePersonReceived;
        protected virtual void OnAdminUpdatePersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdatePersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdatePersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePerson from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeletePersonReceived;
        protected virtual void OnAdminDeletePersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeletePersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeletePersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddPerson from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddPersonReceived;
        protected virtual void OnModeratorAddPersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddPersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddPersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetPeople from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetPeopleReceived;
        protected virtual void OnModeratorGetPeopleReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetPeopleReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetPeopleReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdatePerson from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdatePersonReceived;
        protected virtual void OnModeratorUpdatePersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdatePersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdatePersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeletePerson from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeletePersonReceived;
        protected virtual void OnModeratorDeletePersonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeletePersonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeletePersonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddShowSeason from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddShowSeasonReceived;
        protected virtual void OnAdminAddShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetShowSeasons from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetShowSeasonsReceived;
        protected virtual void OnAdminGetShowSeasonsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetShowSeasonsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetShowSeasonsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateShowSeason from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateShowSeasonReceived;
        protected virtual void OnAdminUpdateShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteShowSeason from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteShowSeasonReceived;
        protected virtual void OnAdminDeleteShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddShowSeason from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddShowSeasonReceived;
        protected virtual void OnModeratorAddShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetShowSeasons from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetShowSeasonsReceived;
        protected virtual void OnModeratorGetShowSeasonsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetShowSeasonsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetShowSeasonsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateShowSeason from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateShowSeasonReceived;
        protected virtual void OnModeratorUpdateShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteShowSeason from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteShowSeasonReceived;
        protected virtual void OnModeratorDeleteShowSeasonReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteShowSeasonReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteShowSeasonReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetShows from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetShowsReceived;
        protected virtual void OnGuestGetShowsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetShowsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetShowsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddShow from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddShowReceived;
        protected virtual void OnAdminAddShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetShows from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetShowsReceived;
        protected virtual void OnAdminGetShowsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetShowsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetShowsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateShow from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateShowReceived;
        protected virtual void OnAdminUpdateShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteShow from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteShowReceived;
        protected virtual void OnAdminDeleteShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddShow from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddShowReceived;
        protected virtual void OnModeratorAddShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetShows from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetShowsReceived;
        protected virtual void OnModeratorGetShowsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetShowsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetShowsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateShow from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateShowReceived;
        protected virtual void OnModeratorUpdateShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteShow from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteShowReceived;
        protected virtual void OnModeratorDeleteShowReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteShowReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteShowReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddSeasonEpisode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddSeasonEpisodeReceived;
        protected virtual void OnAdminAddSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSeasonEpisodes from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetSeasonEpisodesReceived;
        protected virtual void OnAdminGetSeasonEpisodesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetSeasonEpisodesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetSeasonEpisodesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateSeasonEpisode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateSeasonEpisodeReceived;
        protected virtual void OnAdminUpdateSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteSeasonEpisode from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteSeasonEpisodeReceived;
        protected virtual void OnAdminDeleteSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddSeasonEpisode from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorAddSeasonEpisodeReceived;
        protected virtual void OnModeratorAddSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorAddSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorAddSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetSeasonEpisodes from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorGetSeasonEpisodesReceived;
        protected virtual void OnModeratorGetSeasonEpisodesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorGetSeasonEpisodesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorGetSeasonEpisodesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateSeasonEpisode from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorUpdateSeasonEpisodeReceived;
        protected virtual void OnModeratorUpdateSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorUpdateSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorUpdateSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteSeasonEpisode from Moderator
        /// </summary>
        public event EventHandler<PayloadEventArgs> ModeratorDeleteSeasonEpisodeReceived;
        protected virtual void OnModeratorDeleteSeasonEpisodeReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.ModeratorDeleteSeasonEpisodeReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.ModeratorDeleteSeasonEpisodeReceived(this, plea);
            }
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetRabbitSassyMQConfiguration(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetRabbitSassyMQConfiguration(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetJWTSecretKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetJWTSecretKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetjwtsecretkey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
    }
}

                    
