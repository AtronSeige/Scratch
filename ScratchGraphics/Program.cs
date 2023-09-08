using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ScratchGraphics {
	internal class Program {
		static void Main(string[] args) {
			try {
				ImageFormat format = ImageFormat.Bmp;

				string origFileName = $"{System.IO.Directory.GetCurrentDirectory()}\\artifacts\\penguins_original.bmp";
				string rotateFileName = $"{System.IO.Directory.GetCurrentDirectory()}\\artifacts\\penguins_original_Rotated_180.bmp";

				if (File.Exists(rotateFileName)) {
					File.Delete(rotateFileName);
				}

				// Read the original File
				Image origImage = Image.FromFile(origFileName);

				// Read the original file again, but this time we will rotate it
				Image rotateImage = Image.FromFile(origFileName);

				// Rotate the image 180 degrees
				Point point = new Point(rotateImage.Width / 2, rotateImage.Height / 2);
				rotateImage = Rotate(ref rotateImage, (Single)180, point);

				// Save the output
				rotateImage.Save(rotateFileName, format);

				// Read the rotated file
				Image rotateTestImage = Image.FromFile(rotateFileName);

				// compare the files
				Bitmap origBitmap = new Bitmap(origImage);
				Bitmap rotateBitmap = new Bitmap(rotateImage);
				Bitmap rotateTestBitmap = new Bitmap(rotateTestImage);

				if (rotateBitmap.Height != rotateTestBitmap.Height) {
					Console.WriteLine("Height does not match");
				}

				if (rotateBitmap.Width != rotateTestBitmap.Width) {
					Console.WriteLine("Width does not match");
				}

				if (rotateBitmap.Size != rotateTestBitmap.Size) {
					Console.WriteLine("Size does not match");
				}

				for (int x = 0; x < rotateBitmap.Width; x += 1) {
					for (int y = 0; y < rotateBitmap.Height; y += 1) {
						if (rotateBitmap.GetPixel(x, y) != rotateTestBitmap.GetPixel(x, y)) {
							Console.WriteLine($"Rotate .GetPixel({x}, {y}) does not match");
						}
					}
				}

				for (int x = 0; x < origBitmap.Width; x += 1) {
					for (int y = 0; y < origBitmap.Height; y += 1) {
						if (origBitmap.GetPixel(x, y) != rotateTestBitmap.GetPixel(rotateTestBitmap.Width - x - 1, rotateTestBitmap.Height - y - 1)) {
							Console.WriteLine($"Orig.GetPixel({x}, {y}) does not match");
						}
					}
				}


			} catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
            Console.WriteLine("Done");
            Console.ReadLine();
		}

		/// <summary>Rotates the underlying instance image the specified number of degrees clockwise around the given rotation point.</summary>
		/// <param name="input">Image to rotate.</param>
		/// <param name="angle">Degrees to rotate the image.</param>
		/// <param name="rotationPoint">Center of rotation.</param>
		public static Image Rotate(ref Image input, Single angle, Point rotationPoint) {
			int iWidth = input.Width;
			int iHeight = input.Height;

			Bitmap oBitmap = new Bitmap(iWidth, iHeight);
			System.Drawing.Graphics oGraphics = System.Drawing.Graphics.FromImage(oBitmap);

			oGraphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

			oGraphics.TranslateTransform(-rotationPoint.X, -rotationPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
			oGraphics.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Append);
			oGraphics.TranslateTransform(rotationPoint.X, rotationPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);

			oGraphics.DrawImage(input, new PointF(0, 0));

			oGraphics.Dispose();
			input = (Image)oBitmap;

			return oBitmap;
		} // Rotate (Image - By Point)
	}
}
