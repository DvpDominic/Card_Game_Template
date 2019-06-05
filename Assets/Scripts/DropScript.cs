using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnDrop(PointerEventData eventData)
    {
        DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
        if(d != null)
        {
            d.parentToReturnTo = this.transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
        if (d != null)
        {
            d.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragScript d = eventData.pointerDrag.GetComponent<DragScript>();
        if (d != null && d.placeholderParent==this.transform)
        {
            d.placeholderParent = d.parentToReturnTo;
        }
    }

}
