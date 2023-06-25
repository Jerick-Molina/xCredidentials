using DataAccess.Models;
using xCredidentials.Domain.DTOs;
using xCredidentials.Domain.Wrappers;
using xCredidentials.scripts;

namespace xCredidentials;

public static class API 
{
	
	
    public static void ConfigureApi(this WebApplication app)
    {
		app.MapPost("/SignIn", SignIn);
	
		app.MapPost("/SignUp", SignUp);

	}


    private static async Task<ApiResponse<LoginResponseDto>> SignIn(string email,string password, IUserData data,IJwtUtils jwt)
    {
        try
        {
            
            var result = await data.GetUserByAuthentication(email, script.HashPassword(password));

            if (result != null)
			{
                var s = jwt.GenerateIdentityJwtToken(result, "4zljz0npg5c9bmm5");
				return null;
			}

			return new ApiResponse<LoginResponseDto>("hello");
        }
		catch (Exception ex)
		{
			return null;
			throw;
		}
    }

	private static async Task<IResult> SignUp(UserModel user, IUserData data, IJwtUtils jwt)
	{	
	
		try
		{
			var exist = await data.GetUserByEmail(user.Email);
		
			if (exist.UserId != null)
			{
				return Results.BadRequest(error: new ErrorStructure
				{
					Message = "hello",
					Code = "hello",
				});
			}
			if (user != null) {
                user.Password = script.HashPassword(user.Password);
				Console.WriteLine(user.Password);
                await data.AddUser(user);

			var s =	jwt.GenerateIdentityJwtToken(user, "4zljz0npg5c9bmm5");
			
                return Results.Ok(s);
            }
			return Results.BadRequest();
			
		}
		catch (Exception ex)
		{
            return Results.Problem(ex.Message);
            throw;
		}
	}




}
