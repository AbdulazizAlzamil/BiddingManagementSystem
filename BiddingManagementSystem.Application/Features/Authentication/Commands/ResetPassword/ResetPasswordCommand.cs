using MediatR;

public class ResetPasswordCommand : IRequest<Unit>, IBaseRequest
{
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; } // Added property for password confirmation
}
