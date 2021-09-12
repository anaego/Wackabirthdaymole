using UnityEngine;
using UnityEngine.EventSystems;

public class MoleHole : MonoBehaviour, IPointerDownHandler
{
    public BirthdayMolePlayer player;

    public bool HasMoleNow { get; set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        player.ThrowCake(this);
    }
}
