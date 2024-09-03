namespace UnityEngine.XR.Interaction.Toolkit.Samples.SpatialKeyboard.KeyFunctions
{
    /// <summary>
    /// Key function used to hide the keyboard.
    /// </summary>
    [CreateAssetMenu(fileName = "Hide Function", menuName = "XR/Spatial Keyboard/Hide Key Function", order = 1)]
    public class HideFunction : KeyFunction
    {
        /// <inheritdoc />
        public override void ProcessKey(XRKeyboard keyboardContext, XRKeyboardKey key)
        {
            if (keyboardContext != null)
                keyboardContext.Close(false);
        }
    }
}
