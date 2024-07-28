namespace Application.Extenions
{
    using SixLabors.ImageSharp;
    using SixLabors.ImageSharp.Formats.Png;
    using SixLabors.ImageSharp.Processing;

    public static class ImageProcessingHelper
    {
        public static async Task<byte[]> CompressImageAsync(byte[] imageBytes, int sizeReductionFactor, int dpiReductionFactor, PngBitDepth bitDepth)
        {
            using var inputStream = new MemoryStream(imageBytes);
            using var image = Image.Load(inputStream);

            var originalWidth = image.Width;
            var originalHeight = image.Height;
            var newWidth = originalWidth / sizeReductionFactor;
            var newHeight = originalHeight / sizeReductionFactor;

            image.Mutate(x => x.Resize(newWidth, newHeight));

            var encoder = new PngEncoder
            {
                CompressionLevel = PngCompressionLevel.BestCompression,
                ColorType = PngColorType.Palette,
                BitDepth = bitDepth
            };

            // Reduce the DPI
            image.Metadata.HorizontalResolution /= dpiReductionFactor;
            image.Metadata.VerticalResolution /= dpiReductionFactor;

            // Save compressed image to byte array
            using var outputStream = new MemoryStream();
            await image.SaveAsync(outputStream, encoder);
            return outputStream.ToArray();
        }
    }
}
