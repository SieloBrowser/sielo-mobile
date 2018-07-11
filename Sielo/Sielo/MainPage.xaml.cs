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
	    private int mCounter = 0;

		public MainPage()
		{
			InitializeComponent();

            // Web View actions
		    mCentralView.Navigating += OnPageLoading;

            // Action bar event
		    mActionBar.LoadRequest += mCentralView.OnLoadRequest;
		    mActionBar.GoBack += mCentralView.OnGoBack;
		    mActionBar.GoForward += mCentralView.OnGoForward;
		    mActionBar.ShowTabs += OnShowTabs;
		}

	    void OnPageLoading(object sender, WebNavigatingEventArgs e)
	    {
            mActionBar.SetUrl(e.Url);
	    }

	    void OnShowTabs(object sender, EventArgs e)
	    {
            mCentralView.SetTab(mCounter);

	        if (mCounter < 4)
	            mCounter++;
	        else
	            mCounter--;
	    }
    }
}
