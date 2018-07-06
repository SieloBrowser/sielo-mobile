using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sielo.Views;
using Xamarin.Forms;

namespace Sielo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            // Web View events
		    webView.Navigating += PageLoading;

            // Action bar event
		    actionBar.LoadRequest += OnLoadRequest;
		    actionBar.GoBack += OnGoBack;
		    actionBar.GoForward += OnGoForward;
		}

	    void PageLoading(object sender, WebNavigatingEventArgs e)
	    {
            actionBar.SetUrl(e.Url);
	    }

	    void OnLoadRequest(object sender, LoadRequestEventArgs e)
	    {
	        webView.Source = e.Url;
	    }

	    void OnGoBack(object sender, EventArgs e)
	    {
            if (webView.CanGoBack) 
                webView.GoBack();
	    }

	    void OnGoForward(object sender, EventArgs e)
	    {
	        if (webView.CanGoForward)
	            webView.GoForward();
	    }
    }
}
