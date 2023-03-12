using Content.Shared.Actions;
using Content.Shared.SimpleStation14.Species.Shadekin.Components;
using Robust.Shared.Audio;
using Robust.Shared.Serialization;

namespace Content.Shared.SimpleStation14.Species.Shadekin.Events
{
    /// <summary>
    ///     Raised when the shadekin teleport action is used.
    /// </summary>
    public sealed class ShadekinTeleportEvent : WorldTargetActionEvent
    {
        [DataField("sound")]
        public SoundSpecifier Sound = new SoundPathSpecifier("/Audio/SimpleStation14/Effects/Shadekin/Powers/base.ogg");

        [DataField("volume")]
        public float Volume = 5f;


        [DataField("powerCost")]
        public float PowerCost = 35f;

        [DataField("staminaCost")]
        public float StaminaCost = 30f;
    }

    /// <summary>
    ///     Raised when the shadekin darkSwap action is used.
    /// </summary>
    public sealed class ShadekinDarkSwapEvent : InstantActionEvent
    {
        [DataField("soundOn")]
        public SoundSpecifier SoundOn = new SoundPathSpecifier("/Audio/SimpleStation14/Effects/Shadekin/Powers/disappearance-gradual.ogg");

        [DataField("volumeOn")]
        public float VolumeOn = 5f;

        [DataField("soundOff")]
        public SoundSpecifier SoundOff = new SoundPathSpecifier("/Audio/SimpleStation14/Effects/Shadekin/Powers/futuristic-ufo.ogg");

        [DataField("volumeOff")]
        public float VolumeOff = 5f;


        /// <summary>
        ///     How much stamina to drain when darkening.
        /// </summary>
        [DataField("powerCostOn")]
        public float PowerCostOn = 45f;

        /// <summary>
        ///     How much stamina to drain when lightening.
        /// </summary>
        [DataField("powerCostOff")]
        public float PowerCostOff = 35f;

        [DataField("staminaCost")]
        public float StaminaCost = 0f;
    }

    /// <summary>
    ///     Raised over network to notify the client that they're going in/out of The Dark.
    /// </summary>
    [Serializable, NetSerializable]
    public sealed class ShadekinDarkSwappedEvent : EntityEventArgs
    {
        public EntityUid Performer { get; }
        public bool DarkSwapped { get; }

        public ShadekinDarkSwappedEvent(EntityUid performer, bool darkSwapped)
        {
            Performer = performer;
            DarkSwapped = darkSwapped;
        }
    }

    public sealed class ShadekinRestEvent: InstantActionEvent
    {

    }

    [Serializable, NetSerializable]
    public sealed class ShadekinRestEventResponse : EntityEventArgs
    {
        public EntityUid Performer { get; }
        public bool IsResting { get; }

        public ShadekinRestEventResponse(EntityUid performer, bool isResting)
        {
            Performer = performer;
            IsResting = isResting;
        }
    }


    /// <summary>
    ///     Raised when a shadekin becomes a blackeye.
    /// </summary>
    [Serializable, NetSerializable]
    public sealed class ShadekinBlackeyeEvent : EntityEventArgs
    {
        public readonly EntityUid Euid;

        public ShadekinBlackeyeEvent(EntityUid euid)
        {
            Euid = euid;
        }
    }
}
