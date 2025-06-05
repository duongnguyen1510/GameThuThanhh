using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace HoangAnh
{
    public enum ETitleMapHA
    {
        TANK = 1,
        WALL = 0
    }
    public class TitleMapHA : MonoBehaviour
    {
        [FormerlySerializedAs("TypeTitleMap")] 
		[Space, Header("Data Title")] 
        public ETitleMapHA typeTitleMapHa;
        public int column;
        public int row;

        [Space, Header("GameObjTitle")] 
        [SerializeField] private GameObject objTitleTank;
        [SerializeField] private GameObject objTitleWall;

        public void SetupTitleMap(ETitleMapHA type, int column, int row)
        {
            this.column = column;
            this.row = row;
            ResetData();
            typeTitleMapHa = type;
            switch (type)
            {
                case ETitleMapHA.TANK:
                    objTitleTank.SetActive(true);
                    break;
                case ETitleMapHA.WALL:
                    objTitleWall.SetActive(true);
                    break;
            }
        }

        public void ResetData()
        {
            objTitleTank.SetActive(false);
            objTitleWall.SetActive(false);
        }
    }
}
