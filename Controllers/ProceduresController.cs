using Microsoft.AspNetCore.Mvc;
using PhiCollectionAPI.Data;
using PhiCollectionAPI.Models;

namespace PhiCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private IPhiCollectionContextProcedures _repository;

        public ProceduresController(IPhiCollectionContextProcedures repository)
        {
            _repository = repository;
        }

        // POST: api/Procedures/5
        [HttpPost]
        [Route("AcceptRequest/{request}")]
        public Task<int> AcceptRequest(int? request)
        {
            return _repository.spAcceptRequestAsync(request);
        }

        // POST: api/Procedures/5
        [HttpPost]
        [Route("ArrivedAtControlStation/{request}")]
        public Task<int> ArrivedAtControlStation(int? request)
        {
            return _repository.spArrivedAtControlStationAsync(request);
        }

        // POST: api/Procedures/5
        [HttpPost]
        [Route("ArrivedAtGardenSite/{request}/{bin}")]
        public Task<int> ArrivedAtGardenSite(int? request, string bin)
        {
            return _repository.spArrivedAtGardenSiteAsync(request, bin);
        }

        // POST: api/Procedures/5
        [HttpPost]
        [Route("ArrivedAtLandfill/{request}")]
        public Task<int> ArrivedAtLandfill(int? request)
        {
            return _repository.spArrivedAtLandfillAsync(request);
        }

        // POST: api/Procedures/5
        [HttpPost]
        [Route("ArrivedAtReportedTruck/{request}/{bin}")]
        public Task<int> ArrivedAtReportedTruck(int? request, string bin)
        {
            return _repository.spArrivedAtReportedTruckAsync(request, bin);
        }

        // GET: api/Procedures/
        [HttpGet("CurrentMonthCollectionLog")]
        public Task<List<spCurrentMonthCollectionLogResult>> CurrentMonthCollectionLog()
        {
            return _repository.spCurrentMonthCollectionLogAsync();
        }

        // GET: api/Procedures/
        [HttpGet("CurrentMonthOverview")]
        public Task<List<spCurrentMonthOverviewResult>> CurrentMonthOverview()
        {
            return _repository.spCurrentMonthOverviewAsync();
        }

        // Delete: api/Procedures/
        [HttpDelete]
        [Route("Dequeue/{driver}")]
        public Task<int> Dequeue(string driver)
        {
            return _repository.spDequeueTruckAsync(driver);
        }

        // POST: api/Procedures/
        [HttpPost]
        [Route("Enqueue/{driver}")]
        public Task<int> Enqueue(string driver)
        {
            return _repository.spEnqueueTruckAsync(driver);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("GardenSiteTraffic/{startDate}/{endDate}")]
        public Task<List<spGardenSiteTrafficResult>> GardenSiteTraffic(DateTime startDate, DateTime endDate)
        {
            return _repository.spGardenSiteTrafficAsync(startDate, endDate);
        }

        // GET: api/Procedures/5
        [HttpGet]
        [Route("MobileSessions/{staff}")]
        public Task<List<spMoblieCredentialsResult>> MobileSessions(String staff)
        {
            return _repository.spMoblieCredentialsAsync(staff);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("MonthlyCollections/{startDate}/{endDate}")]
        public Task<List<spMonthlyCollectionsResult>> MonthlyCollections(DateTime startDate, DateTime endDate)
        {
            return _repository.spMonthlyCollectionsAsync(startDate, endDate);
        }

        // GET: api/Procedures
        [HttpGet("PendingRequests")]
        public Task<List<spPendingRequestsResult>> PendingRequests()
        {
            return _repository.spPendingRequestsAsync();
        }

        // GET: api/Procedures
        [HttpGet("PendingRequestsFor/{supervisor}")]
        public Task<List<spPendingRequestsForResult>> PendingRequestsFor(string supervisor)
        {
            return _repository.spPendingRequestsForAsync(supervisor);
        }

        // POST: api/Procedures/
        [HttpPost]
        [Route("ReportTruckIssue/{request}/{location}")]
        public Task<int> ReportTruckIssue(int request, string location)
        {
            return _repository.spReportIssuetAsync(request, location);
        }

        // POST: api/Procedures/
        [HttpPost]
        [Route("RequestCollection/{bin}/{waste}/{gardenSite}/{supervisor}")]
        public Task<List<spRequestCollectionResult>> RequestCollection(string bin, string waste, string gardenSite, string supervisor)
        {
            return _repository.spRequestCollectionAsync(bin, waste, gardenSite, supervisor);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("SearchRequestFor/{driver}")]
        public Task<List<spSearchRequestForResult>> SearchRequestFor(string driver)
        {
            return _repository.spSearchRequestForAsync(driver);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("TotalCollectionsBy/{driver}")]
        public Task<List<spTotalCollectionsByResult>> TotalCollectionsBy(string driver)
        {
            return _repository.spTotalCollectionsByAsync(driver);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("TotalRequestsBy/{supervisor}")]
        public Task<List<spTotalRequestsByResult>> TotalRequestsBy(string supervisor)
        {
            return _repository.spTotalRequestsByAsync(supervisor);
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("TruckBreakdowns/{startDate}/{endDate}")]
        public Task<List<spTruckBreakdownsResult>> TruckBreakdowns(DateTime startDate, DateTime endDate)
        {
            return _repository.spTruckBreakdownsAsync(startDate, endDate);
        }

        // GET: api/Procedures/
        [HttpGet("TruckQueue")]
        public Task<List<spTruckQueueResult>> TruckQueue()
        {
            return _repository.spTruckQueueAsync();
        }

        // GET: api/Procedures
        [HttpGet("UnavailableTrucks")]
        public Task<List<spUnavailableTrucksResult>> UnavailableTrucks()
        {
            return _repository.spUnavailableTrucksAsync();
        }

        // GET: api/Procedures/
        [HttpGet]
        [Route("WasteDroppedOff/{atRecycler}")]
        public Task<List<spWasteDroppedOffResult>> WasteDroppedOff(bool atRecycler = false)
        {
            return _repository.spWasteDroppedOffAsync(atRecycler);
        }
    }
}
