using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class EnemyHA : MonoBehaviour
    {
        public List<TitleMapHA> ListPath = new List<TitleMapHA>();
        public float speed = 1;
        public void SetupData(List<TitleMapHA> ListPath)
        {
            this.ListPath = new List<TitleMapHA>(ListPath);
        }
        
        public void Update()
        {
            if (ListPath.Count > 0)
            {
                TitleMapHA titleTarget = ListPath[0];
                Vector3 positionTarget = new Vector3(titleTarget.transform.position.x, transform.position.y, titleTarget.transform.position.z);
                float distance = Vector3.Distance(transform.position, positionTarget);
                if (distance > 0.05f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, positionTarget, speed * Time.deltaTime);
                }
                else
                {
                    ListPath.RemoveAt(0);
                    if (ListPath.Count <= 0)
                    {
                        Debug.Log("Thua");
                    }
                }
            }
        }
    }
}
