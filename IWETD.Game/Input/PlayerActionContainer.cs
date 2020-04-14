using System.Collections.Generic;
using osu.Framework.Input.Bindings;

namespace IWETD.Game.Input
{
    public class PlayerActionContainer : KeyBindingContainer<PlayerAction>
    {
        public PlayerActionContainer(KeyCombinationMatchingMode keyCombinationMatchingMode = KeyCombinationMatchingMode.Any, SimultaneousBindingMode simultaneousBindingMode = SimultaneousBindingMode.All) 
            : base(simultaneousBindingMode, keyCombinationMatchingMode)
        {
        }
        
        public override IEnumerable<KeyBinding> DefaultKeyBindings => new[]
        {
            // Movement
            new KeyBinding(InputKey.Left, PlayerAction.Left),
            new KeyBinding(InputKey.D, PlayerAction.Left),
            new KeyBinding(InputKey.Right, PlayerAction.Right),
            new KeyBinding(InputKey.A, PlayerAction.Right),
            
            // Actions
            new KeyBinding(InputKey.Z, PlayerAction.Shoot),
            new KeyBinding(InputKey.Shift, PlayerAction.Jump),
        };
    }
    
    public enum PlayerAction
    {
        Left,
        Right,
        Jump,
        Shoot
    }
}