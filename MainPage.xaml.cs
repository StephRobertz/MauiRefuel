namespace MauiRefuel;

public partial class MainPage : TabbedPage
{


    //Tallennuspaikka
    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder
           .LocalApplicationData), "refuel.txt");

    string text = "";

    public MainPage()
	{
		InitializeComponent();


        //Onko tiedosto ennestään olemassa
        bool doesExist = File.Exists(fileName);

        if (doesExist == true)
        {
            text = File.ReadAllText(fileName);
            if (text.Length > 0)
            {
                outputLabel.Text = text;
            }
            else
            {
                outputLabel.Text = "Mitään ei ole talletettu muistioon.";
            }

        }
        else
        {
            outputLabel.Text = "Tervetuloa uudelle käyttäjälle!";
        }
    }




    private void SaveBtn_Clicked(object sender, EventArgs e)
    {


       
        text = text + Environment.NewLine + stationPicker.SelectedItem;
        text = text + Environment.NewLine + pricePicker.SelectedItem;
        text = text + Environment.NewLine + petrolTypePicker.SelectedItem;
        text = text + Environment.NewLine + "Vehicle: " + inputKentta1.Text;
        text = text + Environment.NewLine + "Platenumer: " + inputKentta2.Text;
        text = text + Environment.NewLine + "Firstname:" + inputKentta3.Text;
        text = text + Environment.NewLine + "Lastname: " + inputKentta4.Text;
        

        File.WriteAllText(fileName, text);
       
        stationPicker.SelectedItem = "";
        pricePicker.SelectedItem = "";
        petrolTypePicker.SelectedItem = "";
        outputLabel.Text = text;
        inputKentta1.Text = "";
        inputKentta2.Text = "";
        inputKentta3.Text = "";
        inputKentta4.Text = "";
    }

    private void DeleteBtn_Clicked(object sender, EventArgs e)
    {
        outputLabel.Text = string.Empty;

        File.Delete(fileName);
       

    }

    private void pricePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the selected item from the Picker
        string selectedOption = (string)pricePicker.SelectedItem;

        // Update the text in the TextField
        outputLabel.Text = selectedOption;

    }

    private void stationPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the selected item from the Picker
        string selectedOption = (string)stationPicker.SelectedItem;

        // Update the text in the TextField
        outputLabel.Text = selectedOption;

    }

    private async void ConfirmButtonClicked(object sender, EventArgs e)
    {
        // Show an alert pop-up
        await DisplayAlert("Confirmation", "Refueling successfully started", "OK");
    }

    private void petrolTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the selected item from the Picker
        string selectedOption = (string)petrolTypePicker.SelectedItem;

        // Update the text in the TextField
        outputLabel.Text = selectedOption;
    }
}




