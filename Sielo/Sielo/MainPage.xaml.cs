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

		    webView.Navigating += PageLoading;
		    actionBar.LoadRequest += OnLoadRequest;
		}

	    void PageLoading(object sender, WebNavigatingEventArgs e)
	    {
            actionBar.SetUrl(e.Url);
	    }

	    void OnLoadRequest(object sender, LoadRequestEventArgs e)
	    {
	        webView.Source = e.Url;
	    }
	}
}
