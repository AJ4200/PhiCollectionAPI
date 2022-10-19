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
    public partial class PhiCollectionContext
    {
        private IPhiCollectionContextProcedures _procedures;

        public virtual IPhiCollectionContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new PhiCollectionContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IPhiCollectionContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<spCurrentMonthCollectionLogResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spCurrentMonthOverviewResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spDequeueTruckResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spGardenSiteTrafficResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spMoblieCredentialsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spMonthlyCollectionsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spPendingRequestsForResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spPendingRequestsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spRequestCollectionResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spSearchRequestForResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spTotalCollectionsByResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spTotalRequestsByResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spTruckQueueResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spTruckBreakdownsResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spUnavailableTrucksResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<spWasteDroppedOffResult>().HasNoKey().ToView(null);
        }
    }

    public partial class PhiCollectionContextProcedures : IPhiCollectionContextProcedures
    {
        private readonly PhiCollectionContext _context;

        public PhiCollectionContextProcedures(PhiCollectionContext context)
        {
            _context = context;
        }

        public virtual async Task<int> spAcceptRequestAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spAcceptRequest] @request", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spArrivedAtControlStationAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spArrivedAtControlStation] @request", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spArrivedAtGardenSiteAsync(int? request, string bin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "bin",
                    Size = 8,
                    Value = bin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spArrivedAtGardenSite] @request, @bin", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spArrivedAtLandfillAsync(int? request, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spArrivedAtLandfill] @request", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spArrivedAtReportedTruckAsync(int? request, string bin, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "bin",
                    Size = 8,
                    Value = bin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spArrivedAtReportedTruck] @request, @bin", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spCurrentMonthCollectionLogResult>> spCurrentMonthCollectionLogAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spCurrentMonthCollectionLogResult>("EXEC @returnValue = [dbo].[spCurrentMonthCollectionLog]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spCurrentMonthOverviewResult>> spCurrentMonthOverviewAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spCurrentMonthOverviewResult>("EXEC @returnValue = [dbo].[spCurrentMonthOverview]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spDequeueTruckAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "driver",
                    Size = 6,
                    Value = driver ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spDequeueDriver] @driver", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spEnqueueTruckAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "driver",
                    Size = 6,
                    Value = driver ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spEnqueueTruck] @driver", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spGardenSiteTrafficResult>> spGardenSiteTrafficAsync(DateTime startDate, DateTime endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };
            var sqlParameters = new[]
           {
                new SqlParameter
                {
                ParameterName = "StartDate",
                Size = 15,
                Value = startDate,
                SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                ParameterName = "EndDate",
                Size = 15,
                Value = endDate,
                SqlDbType = System.Data.SqlDbType.DateTime,
                },
                 parameterreturnValue,

            };
            var _ = await _context.SqlQueryAsync<spGardenSiteTrafficResult>("EXEC @returnValue = [dbo].[spGardenSiteTraffic] @startDate, @endDate", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spMoblieCredentialsResult>> spMoblieCredentialsAsync(string staff, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "staff",
                    Size = 6,
                    Value = staff ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spMoblieCredentialsResult>("EXEC @returnValue = [dbo].[spMoblieCredentials] @staff", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spMonthlyCollectionsResult>> spMonthlyCollectionsAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "startDate",
                    Value = startDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "endDate",
                    Value = endDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spMonthlyCollectionsResult>("EXEC @returnValue = [dbo].[spMonthlyCollections] @startDate, @endDate", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spPendingRequestsResult>> spPendingRequestsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spPendingRequestsResult>("EXEC @returnValue = [dbo].[spPendingRequests]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
        public virtual async Task<List<spPendingRequestsForResult>> spPendingRequestsForAsync(string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "supervisor",
                    Size = 6,
                    Value = supervisor ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spPendingRequestsForResult>("EXEC @returnValue = [dbo].[spPendingRequestsFor] @supervisor", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spProcessRequestAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spProcessRequest]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> spReportIssuetAsync(int? request, string location, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "request",
                    Size = 6,
                    Value = request ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                new SqlParameter
                {
                    ParameterName = "location",
                    Value = location ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[spReportTruckIssue] @request, @location", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spRequestCollectionResult>> spRequestCollectionAsync(string bin, string waste, string gardenSite, string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "bin",
                    Size = 8,
                    Value = bin ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                new SqlParameter
                {
                    ParameterName = "waste",
                    Size = 100,
                    Value = waste ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "gardenSite",
                    Size = 5,
                    Value = gardenSite ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                new SqlParameter
                {
                    ParameterName = "supervisor",
                    Size = 6,
                    Value = supervisor ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spRequestCollectionResult>("EXEC @returnValue = [dbo].[spRequestCollection] @bin, @waste, @gardenSite, @supervisor", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spSearchRequestForResult>> spSearchRequestForAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "driver",
                    Size = 6,
                    Value = driver ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spSearchRequestForResult>("EXEC @returnValue = [dbo].[spSearchRequestFor] @driver", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spTotalCollectionsByResult>> spTotalCollectionsByAsync(string driver, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "driver",
                    Size = 6,
                    Value = driver ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spTotalCollectionsByResult>("EXEC @returnValue = [dbo].[spTotalCollectionsBy] @driver", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spTotalRequestsByResult>> spTotalRequestsByAsync(string supervisor, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "supervisor",
                    Size = 6,
                    Value = supervisor ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Char,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spTotalRequestsByResult>("EXEC @returnValue = [dbo].[spTotalRequestsBy] @supervisor", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spTruckQueueResult>> spTruckQueueAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spTruckQueueResult>("EXEC @returnValue = [dbo].[spTruckQueue]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spTruckBreakdownsResult>> spTruckBreakdownsAsync(DateTime? startDate, DateTime? endDate, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "startDate",
                    Value = startDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "endDate",
                    Value = endDate ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spTruckBreakdownsResult>("EXEC @returnValue = [dbo].[spTruckBreakdowns] @startDate, @endDate", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spUnavailableTrucksResult>> spUnavailableTrucksAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spUnavailableTrucksResult>("EXEC @returnValue = [dbo].[spUnavailableTrucks]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<spWasteDroppedOffResult>> spWasteDroppedOffAsync(bool atRecycler = false, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "atRecycler",
                    Value = atRecycler,
                    SqlDbType = System.Data.SqlDbType.Bit,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<spWasteDroppedOffResult>("EXEC @returnValue = [dbo].[spWasteDroppedOff] @atRecycler", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

    }
}
