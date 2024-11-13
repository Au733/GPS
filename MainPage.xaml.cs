namespace CustomGPS;

public partial class MainPage : ContentPage
{
    private GeolocationRequest request; //class level variable request of type GeolocationRequest

    public MainPage()
    {
        InitializeComponent();
        Title = "Location Application";
        request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10)); //instantiate new GeolocationRequest object named request
    }


    async void UpdateLocation_OnClicked(object sender, EventArgs e)
    {
        Location location = await Geolocation.Default.GetLocationAsync(request); //creating Location object location.

        lblLat.Text = "Lat: " + location.Latitude.ToString(); //update lblLat to showcase location latitude
        lblLon.Text = "Lon: " + location.Longitude.ToString(); //update lblLon to showcase location longitude

        var placemarks = await Geocoding.Default.GetPlacemarksAsync(location.Latitude, location.Longitude); //variable placemarks that will grab list of possible addresses at set latitude and longitude
        var placemark = placemarks?.FirstOrDefault(); //variable placemark to grab the first address on the list from the placemarks list of addresses

        lblAddress1.Text = placemark.SubThoroughfare + " " + placemark.Thoroughfare;
        lblAddress2.Text = placemark.Locality + " " + placemark.AdminArea + " " + placemark.PostalCode;
    }
}