using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using Matrix = System.Numerics.Matrix4x4;
using Texture2D = System.Object;

using System.Collections.Generic;

namespace NvgSharp.Samples.D3D11.Platform;

public class D3DRenderer : INvgRenderer
{
  private const int MAX_VERTICES = 8192;
  
  private readonly bool _edgeAntiAlias; 
  private readonly bool _stencilStrokes;
  
  private readonly int[] _viewPortValues = new int[4];
  
  public D3DRenderer(bool edgeAntiAlias = true, bool stencilStrokes = true) {
    _edgeAntiAlias = edgeAntiAlias;
    _stencilStrokes = stencilStrokes;
  }
  
  public bool EdgeAntiAlias => _edgeAntiAlias;
  
  #region Texture
  public object CreateTexture(int width, int height) => new Texture(width, height);

  public Point GetTextureSize(object texture)
  {
    var t = (Texture)texture;
    return new Point(t.Width, t.Height);
  }
  
  public void SetTextureData(object texture, Rectangle bounds, byte[] data) {
    var t = (Texture)texture;
    t.SetData(bounds, data);
  }
  #endregion

  #region Draw
  public void Draw(float devicePixelRatio, IEnumerable<CallInfo> calls, Vertex[] vertexes) {
    
  }
  #endregion

  #region Dispose
  ~D3DRenderer() => Dispose(false);

  public void Dispose() => Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
    {
      return;
    }

    /*
    _vao.Dispose();
    _vertexBuffer.Dispose();
    _shader.Dispose();
    */
  }
  #endregion
}