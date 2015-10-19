using System;
using Xamarin.Forms;
using QUTBraingear.Data;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;


[assembly:ExportRenderer(typeof(WebView), typeof(ZoomableWebViewRenderer))]

namespace QUTBraingear.Data
{
	public class ZoomableWebViewRenderer: WebViewRenderer
	{
		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (Control != null) {
				Control.Settings.BuiltInZoomControls = true;
				Control.Settings.DisplayZoomControls = false;
			}
			base.OnElementPropertyChanged(sender, e);
		}
	}
}

