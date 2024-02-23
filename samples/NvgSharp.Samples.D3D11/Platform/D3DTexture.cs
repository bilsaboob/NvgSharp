using System;
using System.Drawing;

namespace NvgSharp.Samples
{
	public unsafe class Texture : IDisposable
	{
		private readonly int _handle;

		public readonly int Width;
		public readonly int Height;

		public Texture(int width, int height)
		{
			Width = width;
			Height = height;

			SetParameters();
		}

		private void SetParameters()
		{
		}

		public void Dispose()
		{
			
		}

		public void SetData(Rectangle bounds, byte[] data)
		{
			fixed (byte* ptr = data)
			{
			}
		}
	}
}