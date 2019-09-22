using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Backend
{
    [System.Serializable]
    class Database
    {
        public List<Kernel> m_Kernels;

        private Database()
        {
        }

        public static Database LoadFromFile()
        {
            Database onStartIMDB = new Database();
            if (File.Exists("ImageAppData.bin"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    using (var file = File.OpenRead("ImageAppData.bin"))
                    {
                        var obj = formatter.Deserialize(file);
                        onStartIMDB = obj as Database;
                    }
                }
                catch
                {
                    File.Delete("ImageAppData.bin");
                    onStartIMDB.initializeWhenThereIsNoFile();
                }
            }
            else
            {
                onStartIMDB.initializeWhenThereIsNoFile();
            }

            return onStartIMDB;
        }

        private void initializeWhenThereIsNoFile()
        {
            m_Kernels = new List<Kernel>();
            addBasicKernelsToKernelPool();
        }

        public Kernel GetKernelByName(string i_KernelName)
        {
            Kernel resultKernel = null;
            foreach (Kernel kernel in m_Kernels)
            {
                if (kernel.KernelName == i_KernelName)
                {
                    resultKernel = kernel;
                }
            }

            return resultKernel;
        }

        public void DeleteKernelFromPool(string i_KernelName)
        {
            Kernel targetKernelForDeletion = null;
            foreach (Kernel kernel in m_Kernels)
            {
                if (kernel.KernelName == i_KernelName)
                {
                    targetKernelForDeletion = kernel;
                }
            }

            m_Kernels.Remove(targetKernelForDeletion);
        }

        public void addNewKernel(Kernel i_NewKernel)
        {
            m_Kernels.Add(i_NewKernel);
        }

        private void addBasicKernelsToKernelPool()
        {
            float[,] sharpenKernelMatrix = new float[3, 3];
            sharpenKernelMatrix[0, 0] = sharpenKernelMatrix[0, 2] = sharpenKernelMatrix[2, 0] = sharpenKernelMatrix[2, 2] = 0;
            sharpenKernelMatrix[0, 1] = sharpenKernelMatrix[1, 0] = sharpenKernelMatrix[1, 2] = sharpenKernelMatrix[2, 1] = -1;
            sharpenKernelMatrix[1, 1] = 5;
            float[,] gassuianBlurKernelMatrix = new float[3, 3];
            gassuianBlurKernelMatrix[0, 0] = gassuianBlurKernelMatrix[0, 2] = gassuianBlurKernelMatrix[2, 0] = gassuianBlurKernelMatrix[2, 2] = 0.0625f;
            gassuianBlurKernelMatrix[0, 1] = gassuianBlurKernelMatrix[1, 0] = gassuianBlurKernelMatrix[1, 2] = gassuianBlurKernelMatrix[2, 1] = 0.125f;
            gassuianBlurKernelMatrix[1, 1] = 0.25f;
            Kernel sharpKernel = new Kernel("Sharpen Kernel", 3, 3, sharpenKernelMatrix);
            Kernel gaussKernel = new Kernel("Gaussian Blur Kernel", 3, 3, gassuianBlurKernelMatrix);
            m_Kernels.Add(sharpKernel);
            m_Kernels.Add(gaussKernel);
        }

        public void SaveToFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var file = File.Create("ImageAppData.bin"))
            {
                formatter.Serialize(file, this);
            }
        }

        public bool isNameAlreadyInKernelPool(string i_NewKernelName)
        {
            bool result = false;
            foreach (Kernel currentKernel in m_Kernels)
            {
                if (i_NewKernelName == currentKernel.KernelName)
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
