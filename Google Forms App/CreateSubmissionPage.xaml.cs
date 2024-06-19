using YourNamespace.ViewModels;
namespace Google_Forms_App;

public partial class CreateSubmissionPage : ContentPage
{
	public CreateSubmissionPage()
	{
		InitializeComponent();

        BindingContext = new CreateSubmissionViewModel();
    }
}
