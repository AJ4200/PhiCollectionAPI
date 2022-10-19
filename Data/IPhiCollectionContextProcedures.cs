using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PhiCollectionAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace PhiCollectionAPI.Data
{
    public partial interface IPhiCollectionContextProcedures
    {
        Task<int> spAcceptRequestAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spArrivedAtControlStationAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spArrivedAtGardenSiteAsync(int? request, string bin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spArrivedAtLandfillAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spArrivedAtReportedTruckAsync(int? request, string bin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spCurrentMonthCollectionLogResult>> spCurrentMonthCollectionLogAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spCurrentMonthOverviewResult>> spCurrentMonthOverviewAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spDequeueTruckAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spEnqueueTruckAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spGardenSiteTrafficResult>> spGardenSiteTrafficAsync(DateTime startDate, DateTime EndDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spMoblieCredentialsResult>> spMoblieCredentialsAsync(string staff, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spMonthlyCollectionsResult>> spMonthlyCollectionsAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spPendingRequestsResult>> spPendingRequestsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spPendingRequestsForResult>> spPendingRequestsForAsync(string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spProcessRequestAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<int> spReportIssuetAsync(int? request, string location, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spRequestCollectionResult>> spRequestCollectionAsync(string bin, string waste, string gardenSite, string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spSearchRequestForResult>> spSearchRequestForAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTotalCollectionsByResult>> spTotalCollectionsByAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTotalRequestsByResult>> spTotalRequestsByAsync(string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTruckQueueResult>> spTruckQueueAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spTruckBreakdownsResult>> spTruckBreakdownsAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spUnavailableTrucksResult>> spUnavailableTrucksAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
        Task<List<spWasteDroppedOffResult>> spWasteDroppedOffAsync(bool atRecycler = false, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default);
    }
}
