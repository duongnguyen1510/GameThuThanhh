using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoangAnh
{
    public class SpawnMapHA : MonoBehaviour
    {
        [Space, Header("Title Map Prefab")]
        [SerializeField] private TitleMapHA titleMapHaPrefab;
        [SerializeField] private Transform transSpawnLevel;
        public List<TitleMapHA> ListPath = new List<TitleMapHA>();
        
        /// <summary>
        /// 0. Title Way, 1. Title Tank 
        /// </summary>
        private int[,] maps = new int[,]
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 0, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 0, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };
        
        private List<TitleMapHA> listTitlesMap = new List<TitleMapHA>();
        private void Start()
        {
            float spacing = 1f;
            int rows = maps.GetLength(0);
            int columns = maps.GetLength(1);
            float offsetX = (columns - 1) / 2f;
            float offsetY = (rows - 1) / 2f;
            int index = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TitleMapHA title = Instantiate(titleMapHaPrefab, transSpawnLevel);
                    title.transform.name = $"TitleMap_{index}";
                    index++;
                    float posX = (j - offsetX) * spacing;
                    float posZ = -(i - offsetY) * spacing;
                    title.transform.localPosition = new Vector3(posX, 0, posZ);
                    int valueMap = maps[i, j];
                    title.SetupTitleMap((ETitleMapHA)valueMap, j, i);
                    listTitlesMap.Add(title);
                }
            }
            ListPath = FindPathAuto();
        }

        private List<TitleMapHA> FindPathAuto()
        {
            int rows = maps.GetLength(0);
            int cols = maps.GetLength(1);
            bool[,] visited = new bool[rows, cols];

            Vector2Int start = new Vector2Int(-1, -1);
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (maps[y, x] == 0)
                    {
                        start = new Vector2Int(x, y);
                        break;
                    }
                }
                if (start.x != -1) break;
            }

            if (start.x == -1)
            {
                Debug.LogWarning("Không tìm thấy điểm bắt đầu.");
                return new List<TitleMapHA>();
            }

            List<Vector2Int> pathCoords = new List<Vector2Int>();
            Queue<Vector2Int> queue = new Queue<Vector2Int>();
            queue.Enqueue(start);
            visited[start.y, start.x] = true;

            Vector2Int[] directions = new Vector2Int[]
            {
                new Vector2Int(0, 1),   // Right
                new Vector2Int(1, 0),   // Down
                new Vector2Int(0, -1),  // Left
                new Vector2Int(-1, 0)   // Up
            };

            while (queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();
                pathCoords.Add(current);

                foreach (var dir in directions)
                {
                    Vector2Int next = current + dir;
                    if (next.x >= 0 && next.x < cols &&
                        next.y >= 0 && next.y < rows &&
                        !visited[next.y, next.x] &&
                        maps[next.y, next.x] == 0)
                    {
                        visited[next.y, next.x] = true;
                        queue.Enqueue(next);
                        break;
                    }
                }
            }

            List<TitleMapHA> result = new List<TitleMapHA>();
            foreach (var coord in pathCoords)
            {
                foreach (var title in listTitlesMap)
                {
                    if (title.column == coord.x && title.row == coord.y)
                    {
                        result.Add(title);
                        break;
                    }
                }
            }

            return result;
        }
    }
}
