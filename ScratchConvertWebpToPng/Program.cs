using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;

static void ConvertWebpToPng(string webpPath, string pngPath)
{
	using var image = Image.Load(new WebpDecoderOptions().GeneralOptions, webpPath);
	image.Save(pngPath, new PngEncoder());

}

// Example usage:
// ConvertWebpToPng("input.webp", "output.png");
