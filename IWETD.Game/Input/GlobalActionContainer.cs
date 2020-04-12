﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using osu.Framework.Input;
using osu.Framework.Input.Bindings;

namespace IWETD.Game.Input
{
    public class GlobalActionContainer : KeyBindingContainer<GlobalAction>, IHandleGlobalKeyboardInput
    {
        public GlobalActionContainer()
            : base(matchingMode: KeyCombinationMatchingMode.Modifiers) 
        { }

        public override IEnumerable<KeyBinding> DefaultKeyBindings => GlobalKeyBindings.Concat(AudioControlKeyBindings);

        public IEnumerable<KeyBinding> GlobalKeyBindings => new[]
        {
            new KeyBinding(InputKey.R, GlobalAction.Restart),
            new KeyBinding(InputKey.Escape, GlobalAction.Pause)
        };
        
        public IEnumerable<KeyBinding> AudioControlKeyBindings => new[]
        {
            new KeyBinding(new[] { InputKey.Alt, InputKey.Up }, GlobalAction.IncreaseVolume),
            new KeyBinding(new[] { InputKey.Alt, InputKey.MouseWheelUp }, GlobalAction.IncreaseVolume),
            new KeyBinding(new[] { InputKey.Alt, InputKey.Down }, GlobalAction.DecreaseVolume),
            new KeyBinding(new[] { InputKey.Alt, InputKey.MouseWheelDown }, GlobalAction.DecreaseVolume),

            new KeyBinding(InputKey.F4, GlobalAction.ToggleMute),
        };
    }

    public enum GlobalAction
    {
        [Description("Increase volume")]
        IncreaseVolume,

        [Description("Decrease volume")]
        DecreaseVolume,
        
        [Description("Toggle mute")]
        ToggleMute,
        
        Restart,
        Pause
    }
}