namespace BipartiteChecker
{
    internal class Demonstration
    {
        static void Main(string[] args)
        {
            // Граф: 0-1, 1-2, 2-3, 3-0  (цикл длины 4 — двудольный)
            var g1 = new List<int>[4];
            for (int i = 0; i < 4; i++) g1[i] = new List<int>();
            void AddEdge(List<int>[] g, int a, int b) { g[a].Add(b); g[b].Add(a); }

            AddEdge(g1, 0, 1); AddEdge(g1, 1, 2); AddEdge(g1, 2, 3); AddEdge(g1, 3, 0);
            Console.WriteLine(BipartiteChecker.Check(g1).isBipartite); // True

            // Треугольник 0-1-2  (цикл длины 3 — не двудольный)
            var g2 = new List<int>[3];
            for (int i = 0; i < 3; i++) g2[i] = new List<int>();
            AddEdge(g2, 0, 1); AddEdge(g2, 1, 2); AddEdge(g2, 2, 0);
            Console.WriteLine(BipartiteChecker.Check(g2).isBipartite); // False
        }
    }
}
