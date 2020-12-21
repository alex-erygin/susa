using System;

namespace Susanin.Api.Contracts
{
    public record RoadmapItem(
        int Id,
        DateTime Created,
        string Name,
        string Description,
        string Status,
        string Customer,
        string Executor,
        bool Approved,
        float Readiness,
        DateTime? Started,
        DateTime? PlannedComplete,
        DateTime? FactComplete,
        string Url);
}