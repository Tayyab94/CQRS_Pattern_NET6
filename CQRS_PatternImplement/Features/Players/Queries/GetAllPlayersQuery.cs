using CQRS_PatternImplement.Models;
using CQRS_PatternImplement.Repositories;
using MediatR;

namespace CQRS_PatternImplement.Features.Players.Queries
{
    public class GetAllPlayersQuery:IRequest<IEnumerable<Player>>
    {
        public class GetAllPlayerQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
        {
            private readonly IPlayersService _playerService;

            public GetAllPlayerQueryHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }
            public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
            {
                return await _playerService.GetPlayersList();
            }
        }
    }
}
