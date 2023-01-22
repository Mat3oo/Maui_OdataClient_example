using odataMacCatalystExample;
using testOdataMaui;

ODataServiceContext odataContext;

odataContext = new(new Uri("http://services.odata.org/TripPinRESTierService/(S(3mslpb2bc0k5ufk24olpghzx))/"));

try
{
    var result = odataContext.People.Execute();
}
catch (Exception ex)
{
    throw;
}

// This is the main entry point of the application.
// If you want to use a different Application Delegate class from "AppDelegate"
// you can specify it here.
UIApplication.Main (args, null, typeof (AppDelegate));

