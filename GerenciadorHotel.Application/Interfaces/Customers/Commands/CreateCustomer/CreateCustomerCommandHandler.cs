﻿using System.Security.Cryptography;
using System.Text;
using GerenciadorHotel.Application.Models;
using GerenciadorHotel.Infrastructure.Persistence;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ResultViewModel<int>>
{
    private readonly AppDbContext _context;

    public CreateCustomerCommandHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResultViewModel<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = DoHash(request.Password);

        request.Password = hashedPassword;
        var user = request.ToEntity();
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(user.Id);
    }

    private string DoHash(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
