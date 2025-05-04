namespace EventForm.Models;

public class Repository
{
    public int Id { get; set; }

    private static List<GuestResponse> responses = [];
    public static IEnumerable<GuestResponse> Responses => responses;
    public static void AddResponse(GuestResponse guestResponse) => responses.Add(guestResponse);
}
