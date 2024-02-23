using System;
using System.Diagnostics;
using NvgSharp.Samples.D3D11.Platform;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;
using WinApi.DxUtils.Component;
using WinApi.Windows;

namespace NvgSharp.Samples.D3D11;

public sealed class MainWindow : EventedWindowCore
{
    private readonly Dx11Component _dx = new ();
    private NvgContext _nvgContext;
    private Demo _demo;

    protected override void OnCreate(ref CreateWindowPacket packet)
    {
        this._dx.Initialize(this.Handle, this.GetClientSize());
        
        var renderer = new D3DRenderer(true, true);
        _nvgContext = new NvgContext(renderer, renderer.EdgeAntiAlias);
        _demo = new Demo(_nvgContext);
        
        base.OnCreate(ref packet);
    }

    protected override void OnPaint(ref PaintPacket packet) {
        UpdateFps();

        var size = this.GetClientSize();
        var w = size.Width;
        var h = size.Height;

        this._dx.EnsureInitialized();
        try {
            D3DPaint();
        }
        catch (SharpDXException ex)
        {
            if (!this._dx.PerformResetOnException(ex)) throw;
        }
    }

    private void D3DPaint() {
        var wndSize = GetWindowSize();
        
        var nvg = _nvgContext;
        var D3D = this._dx.D3D;
        D3D.Context.ClearRenderTargetView(D3D.RenderTargetView, new RawColor4(0.0f, 0.0f, 255.0f, 1.0f));
        
        nvg.ResetState();

        _demo.renderSimpleRectDemo(_nvgContext);
        //_demo.renderDemo(nvg, 100, 100, wndSize.Width, wndSize.Height, (float)_paintTimer.Elapsed.TotalSeconds, false);
        
        nvg.Flush();
        
        D3D.SwapChain.Present(0, PresentFlags.None);
        Validate();
    }

    protected override void OnSize(ref SizePacket packet)
    {
        this._dx.Resize(packet.Size);
        base.OnSize(ref packet);
    }

    protected override void Dispose(bool disposing)
    {
        this._dx.Dispose();
        base.Dispose(disposing);
    }
    
    #region Fps
    private int _paintCount;
    private int _paintFps;
    private long _lastPaintFpsElapsed;
    private Stopwatch _paintTimer;
    
    private void UpdateFps() {
        _paintTimer ??= Stopwatch.StartNew();
        ++_paintCount;
        var elapsed = _paintTimer.ElapsedMilliseconds;
        var elapsedDiff = elapsed - _lastPaintFpsElapsed;
        if (elapsedDiff >= 1000 && elapsed != _lastPaintFpsElapsed) {
            _paintFps = _paintCount;
            _paintCount = 0;
            Console.WriteLine($"paint FPS: {_paintFps}");
            _lastPaintFpsElapsed = _paintTimer.ElapsedMilliseconds;
        }
    }
    #endregion
}