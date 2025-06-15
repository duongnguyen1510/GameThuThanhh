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
<<<<<<< HEAD

        private TitleMapHA titleMapCache;
=======
        [SerializeField] private Tank tankPrefab;

        private TitleMapHA titleMapCache;
        private Tank tankCache;
>>>>>>> 2a9a859e8e227b2b6c8a0311e6552b4eccfe79fe
        
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
<<<<<<< HEAD
=======
                        if (tankCache != null)
                        {
                            Destroy(tankCache.gameObject);
                        }
>>>>>>> 2a9a859e8e227b2b6c8a0311e6552b4eccfe79fe
                        titleMapCache = titleMapHa;
                        if (titleMapCache.typeTitleMapHa == ETitleMapHA.TANK)
                        {
                            titleMapCache.EnableOutLine(true);
<<<<<<< HEAD
=======
                            tankCache = Instantiate(tankPrefab, transform);
                            tankCache.EnableRangeAtt(true);
                            tankCache.transform.position = titleMapCache.transform.position;
                            tankCache.Initialized();
>>>>>>> 2a9a859e8e227b2b6c8a0311e6552b4eccfe79fe
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
<<<<<<< HEAD
=======
                    if (tankCache != null)
                    {
                        tankCache.EnableRangeAtt(false);
                        Destroy(tankCache.gameObject);
                        tankCache = null;
                    }
>>>>>>> 2a9a859e8e227b2b6c8a0311e6552b4eccfe79fe
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (titleMapCache != null)
                {
                    titleMapCache.EnableOutLine(false);
                    titleMapCache = null;
                }
<<<<<<< HEAD
=======
                if (tankCache != null)
                {
                    tankCache.EnableRangeAtt(false);
                    tankCache = null;
                }
>>>>>>> 2a9a859e8e227b2b6c8a0311e6552b4eccfe79fe
            }
        }
    }
}
