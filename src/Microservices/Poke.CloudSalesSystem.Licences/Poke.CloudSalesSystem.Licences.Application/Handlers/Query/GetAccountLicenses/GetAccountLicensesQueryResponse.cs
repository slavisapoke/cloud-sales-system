﻿
using Poke.CloudSalesSystem.Common.Contracts.Licences;

namespace Poke.CloudSalesSystem.Licences.Application.Handlers.Query.GetAccountLicences
{
    public class GetAccountLicencesQueryResponse
    {
        public Guid AccountId { get; set; }
        public List<Licence> Licences { get; set; } = [];
        public List<Subscription> Subscriptions { get; set; } = [];
    }
}