using GerenciadorHotel.Application.Models;
using MediatR;

namespace GerenciadorHotel.Application.Interfaces.Cash.Queries.GetCashByMonth;

public class GetCashByMonthQuery : IRequest<ResultViewModel<int>>
{
    public GetCashByMonthQuery(int month, int year)
    {
        Month = month;
        Year = year;
    }
   
    public int Month { get; set; }
    public int Year { get; set; }
}