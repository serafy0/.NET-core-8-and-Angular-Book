using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;

namespace HelloCheck.Server
{
    public class ICMPHealthCheck : IHealthCheck
    {
        private readonly string Host;
        private readonly int HealthyRoundTripTime;
        public ICMPHealthCheck(string host, int healthyRoundTripTime)
        {
            Host = host;
            HealthyRoundTripTime = healthyRoundTripTime;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(Host);
                switch (reply.Status)
                {
                    case IPStatus.Success:
                        var message = $"ICMP to {Host} took {reply.RoundtripTime} ms.";
                        return (reply.RoundtripTime > HealthyRoundTripTime) ? HealthCheckResult.Degraded(message) : HealthCheckResult.Healthy(message);

                    default:
                        var error = $"ICMP to {Host} failed: {reply.Status}";
                        return HealthCheckResult.Unhealthy(error);
                }
            }catch(Exception e)
            {
                var error = $"ICMP failed: {e.Message}";
                return HealthCheckResult.Unhealthy(error);
            }
            
        }
    }
}
