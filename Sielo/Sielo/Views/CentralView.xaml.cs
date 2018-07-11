using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sielo.Views.Web;
using Xam.Plugin.TabView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Sielo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CentralView : TabViewControl
    {
        public event EventHandler<WebNavigatingEventArgs> Navigating;

        private int mFocusedView = 0;

        public CentralView() : base(new List<TabItem>() {new TabItem("Tab 1", new WebView())})
        {
            InitializeComponent();

            AddTab(new TabItem("Tab 2", new WebView()));
            AddTab(new TabItem("Tab 3", new WebView()));
            AddTab(new TabItem("Tab 4", new WebView()));
            AddTab(new TabItem("Tab 5", new WebView()));

            ((WebView)(ItemSource[0].Content)).Source = "https://doosearch.sielo.app/fr";
            ((WebView)(ItemSource[1].Content)).Source = "https://feldrise.com";
            ((WebView)(ItemSource[2].Content)).Source = "https://sielo.app";
            ((WebView)(ItemSource[3].Content)).Source = "https://youtube.com";
            ((WebView)(ItemSource[4].Content)).Source = "https://discordapp.com";

            ((WebView)(ItemSource[0].Content)).Navigating += OnNavigating;
            ((WebView)(ItemSource[1].Content)).Navigating += OnNavigating;
            ((WebView)(ItemSource[2].Content)).Navigating += OnNavigating;
            ((WebView)(ItemSource[3].Content)).Navigating += OnNavigating;
            ((WebView)(ItemSource[4].Content)).Navigating += OnNavigating;
        }

        public WebView CurrentView()
        {
            int index = 0;
            for (int i = 0; i < ItemSource.Count; ++i)
            {
                if (ItemSource[i].IsCurrent)
                {
                    index = i;
                    break;
                }
            }

            return (WebView)(ItemSource[index].Content);
        }

        public void SetTab(int index)
        {
            if (index >= ItemSource.Count)
                return;

            SetPosition(index);
        }

        public void OnLoadRequest(object sender, LoadRequestEventArgs e)
        {
            CurrentView().Source = e.Url;
        }

        public void OnGoBack(object sender, EventArgs e)
        {
            if (CurrentView().CanGoBack)
                CurrentView().GoBack();
        }

        public void OnGoForward(object sender, EventArgs e)
        {
            if (CurrentView().CanGoForward)
                CurrentView().GoForward();
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            var handler = Navigating;
            handler?.Invoke(this, e);
        }
    }
}