namespace Application.Extenions
{
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

    public static partial class ImageProcessingHelper
    {
        public static async Task<byte[]> CompressImageAsync(byte[] imageBytes, TargetSize targetSize, PngBitDepth bitDepth)
        {
            using var inputStream = new MemoryStream(imageBytes);
            using var image = Image.Load(inputStream);

            int targetWidth = (int)targetSize;
            int targetHeight = (int)targetSize;

            // Calculate the aspect ratio
            float aspectRatio = (float)image.Width / image.Height;

            // Adjust target dimensions to maintain aspect ratio
            if (aspectRatio > 1)
            {
                targetHeight = (int)(targetWidth / aspectRatio);
            }
            else
            {
                targetWidth = (int)(targetHeight * aspectRatio);
            }

            // Resize the image
            image.Mutate(x => x
                .Resize(new ResizeOptions
                {
                    Size = new Size(targetWidth, targetHeight),
                    Mode = ResizeMode.Pad,
                    PadColor = Color.Transparent
                })
                .AutoOrient()
                .Grayscale()
            );

            // Configure the encoder
            var encoder = new PngEncoder
            {
                CompressionLevel = PngCompressionLevel.BestCompression,
                ColorType = PngColorType.Palette,
                BitDepth = bitDepth
            };

            // Save compressed image to byte array
            using var outputStream = new MemoryStream();
            await image.SaveAsync(outputStream, encoder);
            return outputStream.ToArray();
        }
    }
}
