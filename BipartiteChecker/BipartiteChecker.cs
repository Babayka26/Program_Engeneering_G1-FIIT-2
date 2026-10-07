using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BipartiteChecker
{
    public static class BipartiteChecker
    {
        /// <summary>
        /// Проверяет граф на двудольность.
        /// graph[v] — список соседей вершины v.
        /// Возвращает (isBipartite, colors), где colors[v] ∈ {0, 1} — цвет вершины.
        /// Для несвязных графов обрабатывает каждую компоненту.
        /// </summary>
        public static (bool isBipartite, int[] colors) Check(List<int>[] graph)
        {
            int n = graph.Length;
            var colors = new int[n];
            Array.Fill(colors, -1); // -1 = не покрашена

            var queue = new Queue<int>(n);

            for (int start = 0; start < n; start++)
            {
                if (colors[start] != -1) continue;

                colors[start] = 0;
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    int v = queue.Dequeue();

                    foreach (int u in graph[v])
                    {
                        if (colors[u] == -1)
                        {
                            colors[u] = colors[v] ^ 1; // инвертируем цвет: 0 <-> 1
                            queue.Enqueue(u);
                        }
                        else if (colors[u] == colors[v])
                        {
                            return (false, colors); // конфликт — не двудольный
                        }
                    }
                }
            }

            return (true, colors);
        }
    }
}
