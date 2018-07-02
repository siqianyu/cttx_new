using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Web;

namespace Startech.Utils
{
	/// <summary>
	/// ImageUtility ��ժҪ˵����
	/// </summary>
	public sealed class ImageUtility
	{
		private ImageUtility()
		{}

		private static Size NewSize(int maxWidth, int maxHeight, int width, int height)
		{
			double w = 0.0;
			double h = 0.0;
			double sw = Convert.ToDouble(width);
			double sh = Convert.ToDouble(height);
			double mw = Convert.ToDouble(maxWidth);
			double mh = Convert.ToDouble(maxHeight);

			if ( sw < mw && sh < mh )
			{
				w = sw;
				h = sh;
			}
			else if ( (sw/sh) > (mw/mh) )
			{
				w = maxWidth;
				h = (w * sh)/sw;
			}
			else
			{
				h = maxHeight;
				w = (h * sw)/sh;
			}

			return new Size(Convert.ToInt32(w), Convert.ToInt32(h));
		}

		/// <summary>
		/// ��������ͼ
		/// </summary>
		/// <param name="fileName">ԭʼͼƬ·��</param>
		/// <param name="newFile">��ͼƬ�ı���·��</param>
		/// <param name="maxHeight">ͼƬ�����ĸ߶�</param>
        /// <param name="maxWidth">ͼƬ�����Ŀ��</param>
		public static void MakeSmallImage(string Filename, string newFile, int maxHeight, int maxWidth)
		{
			System.Drawing.Image img = Image.FromFile(Filename);
            MakeSmallImage(img, newFile, maxHeight, maxWidth);
		}
        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="file">�ϴ���ͼƬ</param>
        /// <param name="newFile">��ͼƬ�ı���·��</param>
        /// <param name="maxHeight">ͼƬ�����ĸ߶�</param>
        /// <param name="maxWidth">ͼƬ�����Ŀ��</param>
        public static void MakeSmallImage(HttpPostedFile file, string newFile, int maxHeight, int maxWidth)
        {
            System.Drawing.Image img = Image.FromStream(file.InputStream);
            MakeSmallImage(img, newFile, maxHeight, maxWidth);
        }
        public static void MakeSmallImage(Image img, string newFile, int maxHeight, int maxWidth)
        {
            System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;

            Size newSize = NewSize(maxWidth, maxHeight, img.Width, img.Height);
            Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
            Graphics g = Graphics.FromImage(outBmp);

            // ���û������������
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height),
                0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
            g.Dispose();

            // ���´���Ϊ����ͼƬʱ������ѹ������
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 50;

            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;

            //��ð����й�����ͼ��������������Ϣ��ImageCodecInfo ����
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICI = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICI = arrayICI[x];//����JPEG����
                    break;
                }
            }

            if (jpegICI != null)
            {
                outBmp.Save(newFile, jpegICI, encoderParams);
            }
            else
            {
                outBmp.Save(newFile, thisFormat);
            }

            img.Dispose();
            outBmp.Dispose();
        }
		public static void WriteLogo(Stream stream, string logo, string filename)
		{
			System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
			System.Drawing.Image copyImage = System.Drawing.Image.FromFile(logo);
			Graphics g = Graphics.FromImage(image);
			g.DrawImage(copyImage, new Rectangle(image.Width-copyImage.Width, image.Height-copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, GraphicsUnit.Pixel);
			image.Save(filename);
			g.Dispose();
			copyImage.Dispose();
			image.Dispose();
		}

		public static void addWatermarkImage(Image image, string WaterMarkPicPath,string _watermarkPosition, string filename, SmoothingMode smode, InterpolationMode imode)
		{
			Bitmap b = new Bitmap(image.Width, image.Height,PixelFormat.Format24bppRgb);
			Graphics picture = Graphics.FromImage(b);
			picture.Clear(Color.White);
			picture.SmoothingMode = smode;
			picture.InterpolationMode = imode;

			picture.DrawImage(image, 0, 0, image.Width, image.Height);

			int _width = image.Width;
			int _height = image.Height;

			Image watermark = new Bitmap(WaterMarkPicPath);

			ImageAttributes imageAttributes = new ImageAttributes();
			ColorMap colorMap = new ColorMap();

			colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
			colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
			ColorMap[] remapTable = {colorMap};

			imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

			float[][] colorMatrixElements = {
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  0.3f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
											};

			ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

			imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

			int xpos = 0;
			int ypos = 0;
			int WatermarkWidth=0;
			int WatermarkHeight=0;
			double bl=1d;
			//����ˮӡͼƬ�ı���
			//ȡ������1/4������Ƚ�
			if((_width>watermark.Width*4)&&(_height>watermark.Height*4))
			{
				bl=1;
			}
			else if((_width>watermark.Width*4)&&(_height<watermark.Height*4))
			{
				bl=Convert.ToDouble(_height/4)/Convert.ToDouble(watermark.Height);

			}
			else

				if((_width<watermark.Width*4)&&(_height>watermark.Height*4))
			{
				bl=Convert.ToDouble(_width/4)/Convert.ToDouble(watermark.Width);
			}
			else
			{
				if((_width*watermark.Height)>(_height*watermark.Width))
				{
					bl=Convert.ToDouble(_height/4)/Convert.ToDouble(watermark.Height);

				}
				else
				{
					bl=Convert.ToDouble(_width/4)/Convert.ToDouble(watermark.Width);

				}

			}

			WatermarkWidth=Convert.ToInt32(watermark.Width*bl);
			WatermarkHeight=Convert.ToInt32(watermark.Height*bl);



			switch(_watermarkPosition)
			{
				case "WM_TOP_LEFT":
					xpos = 10;
					ypos = 10;
					break;
				case "WM_TOP_RIGHT":
					xpos = _width - WatermarkWidth - 10;
					ypos = 10;
					break;
				case "WM_BOTTOM_RIGHT":
					xpos = _width - WatermarkWidth - 5;
					ypos = _height -WatermarkHeight - 5;
					break;
				case "WM_BOTTOM_LEFT":
					xpos = 10;
					ypos = _height - WatermarkHeight - 10;
					break;
			}

			picture.DrawImage(watermark, new Rectangle(xpos, ypos, WatermarkWidth, WatermarkHeight), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

			b.Save(filename);
			watermark.Dispose();
			imageAttributes.Dispose();
			picture.Dispose();
		}

		public static void addWatermarkImage(Image image, string WaterMarkPicPath,string _watermarkPosition, string filename)
		{
			addWatermarkImage(image, WaterMarkPicPath, _watermarkPosition, filename, SmoothingMode.HighQuality, InterpolationMode.HighQualityBicubic);
		}

		/// <summary>
		///  ��ˮӡͼƬ
		/// </summary>
		/// <param name="stream">�ϴ�����</param>
		/// <param name="WaterMarkPicPath">ˮӡͼƬ�ĵ�ַ</param>
		/// <param name="_watermarkPosition">ˮӡλ��</param>
		public static void addWatermarkImage(Stream stream, string WaterMarkPicPath,string _watermarkPosition, string filename)
		{
			System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

			addWatermarkImage(image, WaterMarkPicPath, _watermarkPosition, filename);

			image.Dispose();
		}
	}
}
