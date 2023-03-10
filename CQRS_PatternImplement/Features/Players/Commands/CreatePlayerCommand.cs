using CQRS_PatternImplement.Models;
using CQRS_PatternImplement.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CQRS_PatternImplement.Features.Players.Commands
{
    public class CreatePlayerCommand :IRequest<Player>
    {
        public int ShirtNo { get; set; }
        public string Name { get; set; }
        public int Appearances { get; set; }
        public int Goals { get; set; }
        public int position { get;set; }

        public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Player>
        {
            private readonly IPlayersService _playerService;

            public CreatePlayerCommandHandler(IPlayersService playerService)
            {
                _playerService = playerService;
            }
            public async Task<Player> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
            {
                command.position = 1;
                var player = new Player()
                {
                    ShirtNo = command.ShirtNo,
                    Name = command.Name,
                    Appreaances = command.Appearances,
                    Goals = command.Goals,
                    PositionId= command.position,
                };

                return await _playerService.CreatePlayer(player);
            }
        }
    }
}
