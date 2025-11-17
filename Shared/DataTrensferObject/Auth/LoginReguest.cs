using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransfererObjects.Auth;

public record LoginRequest([EmailAddress] string Email, string Password);