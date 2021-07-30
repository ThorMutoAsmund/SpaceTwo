using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler
{
    public bool isDown;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        this.isDown = true;
    }

    public bool GetDown()
    {
        if (this.isDown)
        {
            this.isDown = false;
            return true;
        }

        return false;
    }
}
