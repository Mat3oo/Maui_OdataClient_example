using Microsoft.OData.Client;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace testOdataMaui;

public partial class ODataServiceContext : DataServiceContext
{
    public DataServiceQuery<PeopleModel> People { get; }

    public ODataServiceContext(Uri serviceRoot) : base(serviceRoot)
    {
        //Add this to override the default HttpWebRequest for making requests in OData Client.
        HttpRequestTransportMode = HttpRequestTransportMode.HttpClient;

        People = base.CreateQuery<PeopleModel>("People");
        Format.LoadServiceModel = () => GetEdmModel();
        Format.UseJson();
    }

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<PeopleModel>("People")
            .EntityType
            .HasKey(p => p.UserName)
            .Count()
            .Select()
            .Page(null, 100)
            .Filter();

        return builder.GetEdmModel();
    }
}

public class PeopleModel
{
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
}