using Backend;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ImageManipulationApp
{
    public partial class MainForm : Form
    {
        private FloatTextboxProxy[,] m_KernelTextBoxes;
        private List<RadioButton> m_RadioButtons;
        private Facade m_ImageManipulationFacade;

        public MainForm()
        {
            InitializeComponent();
            facadeAndDataSetup();
            initializeExplanation();
        }

        protected override void OnLoad(EventArgs e)
        {
            new Thread(() => fetchKernels()).Start();
            base.OnLoad(e);
        }

        private void facadeAndDataSetup()
        {
            try
            {
                pictureBoxImage.Load(@"..\..\..\Image.jpg");
                labelBrowseImageResult.Text = "Defualt Image found";
            }
            catch
            {
                pictureBoxImage.Image = new Bitmap(250, 250);
                labelBrowseImageResult.Text = "Default Image not found";
            }
            finally
            {
                m_ImageManipulationFacade = new Facade(generateAndDisplayResultImage, new Bitmap(pictureBoxImage.Image), showLoading);
                textBoxKernelHeight.MaxLength = 1;
                textBoxKernelHeight.Text = m_ImageManipulationFacade.KernelHeight.ToString();
                textBoxKernelWidth.MaxLength = 1;
                textBoxKernelWidth.Text = m_ImageManipulationFacade.KernelWidth.ToString();
                m_KernelTextBoxes = new FloatTextboxProxy[m_ImageManipulationFacade.MaxKernelSize,
                    m_ImageManipulationFacade.MaxKernelSize];
                configureTextBoxes();
                showOnlyRelevantTextBoxes();
                m_ImageManipulationFacade.ProcessImage(new Bitmap(pictureBoxImage.Image));
                m_RadioButtons = new List<RadioButton>();
                generateImageFormatRadioButtons();
            }  
        }

        private void initializeExplanation()
        {
            StringBuilder explanationText = new StringBuilder(
@"Welcome to the Image Manipulation App.
In this app you will choose a photo and a kernel to to experience the magical world of image processing.

At the tab named choose image you will be able to choose from all the pictures in your albums,
in case you dont have any the deafult picture will always be your profile picture.

At the tab named choose Kernel you can build your own Kernel or Choose from one of our premade ones.
Clarification: A Kernel is a matrix with which we build a new image by multiplying the kernel matirx with 
the matching pixels in an image.

All that's left is to jump over to the result tab and enjoy the magic.

Be sure to recommend our app to your friends.
");
            labelImageAppExplanation.Text = explanationText.ToString();
        }

        private void showLoading()
        {
            labelInProgress.Text = "Processing Image\nDuration: around a minute";
        }

        private void configureTextBoxes()
        {
            for (int i = 0; i < m_ImageManipulationFacade.MaxKernelSize; i++)
            {
                for (int j = 0; j < m_ImageManipulationFacade.MaxKernelSize; j++)
                {
                    m_KernelTextBoxes[i, j] = new FloatTextboxProxy(m_ImageManipulationFacade, i, j);
                    tabControlImageManiplation.GetControl(2).Controls.Add(m_KernelTextBoxes[i, j]);
                }
            }
        }

        private void generateImageFormatRadioButtons()
        {
            RadioButton newRadioButton;
            int XLocationValue = 10, YLocationValue = 5;
            bool isFirst = true;

            foreach (ChangeImageFormatCommandInfo currentCommand in m_ImageManipulationFacade.PossibleImageFormats)
            {
                newRadioButton = new RadioButtonWIthCommand(currentCommand, m_ImageManipulationFacade);
                newRadioButton.Location = new Point(XLocationValue, YLocationValue);
                YLocationValue += 20;
                if (isFirst)
                {
                    newRadioButton.Checked = true;
                    isFirst = false;
                }

                tabControlImageManiplation.GetControl(3).Controls.Add(newRadioButton);
                m_RadioButtons.Add(newRadioButton);
            }
        }

        private void showOnlyRelevantTextBoxes()
        {
            foreach (TextBox currentTextBox in m_KernelTextBoxes)
            {
                currentTextBox.Enabled = false;
                currentTextBox.Visible = false;
            }

            for (int i = 0; i < m_ImageManipulationFacade.KernelWidth; i++)
            {
                for (int j = 0; j < m_ImageManipulationFacade.KernelHeight; j++)
                {
                    m_KernelTextBoxes[i, j].Enabled = true;
                    m_KernelTextBoxes[i, j].Visible = true;
                }
            }
        }

        private void textBoxKernelLengthOrWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar == '8') &&
                (e.KeyChar == '9') && (e.KeyChar == '0'))
            {
                e.Handled = true;
            }
            else
            {
                char userInput = e.KeyChar;
                int newValue = userInput - '0';
                if (((TextBox)sender).TabIndex == 210)
                {
                    m_ImageManipulationFacade.KernelWidth = newValue;
                }
                else
                {
                    m_ImageManipulationFacade.KernelHeight = newValue;
                }
            }

            showOnlyRelevantTextBoxes();
            m_ImageManipulationFacade.ProcessImage(new Bitmap(pictureBoxImage.Image));
        }

        private void fetchKernels()
        {
            listBoxKernel.Invoke(new Action(() => listBoxKernel.DisplayMember = "KernelName"));
            foreach (Kernel kernel in m_ImageManipulationFacade.GetKernelsDatabase())
            {
                listBoxKernel.Invoke(new Action(() => listBoxKernel.Items.Add(kernel)));
            }
        }

        private void listBoxKernel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Kernel desiredKernel = listBoxKernel.SelectedItem as Kernel;
                for (int i = 0; i < desiredKernel.KernelWidth; i++)
                {
                    for (int j = 0; j < desiredKernel.KernelHeight; j++)
                    {
                        m_KernelTextBoxes[i, j].SetTextWithoutImageProcessing(desiredKernel.KernelMatrix[i, j].ToString());
                        m_ImageManipulationFacade.CurrentKernel[i, j] = desiredKernel.KernelMatrix[i, j];
                    }
                }

                m_ImageManipulationFacade.KernelHeight = desiredKernel.KernelHeight;
                m_ImageManipulationFacade.KernelWidth = desiredKernel.KernelWidth;
                textBoxKernelHeight.Text = desiredKernel.KernelHeight.ToString();
                textBoxKernelWidth.Text = desiredKernel.KernelWidth.ToString();
                showOnlyRelevantTextBoxes();
                m_ImageManipulationFacade.ProcessImage(new Bitmap(pictureBoxImage.Image));
            }
            catch
            {
            }
        }

        private void ButtonSaveKernel_Click(object sender, EventArgs e)
        {
            string newKernelName = textBoxNewKernelName.Text;
            if (newKernelName != string.Empty)
            {
                StringBuilder modifyNewKernelNameUntilItIsUnique = new StringBuilder(newKernelName);
                while (m_ImageManipulationFacade.isNameAlreadyInKernelPool(modifyNewKernelNameUntilItIsUnique.ToString()))
                {
                    modifyNewKernelNameUntilItIsUnique.Append("1");
                }

                listBoxKernel.Items.Add(m_ImageManipulationFacade.PassNewKernelToBackend(modifyNewKernelNameUntilItIsUnique.ToString()));
            }
        }

        private void buttonGetImage_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            Image currentImage = pictureBoxImage.Image;
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    pictureBoxImage.Load(file);
                    labelBrowseImageResult.Text = "        File is valid";
                    m_ImageManipulationFacade.ProcessImage(new Bitmap(pictureBoxImage.Image));
                }
                catch
                {
                    pictureBoxImage.Image = currentImage;
                    labelBrowseImageResult.Text = "File type not supported";
                }
            }
        }

        private void ButtonDeleteKernel_Click(object sender, EventArgs e)
        {
            m_ImageManipulationFacade.DeleteKernelFromPool(listBoxKernel.GetItemText(listBoxKernel.SelectedItem));
            listBoxKernel.Items.Remove(listBoxKernel.SelectedItem);
        }

        private void generateAndDisplayResultImage(Bitmap i_NewProcessedImage)
        {
            labelInProgress.Invoke(new Action(() => labelInProgress.Text = "Processing Complete"));
            pictureBoxResult.Image = i_NewProcessedImage;
        }

        private void ImageManipulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_ImageManipulationFacade.SaveBackendToFile();
        }
    }
}
