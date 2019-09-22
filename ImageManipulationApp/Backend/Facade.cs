using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Backend
{
    public class Facade
    {
        private Action ShowLoading { get; set; }

        private Database ImageManipulatorDatabase { get; set; }

        private Thread GenerateNewProcessedImageThread { get; set; }

        public Convolver ImageManipulationConvolver { get; }

        public RadioButtonCommands PossibleImageFormats { get; set; }

        public int MaxKernelSize { get; } = 7;

        public int KernelHeight { get; set; }

        public int KernelWidth { get; set; }

        public float[,] CurrentKernel { get; set; }

        public Facade(Action<Bitmap> i_ChangeResultImageFunction, Bitmap i_StartImage, Action i_ShowLoading)
        {
            ImageManipulationConvolver = new Convolver(i_ChangeResultImageFunction, i_StartImage);
            ShowLoading = i_ShowLoading;
            ImageManipulatorDatabase = Database.LoadFromFile();
            KernelHeight = MaxKernelSize;
            KernelWidth = MaxKernelSize;
            PossibleImageFormats = new RadioButtonCommands();
            ////Databinded Textboxes initialize values
            CurrentKernel = new float[MaxKernelSize, MaxKernelSize];
        }

        public Kernel PassNewKernelToBackend(string i_KernelName)
        {
            Kernel newKernel = new Kernel(i_KernelName, KernelHeight, KernelWidth, CurrentKernel);
            ImageManipulatorDatabase.addNewKernel(newKernel);
            return newKernel;
        }

        public List<Kernel> GetKernelsDatabase()
        {
            return ImageManipulatorDatabase.m_Kernels;
        }

        public void SaveBackendToFile()
        {
            ImageManipulatorDatabase.SaveToFile();
        }

        public bool isNameAlreadyInKernelPool(string i_NewKernelName)
        {
            return ImageManipulatorDatabase.isNameAlreadyInKernelPool(i_NewKernelName);
        }

        public void DeleteKernelFromPool(string i_KernelName)
        {
            ImageManipulatorDatabase.DeleteKernelFromPool(i_KernelName);
        }

        public void ProcessImage(Bitmap i_ImageBeforeProcessing = null)
        {
            if (GenerateNewProcessedImageThread != null && GenerateNewProcessedImageThread.ThreadState == ThreadState.Running)
            {
                GenerateNewProcessedImageThread.Abort();
            }
            ShowLoading.Invoke();
            GenerateNewProcessedImageThread = new Thread(() => ImageManipulationConvolver.Convolve(KernelHeight, KernelWidth, CurrentKernel, i_ImageBeforeProcessing));
            GenerateNewProcessedImageThread.Start();
        }

        public void UpdateCurrentKernel(float i_UserInput, int i_CellIndexes)
        {
            CurrentKernel[i_CellIndexes % 7, i_CellIndexes / 7] = i_UserInput;
        }
    }
}
