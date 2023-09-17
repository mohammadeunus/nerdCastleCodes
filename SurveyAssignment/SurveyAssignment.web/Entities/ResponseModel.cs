namespace SurveyAssignment.web.Entities;

public class ResponseModel
{ 
    public int Id { get; set; } 
    public string Option { get; set; }
    public string UserIpAddress { get; set; } // Add this field to store the user's IP address
}
