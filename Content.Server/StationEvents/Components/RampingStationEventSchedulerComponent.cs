namespace Content.Server.StationEvents.Components;

[RegisterComponent, Access(typeof(RampingStationEventSchedulerSystem))]
public sealed class RampingStationEventSchedulerComponent : Component
{
    [DataField("endTime"), ViewVariables(VVAccess.ReadWrite)]
    public float EndTime;

    [DataField("maxChaos"), ViewVariables(VVAccess.ReadWrite)]
    public float MaxChaos;

    [DataField("startingChaos"), ViewVariables(VVAccess.ReadWrite)]
    public float StartingChaos;

    [DataField("timeUntilNextEvent"), ViewVariables(VVAccess.ReadWrite)]
    public float TimeUntilNextEvent;

    [DataField("survivalTimeGoal"), ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan SurvivalTimeGoal;
}
