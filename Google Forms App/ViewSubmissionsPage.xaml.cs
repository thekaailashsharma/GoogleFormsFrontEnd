using YourNamespace.ViewModels;

namespace Google_Forms_App;

public partial class ViewSubmissionsPage : ContentPage
{
	public ViewSubmissionsPage()
	{
		InitializeComponent();
        BindingContext = new ViewSubmissionsViewModel();
    }
}
