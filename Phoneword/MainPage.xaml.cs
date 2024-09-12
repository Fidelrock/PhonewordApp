namespace Phoneword;

public partial class MainPage : ContentPage
{

    string translatedNumber;
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = core.PhonewordTranslator.ToNumber(enteredNumber);


        if (!string.IsNullOrEmpty(translatedNumber))
        {
            //TODO
            CallButton.IsEnabled = true;
            CallButton.Text = "Call" + translatedNumber;
        }
        else
        {
            //TODO
            CallButton.IsEnabled = false;
            CallButton.Text = "Call";
        }

    }

    async void OnCall(object sender, System.EventArgs e)
    {

        if (await this.DisplayAlert(
           "Dial a Number",
           "Would you like to call " + translatedNumber + "?",
           "Yes",
           "No"))
        {
            //TODO: dial the phone
            try
            {

                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(translatedNumber);

            }
            catch (ArgumentNullException) {

                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }

            catch (Exception)
                {
                //Other error has occurred

                await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
            }


            }

        }
    }


