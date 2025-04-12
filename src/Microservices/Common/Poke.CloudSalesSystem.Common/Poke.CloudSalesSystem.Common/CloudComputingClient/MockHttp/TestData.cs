using Poke.CloudSalesSystem.Common.CloudComputingClient.Abstract.Model;

namespace Poke.CloudSalesSystem.Common.CloudComputingClient.MockHttp;

public sealed class TestData
{
    public static Guid Account1_Id = Guid.Parse("61db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account2_Id = Guid.Parse("62db564e-5ef0-4614-9127-562a8b2856db");
    public static Guid Account3_Id_FailsToOrder = Guid.Parse("63db564e-5ef0-4614-9127-562a8b2856db");

    public static Guid ExternalSub1_id = Guid.Parse("b337547d-4f1c-4b17-b464-8e4e28899a8b");
    public static Guid ExternalSub2_id = Guid.Parse("b437547d-4f1c-4b17-b464-8e4e28899a8b");
    public static Guid ExternalSub3_id = Guid.Parse("b537547d-4f1c-4b17-b464-8e4e28899a8b");

    public static Guid Service1_Id = Guid.Parse("d284eb26-9d42-4c16-89cb-ce75e0ab5afa");
    public static Guid Service2_Id = Guid.Parse("d384eb26-9d42-4c16-89cb-ce75e0ab5afa");

    public static Guid ProviderId = Guid.Parse("8d206b9f-d4b6-449c-b898-3c973cfe4a69");

    public static List<CloudComputingService> Services = new List<CloudComputingService>
        {
            new ()
            {
                Id = TestData.Service1_Id,
                Name = "Service 1",
                Description = "Service description 1...",
                ProviderId = TestData.ProviderId
},
            new ()
            {
                Id = TestData.Service2_Id,
                Name = "Service 2",
                Description = "Service description 2...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("05b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 3",
                Description = "Service description 3...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("06b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 4",
                Description = "Service description 4...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("07b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 5",
                Description = "Service description 5...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("08b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 6",
                Description = "Service description 6...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("09b2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 7",
                Description = "Service description 7...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("0ab2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 8",
                Description = "Service description 8...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("0bb2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 9",
                Description = "Service description 9...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("d384eb26-9d42-4c16-89cb-ce75e0ab5afa"),
                Name = "Service 2",
                Description = "Service description 2...",
                ProviderId = TestData.ProviderId
            },
            new()
            {
                Id = Guid.Parse("0cb2b369-3583-42cf-a08c-752d8456f561"),
                Name = "Service 10",
                Description = "Service description 10...",
                ProviderId = TestData.ProviderId
            }
        };
}
