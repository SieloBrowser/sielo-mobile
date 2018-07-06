using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sielo.Views.Web
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SWebView : WebView
	{
		public SWebView ()
		{
			InitializeComponent ();

		    Source = Sielo.Helpers.Settings.HomePage;
		}
	}
}