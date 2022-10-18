using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace computervision
{
    class Program
    {
        static string l_subscriptionKey = "";
        static string l_endpoint = "";
        
        private const string my_image = "";
        static void Main(string[] args)
        {
            Analyze().GetAwaiter().GetResult();
            Console.WriteLine("End of Program");
            Console.Read();
        }

        public static async Task Analyze()
        {
            ComputerVisionClient client =
            new ComputerVisionClient(new ApiKeyServiceClientCredentials(l_subscriptionKey))
            { Endpoint = l_endpoint };

            Console.WriteLine("Let's Analyze the Image");
            List<VisualFeatureTypes?> features = new List<VisualFeatureTypes?>()
            {
                VisualFeatureTypes.Categories, VisualFeatureTypes.Description
            };

            ImageAnalysis l_results = await client.AnalyzeImageAsync(my_image, features);

            // Getting the description of the image
            Console.WriteLine("Getting the caption for the image");
            foreach (var caption in l_results.Description.Captions)
            {
                Console.WriteLine(caption.Text);
                Console.WriteLine(caption.Confidence);
            }
        }
    }
}
