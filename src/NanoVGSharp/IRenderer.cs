﻿using Microsoft.Xna.Framework.Graphics;
using System;

namespace NanoVGSharp
{
	public interface IRenderer
	{
		void Begin();
		void End();

		int renderCreateTexture(int type, int w, int h, int imageFlags, byte[] data);
		void renderDeleteTexture(int image);
		void renderUpdateTexture(int image, int x, int y, int w, int h, byte[] data);
		void renderGetTextureSize(int image, out int w, out int h);
		void renderViewport(float width, float height, float devicePixelRatio);
		void renderFill(ref Paint paint, CompositeOperationState compositeOperation, ref Scissor scissor, float fringe, Bounds bounds, Buffer<Path> paths);
		void renderStroke(ref Paint paint, CompositeOperationState compositeOperation, ref Scissor scissor, float fringe, float strokeWidth, Buffer<Path> paths);
		void renderTriangles(ref Paint paint, CompositeOperationState compositeOperation, ref Scissor scissor, ArraySegment<VertexPositionColorTexture> verts);
	}
}
