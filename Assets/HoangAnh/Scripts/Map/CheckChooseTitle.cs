using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class CheckChooseTitle : MonoBehaviour
    {
        [SerializeField] private LayerMask layerTitle;
        [SerializeField] private Camera camera;

        private TitleMapHA titleMapCache;
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, layerTitle))
                {
                    TitleMapHA titleMapHa = hit.transform.GetComponent<TitleMapHA>();
                    if (titleMapHa != null && titleMapCache != titleMapHa)
                    {
                        if (titleMapCache != null)
                        {
                            titleMapCache.EnableOutLine(false);
                        }
                        titleMapCache = titleMapHa;
                        if (titleMapCache.typeTitleMapHa == ETitleMapHA.TANK)
                        {
                            titleMapCache.EnableOutLine(true);
                        }
                    }
                }
                else
                {
                    if (titleMapCache != null)
                    {
                        titleMapCache.EnableOutLine(false);
                        titleMapCache = null;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (titleMapCache != null)
                {
                    titleMapCache.EnableOutLine(false);
                    titleMapCache = null;
                }
            }
        }
    }
}
