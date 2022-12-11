using Content.Shared.Simplestation14.Nanites;
using Content.Shared.Actions;
using Content.Server.Popups;
using Content.Shared.Actions.ActionTypes;
using Robust.Shared.Prototypes;

namespace Content.Server.SimpleStation14.Nanites
{
    public sealed class NaniteButtonProgram : EntitySystem
    {
        [Dependency] private readonly IEntityManager _entityManager = default!;
        [Dependency] private readonly IPrototypeManager _prototype = default!;
        [Dependency] private readonly PopupSystem _popupSystem = default!;
        [Dependency] private readonly SharedActionsSystem _actionsSystem = default!;

        public override void Initialize()
        {
            base.Initialize();

            SubscribeLocalEvent<NaniteHostComponent, NaniteButtonTrigger>(OnButtonTrigger);
            SubscribeLocalEvent<NaniteHostComponent, NaniteButtonProgramDeleted>(OnProgramDeleted);
        }

        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            foreach (var Nanites in EntityQuery<NaniteHostComponent>())
            {
                Nanites.buttonAccumulator += frameTime;
                if (Nanites.buttonAccumulator < 2.5f) continue;
                Nanites.buttonAccumulator -= 1f;

                foreach (var Program in Nanites.Programs)
                {
                    if (Program.Type != "Button") continue;

                    if (Program.EEnabled == true)
                    {
                        if (!_prototype.TryIndex<InstantActionPrototype>("NaniteButtonTrigger", out var prototype)) continue;
                        var button = new InstantAction(prototype)
                        {
                            DisplayName = Program.EName,
                            Description = Program.EDescription,
                        };

                        _actionsSystem.AddAction(Nanites.Owner, button, Nanites.Owner);
                        // TODO: Only have this appear once
                        // _popupSystem.PopupEntity(Loc.GetString("nanite-button-appear"), Nanites.Owner, Filter.Entities(Nanites.Owner));
                    }

                    // TODO: This seems to not work, actions stay while the program is disabled
                    if (Program.EEnabled == false)
                    {
                        if (!_prototype.TryIndex<InstantActionPrototype>("NaniteButtonTrigger", out var prototype)) continue;
                        var button = new InstantAction(prototype)
                        {
                            DisplayName = Program.EName,
                            Description = Program.EDescription,
                        };

                        _actionsSystem.RemoveAction(Nanites.Owner, button);
                        // TODO: Only have this appear once
                        // _popupSystem.PopupEntity(Loc.GetString("nanite-button-disappear"), Nanites.Owner, Filter.Entities(Nanites.Owner));
                    }
                }
            }
        }

        public void OnButtonTrigger(EntityUid uid, NaniteHostComponent Nanites, NaniteButtonTrigger args)
        {
            Console.WriteLine(args);
        }

        public void OnProgramDeleted(EntityUid uid, NaniteHostComponent Nanites, NaniteButtonProgramDeleted args)
        {
            var Program = args.Program;
            if (Program.Type != "Button") return;

            if (!_prototype.TryIndex<InstantActionPrototype>("NaniteButtonTrigger", out var prototype)) return;
            var button = new InstantAction(prototype)
            {
                DisplayName = Program.EName,
                Description = Program.EDescription,
            };

            _actionsSystem.RemoveAction(Nanites.Owner, button);
        }
    }

    public sealed class NaniteButtonTrigger : InstantActionEvent { }
    public sealed class NaniteButtonProgramDeleted : EntityEventArgs {
        public NaniteProgram Program = new();
    }
}
