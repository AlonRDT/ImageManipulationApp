namespace Backend
{
    [System.Serializable]
    public class Kernel
    {
        public string KernelName { get; }

        public int KernelHeight { get; }

        public int KernelWidth { get; }

        public float[,] KernelMatrix { get; }

        public Kernel(string i_KernelName, int i_KernelHeight, int i_KernelWidth, float[,] i_KernelMatrix)
        {
            KernelName = i_KernelName;
            KernelHeight = i_KernelHeight;
            KernelWidth = i_KernelWidth;
            float[,] newKernelMatrix = new float[i_KernelWidth, i_KernelHeight];
            for (int i = 0; i < i_KernelHeight; i++)
            {
                for (int j = 0; j < i_KernelWidth; j++)
                {
                    newKernelMatrix[j, i] = i_KernelMatrix[j, i];
                }
            }

            KernelMatrix = newKernelMatrix;
        }
    }
}
