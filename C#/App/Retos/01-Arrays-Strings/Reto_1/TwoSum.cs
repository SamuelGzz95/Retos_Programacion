
namespace App.Retos._01_Arrays_Strings.Reto_1
{
    internal static class TwoSum
    {
        public static int[]? FindTwoSum(int[] nums, int target)
        {
            int[]? result = null;
            if (nums.Length < 2)
                return result;

            int idx1 = 0;
            int idx2 = 1;

            while (idx1 < nums.Length - 1)
            {
                //if (nums[idx1] > target || nums[idx2] > target)
                //    continue;
                if (nums[idx1] + nums[idx2] == target)
                    return [idx1, idx2];

                if (idx2 == nums.Length - 1)
                {
                    idx1++;
                    idx2 = idx1 + 1;
                }
                else
                    idx2++;
            }
            return result;
        }
        /// <summary>
        /// Encuentra dos índices en el array que sumen el target
        /// </summary>
        /// <param name="nums">Array de enteros</param>
        /// <param name="target">Valor objetivo</param>
        /// <returns>Array con los dos índices [i, j]</returns>
        /// <exception cref="ArgumentNullException">Si nums es null</exception>
        /// <exception cref="ArgumentException">Si no hay solución</exception>
        public static int[]? FindTwoSum_IA(int[] nums, int target)
        {
            // Validaciones
            if (nums == null)
                return null;
                //throw new ArgumentNullException(nameof(nums));

            if (nums.Length < 2)
                return null;
            //throw new ArgumentException("Array debe tener al menos 2 elementos", nameof(nums));

            // Dictionary para almacenar: valor -> índice
            var numToIndex = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // Si el complemento existe en el diccionario, encontramos la solución
                if (numToIndex.ContainsKey(complement))
                {
                    return new int[] { numToIndex[complement], i };
                }

                // Almacenar el número actual y su índice
                // Solo agregamos si no existe para evitar duplicados
                if (!numToIndex.ContainsKey(nums[i]))
                {
                    numToIndex[nums[i]] = i;
                }
            }
            return null;
            //throw new ArgumentException("No se encontró una solución válida");
        }
    }
}
