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
        [SerializeField] private Tank tankPrefab;

        private TitleMapHA titleMapCache;
        private Tank tankCache;
        
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
                        if (tankCache != null)
                        {
                            Destroy(tankCache.gameObject);
                        }
                        titleMapCache = titleMapHa;
                        if (titleMapCache.typeTitleMapHa == ETitleMapHA.TANK)
                        {
                            titleMapCache.EnableOutLine(true);
                            tankCache = Instantiate(tankPrefab, transform);
                            tankCache.transform.position = titleMapCache.transform.position;
                            tankCache.Initialized();
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
                    if (tankCache != null)
                    {
                        Destroy(tankCache.gameObject);
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
                if (tankCache != null)
                {
                    tankCache = null;
                }
            }
        }
    }
}
