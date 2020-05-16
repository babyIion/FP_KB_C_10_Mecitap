using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AboutController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject about;

    public void OnPointerEnter(PointerEventData eventData)
    {
        about.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        about.SetActive(false);
    }
}
