﻿namespace Services.DTOs.CollaboratorDTOs;

public class CollaboratorAddDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string AppUserId { get; set; }
}