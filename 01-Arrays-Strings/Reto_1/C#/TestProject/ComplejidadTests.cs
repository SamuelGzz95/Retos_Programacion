using System.Diagnostics;
using Xunit.Abstractions;

namespace TestProject
{
    public class ComplejidadTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

        [Fact]
        public void Tiempo_DebeSerLineal()
        {
            var tiempos = new Dictionary<int, long>();

            foreach (var n in new[] { 1000, 2000, 4000, 8000 })
            {
                Random rnd = new Random();

                var sw = Stopwatch.StartNew();
                //int[] num = { 2, 7, 11, 15 };
                int[] arr = Enumerable.Range(1, n).ToArray();

                int target = rnd.Next(n, n * 2);
                for (int i = 0; i < 100; i++) // Repetir para medición más precisa
                    ConsoleApp.TwoSum.FindTwoSum(arr, target);

                sw.Stop();
                tiempos[n] = sw.ElapsedMilliseconds;
            }

            // Verificar que la relación sea aproximadamente lineal
            var ratio = (double)tiempos[2000] / tiempos[1000];
            Assert.True(ratio >= 1.5 && ratio <= 2.5,
                $"La complejidad no parece ser O(n). Ratio: {ratio}");
        }

        [Fact]
        public void Espacio_DebeSerLineal()
        {
            var memorias = new Dictionary<int, long>();

            foreach (var n in new[] { 1000, 2000, 4000, 8000 })
            {
                Random rnd = new Random();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                var before = GC.GetTotalMemory(true);
                int[] num = Enumerable.Range(1, n).ToArray();
                //int[] num = { 2, 7, 11, 15 };
                int target = rnd.Next(n, n * 2);
                var resultado = ConsoleApp.TwoSum.FindTwoSum(num, target);
                var after = GC.GetTotalMemory(false);

                memorias[n] = after - before;
            }

            var ratio = (double)memorias[2000] / memorias[1000];
            Assert.True(ratio >= 1.5 && ratio <= 2.5,
                $"El espacio no parece ser O(n). Ratio: {ratio}");
        }

        [Fact]
        public void ProbarComplejidad()
        {
            var tamaños = new[] { 1000, 2000, 4000, 8000 };
            long[] tiempos = new long[] { 0, 0, 0, 0, 0 };
            _output.WriteLine($"========== Probando con tamaño:  ==========");
            int i = 0;
            foreach (var n in tamaños)
            {
                Random rnd = new Random();
                var arr = Enumerable.Range(1, n).ToArray();
                // Medir tiempo
                var sw = Stopwatch.StartNew();
                var memoryBefore = GC.GetTotalMemory(true);

                //int[] num = { 2, 7, 11, 15 };
                int target = rnd.Next(n, n * 2);
                var resultado = ConsoleApp.TwoSum.FindTwoSum(arr, target);

                var memoryAfter = GC.GetTotalMemory(false);
                sw.Stop();

                var memoryUsed = (memoryAfter - memoryBefore) / 1024.0;

                _output.WriteLine($"{n}\t{sw.ElapsedMilliseconds}\t{memoryUsed:F2}");
                _output.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
                _output.WriteLine($"Memoria: {memoryUsed:F2} KB");
                //_output.WriteLine($"Elementos procesados: {resultado.Length}");
                _output.WriteLine($"Tiempo por elemento: {sw.ElapsedMilliseconds / (double)n:F6} ms");
                _output.WriteLine("");
                tiempos[i] = sw.ElapsedMilliseconds;
                i++;
            }
            ScottPlot.Plot myPlot = new();
            myPlot.Add.Scatter(tamaños, tiempos);
            myPlot.Title("Complejidad Temporal - O(n)");
            myPlot.XLabel("Tamaño del array (n)");
            myPlot.YLabel("Tiempo (ms)");
            myPlot.SavePng("quickstart.png", 400, 300);
            //plt.AddScatter(tamaños, tiempos);

            //plt.SaveFig("complejidad.png");
            Assert.True(true);
        }
    }
}
