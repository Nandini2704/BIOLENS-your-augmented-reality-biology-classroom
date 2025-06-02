using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Unity.Barracuda;
using UnityEngine.Android;

public class ImageUploader : MonoBehaviour
{
    public Button uploadButton;
    public Text resultText;
    public GameObject leafOptionsPanel;
    public GameObject flowerOptionsPanel;
    public NNModel modelAsset;

    private Model runtimeModel;
    private IWorker worker;

    void Start()
    {
        runtimeModel = ModelLoader.Load(modelAsset);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.Auto, runtimeModel);
        Debug.Log("✅ ONNX Model Loaded!");

        uploadButton.onClick.AddListener(PickImage);
        
        // Request permissions
        if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
        {
            Permission.RequestUserPermission(Permission.ExternalStorageRead);
        }
    }

    void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            if (path != null)
            {
                Debug.Log("📸 Image Path: " + path);
                byte[] imageBytes = File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(2, 2);
                texture.LoadImage(imageBytes);
                
                ClassifyImage(texture);
            }
        }, "Select an image", "image/*");
    }

    void ClassifyImage(Texture2D image)
    {
        Tensor inputTensor = PreprocessImage(image);
        worker.Execute(inputTensor);
        Tensor outputTensor = worker.PeekOutput();

        string predictedClass = GetPredictedClass(outputTensor);
        resultText.text = "Prediction: " + predictedClass;
        Debug.Log("🌿 Predicted Class: " + predictedClass);

        HandlePrediction(predictedClass);
    }

    Tensor PreprocessImage(Texture2D image)
    {
        int width = 224;
        int height = 224;
        Texture2D resizedImage = new Texture2D(width, height);
        Graphics.ConvertTexture(image, resizedImage);

        float[] inputTensorData = new float[width * height * 3];
        Color[] pixels = resizedImage.GetPixels();

        for (int i = 0; i < pixels.Length; i++)
        {
            inputTensorData[i * 3] = pixels[i].r;
            inputTensorData[i * 3 + 1] = pixels[i].g;
            inputTensorData[i * 3 + 2] = pixels[i].b;
        }

        return new Tensor(1, 3, width, height, inputTensorData);
    }

    string GetPredictedClass(Tensor outputTensor)
    {
        float maxVal = float.MinValue;
        int maxIndex = 0;

        for (int i = 0; i < outputTensor.length; i++)
        {
            if (outputTensor[i] > maxVal)
            {
                maxVal = outputTensor[i];
                maxIndex = i;
            }
        }

        if (maxIndex == 0) return "Leaf";
        if (maxIndex == 1) return "Flower";
        return "Unknown";
    }

    void HandlePrediction(string predictedClass)
    {
        leafOptionsPanel.SetActive(false);
        flowerOptionsPanel.SetActive(false);

        if (predictedClass == "Leaf")
        {
            leafOptionsPanel.SetActive(true);
        }
        else if (predictedClass == "Flower")
        {
            flowerOptionsPanel.SetActive(true);
        }
    }

    void OnDestroy()
    {
        worker?.Dispose();
    }
}
// This script handles image uploading, classification using an ONNX model, and displays the results.
// It uses Unity's Barracuda library for model inference and NativeGallery for image selection.
// Ensure you have the Barracuda package installed and the ONNX model is correctly set up in Unity.
// The script also manages user permissions for accessing external storage on Android devices.
// Make sure to test the image classification functionality with various images to ensure accuracy and performance.
// Ensure that the model is trained to recognize the classes "Leaf" and "Flower" for accurate predictions.
// The script also includes UI elements for displaying the results and options based on the classification.
// Ensure that the UI elements (uploadButton, resultText, leafOptionsPanel, flowerOptionsPanel) are assigned in the Unity Editor.   
// The script should be attached to a GameObject in your scene, and the UI elements should be linked in the Inspector.
// Make sure to handle any exceptions or errors that may occur during image processing or model inference.
// Ensure that the model is compatible with Barracuda and properly configured in Unity.
// This script is designed to be used in a Unity project where you want to classify images of leaves and flowers using a pre-trained ONNX model.
