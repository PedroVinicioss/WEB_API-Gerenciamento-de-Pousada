using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.User.Commands.CreateUser;

public class ValidateCreateUserCommandBehavior : IPipelineBehavior<CreateUserCommand, ResultViewModel<int>>
{
    private AppDbContext _context;

    public ValidateCreateUserCommandBehavior(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ResultViewModel<int>> Handle(CreateUserCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
    {
        // Validação: email único
        if (_context.Users.Any(u => u.Email == request.Email))
            return ResultViewModel<int>.Error("Email já cadastrado");

        // Validação: CPF único
        if (_context.Users.Any(u => u.Cpf == request.Cpf))
            return ResultViewModel<int>.Error("CPF já cadastrado");

        // Validação de senha
        if (request.Password.Length < 6 ||
            !request.Password.Any(char.IsDigit) ||
            !request.Password.Any(char.IsUpper) ||
            !request.Password.Any(char.IsLower))
            return ResultViewModel<int>.Error("Senha deve conter ao menos 6 caracteres, um número, uma letra maiúscula e uma minúscula");
        
        return await next();
    }
}