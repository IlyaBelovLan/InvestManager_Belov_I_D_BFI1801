namespace InvestManager.Users.UseCases.Users.RegisterUser
{
    using AutoMapper;
    using Database.Models;

    public class RegisterUserMapping : Profile
    {
        public RegisterUserMapping()
        {
            CreateMap<RegisterUserCommand, EntityUser>();
        }
    }
}