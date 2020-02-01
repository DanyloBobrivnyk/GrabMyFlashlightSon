using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour, IGrabbable {

    private bool isPressed = false;
    [SerializeField]
    private List<IButtonTarget> targets;

    public void Grab(HandController handController) {
        foreach (IButtonTarget target in targets) {
            target.ButtonPressed();
        }
    }

    public void Release() {
        foreach (IButtonTarget target in targets) {
            target.ButtonReleased();
        }
    }
}