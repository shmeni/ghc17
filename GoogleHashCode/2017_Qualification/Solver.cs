﻿using HashCodeCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017_Qualification
{
    public class Solver : SolverBase<ProblemInput, ProblemOutput>
    {
        protected override ProblemOutput Solve(ProblemInput input)
        {
	        var result = new ProblemOutput();

	        while (true)
	        {
		        var request = GetBestCurrentRequest(input);
		        if (request == null)
			        break;
		        var availableServers = input.CachedServers.Where(s => IsServerAvailableForVideo(s, request.Video));
		        if (!availableServers.Any())
			        continue;

				var selectedServer = availableServers.ArgMin(s => CalculateServerDistanceToRequest(s, request));

		        AssignVideoToServer(selectedServer, request, result);
	        }

			return result;
        }

		private bool IsServerAvailableForVideo(CachedServer cachedServer, Video video)
		{
            return video.Size <= cachedServer.Capacity;
		}

		private void AssignVideoToServer(CachedServer selectedServer, RequestsDescription request, ProblemOutput result)
		{
			selectedServer.Capacity -= request.Video.Size;
			result.ServerAssignments.GetOrCreate(selectedServer, _ => new List<Video>()).Add(request.Video);
		}

	    private double CalculateServerDistanceToRequest(CachedServer cachedServer, RequestsDescription request)
	    {
		    return request.Endpoint.ServersLatency.GetOrDefault(cachedServer, request.Endpoint.DataCenterLatency);
	    }

	    private RequestsDescription GetBestCurrentRequest(ProblemInput input)
	    {
		    throw new NotImplementedException();
	    }
    }
}
